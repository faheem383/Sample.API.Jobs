using Microsoft.AspNetCore.Mvc;
using Sample.API.Jobs.Repository;
using System.Net;
using System.Threading.Tasks;

namespace Sample.API.Jobs.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobRepository _ijobRepository;
        public JobsController(IJobRepository jobRepository)
        {
            _ijobRepository = jobRepository;
        }



        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetAllJobsAsync()
        {
            //throw new System.NullReferenceException("Id is required");
            throw new CustomException("Need valid user login", (int)HttpStatusCode.Forbidden);




            var result = await _ijobRepository.GetAllJobsAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> GetJobByIdAsync(int id)
        {
            var result = await _ijobRepository.GetJobAsync(id);

            if (result == null) {
                throw new CustomException("No job found", (int)HttpStatusCode.NotFound);
            }
            return Ok(result);
        }
    }
}
