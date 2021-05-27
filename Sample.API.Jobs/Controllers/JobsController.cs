using Microsoft.AspNetCore.Mvc;
using Sample.API.Jobs.Repository;
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
            var result = await _ijobRepository.GetAllJobsAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> GetJobByIdAsync(int id)
        {
            var result = await _ijobRepository.GetJobAsync(id);
            return Ok(result);
        }
    }
}
