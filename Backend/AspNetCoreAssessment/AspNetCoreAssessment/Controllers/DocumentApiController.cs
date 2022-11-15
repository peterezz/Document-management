using AspNetCoreAssessment.Manger;
using AspNetCoreAssessment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

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
                return BadRequest("At least upload file to the document");
            var priority = priorityManger.SearchPriority(documentVM.Priority);
            if (priority == null)
                return BadRequest("Please enter a valid priority");
            documentManger.UploadDocument(documentVM);
            return Ok(documentVM);
        }
        [HttpGet("GetDocumentById/{Id}")]
        public IActionResult GetDocumentById(int Id )
        {
            if (Id == 0)
                return BadRequest();
                var data = documentManger.GetDocumentById(Id);
                if (data == null)
                    return NotFound("document not found");
            return Ok(data);
        }
        [HttpPut]
        public IActionResult update( DocumentVM documentVM)
        {
            var data = documentManger.GetDocumentById(documentVM.DocumentId);
            if (data == null)
                return NotFound("No Such a document");

            documentManger.UpdateDocument(documentVM);
            return Ok(documentVM);
        }
        [HttpDelete("{Id}")]
        public IActionResult delete(int Id = 0)
        {
            if (Id == 0)
                return BadRequest();
            var data = documentManger.GetDocumentById(Id);
            if (data == null)
                return NotFound("Document not found");
            documentManger.DeleDocument(Id);
            return NoContent();
        }
        [HttpGet()]
        public IActionResult GetAllDocuments()
        {
            var data = documentManger.GetDocumentsVM();
            return Ok(data);
        }
    }
}
