using AspNetCoreAssessment.Manger;
using AspNetCoreAssessment.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAssessment.Controllers
{
    public class DocumentController : Controller    
    {
        private readonly DocumentManger documentManger;
        private readonly PriorityManger priorityManger;

        public DocumentController(DocumentManger documentManger, PriorityManger priorityManger)
        {
            this.documentManger = documentManger;
            this.priorityManger = priorityManger;
        }
        [HttpGet]
        public IActionResult Index(string Msg)
        {
            if(!string.IsNullOrEmpty(Msg))
            {
            ViewBag.Msg = Msg;

            }
            return View();
        }
        [HttpGet]
        public IActionResult upload()
        {
            ViewBag.PrioritiesSelectList = priorityManger.GetAllPriorities();

            return View();
        }
        [HttpPost]
        public IActionResult upload(DocumentVM documentVM)
        {
            ViewBag.PrioritiesSelectList = priorityManger.GetAllPriorities();

            if(ModelState.IsValid)
            {
                if(documentVM.DocumentFiles == null)
                {
                    ModelState.AddModelError("", "At Least Upload one file");
                    ViewBag.PrioritiesSelectList = priorityManger.GetAllPriorities();
                    return View();
                }
                documentManger.UploadDocument(documentVM);
                Redirect("/Document#AvalableDocs?Msg=UploadSuccess#Msg");

            }
            return View();
        }
        [HttpGet]
        public IActionResult details(int Id=0)
        {
            if(Id==0)
            {
                return Redirect("/Document?Msg=NoDocument#Msg");
            }
            var data = documentManger.GetDocumentById(Id);
            return View(data);
        }
        [HttpGet]
        public IActionResult update(int Id = 0)
        {            
            ViewBag.PrioritiesSelectList = priorityManger.GetAllPriorities();

            if (Id == 0)
            {
                return Redirect("/Document?Msg=NoDocument#Msg");
            }
            var data = documentManger.GetDocumentById(Id);
            return View(data);
        }
        [HttpPost]
        public IActionResult update(DocumentVM documentVM)
        {
            ViewBag.PrioritiesSelectList = priorityManger.GetAllPriorities();

            if (ModelState.IsValid)
            {
                documentManger.UpdateDocument(documentVM);
                return Redirect("/Document?Msg=UpdatedSuccessfuly#Msg");

            }
            return View();
        }
        [HttpGet]
        public IActionResult delete(int Id = 0)
        {
            if (Id == 0)
                return Redirect("/Document?Msg=NoDocument#Msg");
            documentManger.DeleDocument(Id);
            return Redirect("/Document?Msg=DeletedSuccessfuly#Msg");
        }

    }
}
