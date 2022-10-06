using AspNetCoreAssessment.Manger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioritiesController : ControllerBase
    {
        private readonly PriorityManger priorityManger;

        public PrioritiesController(PriorityManger priorityManger)
        {
            this.priorityManger = priorityManger;
        }
        [HttpGet]
        public IActionResult GetAllPriorities()
        {
           var data= priorityManger.GetAllPriorities();
            return Ok(data);
        }
    }
}
