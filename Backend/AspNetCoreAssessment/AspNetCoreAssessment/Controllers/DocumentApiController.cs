using AspNetCoreAssessment.Manger;
using AspNetCoreAssessment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentApiController : ControllerBase
    {
        private readonly DocumentManger documentManger;
        private readonly PriorityManger priorityManger;

        public DocumentApiController(DocumentManger documentManger, PriorityManger priorityManger)
        {
            this.documentManger = documentManger;
            this.priorityManger = priorityManger;
        }
        [HttpPost]
        public IActionResult upload(DocumentVM documentVM)
        {
           
                if (documentVM.DocumentFiles == null)
                    return BadRequest();
                var priority = priorityManger.SearchPriority(documentVM.Priority);
                if(priority == null)
                    return NotFound();
                documentManger.UploadDocument(documentVM);
                return Ok();
        }
        [HttpGet("{Id}")]
        public IActionResult details(int Id = 0)
        {
            if (Id == 0)
                return BadRequest();
            var data = documentManger.GetDocumentById(Id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }
        [HttpPut]
        public IActionResult update(DocumentVM documentVM)
        {
            var data = documentManger.GetDocumentById(documentVM.DocumentId);
            if (data == null)
                return NotFound();

            documentManger.UpdateDocument(documentVM);
            return NoContent();    
        }
        [HttpDelete]
        public IActionResult delete(int Id = 0)
        {
            if (Id == 0)
                return BadRequest();
            var data = documentManger.GetDocumentById(Id);
            if (data == null)
                return NotFound();
            documentManger.DeleDocument(Id);
            return NoContent();
        }
        [HttpGet]
        public IActionResult GetAllDocuments()
        {
            var data = documentManger.GetDocuments();
            if (data == null)
                return NoContent();
            return Ok(data);
        }
    }
}
