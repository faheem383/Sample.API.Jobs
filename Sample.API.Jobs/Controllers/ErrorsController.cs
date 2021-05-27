using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Sample.API.Jobs.Controllers
{
	[ApiController]
	[ApiExplorerSettings(IgnoreApi = true)]
	public class GlobalErrorsController : ControllerBase
	{
		[HttpGet]
		[Route("/errors")]
		public IActionResult HandleErrors()
		{
			var contextException = HttpContext.Features.Get<IExceptionHandlerFeature>();
			var responseStatusCode = contextException.Error.GetType().Name switch
			{
				"NullReferenceException" => HttpStatusCode.BadRequest,
				_ => HttpStatusCode.ServiceUnavailable
			};

			if (contextException.Error.GetType().Name == "CustomException")
			{
				CustomException ex = (CustomException)contextException.Error;
				if (ex != null)
				{
					responseStatusCode = (HttpStatusCode)ex.ErrorCode;
				}
			}
			



			return Problem(detail: contextException.Error.Message, statusCode:(int)responseStatusCode);
		}
	}
}
