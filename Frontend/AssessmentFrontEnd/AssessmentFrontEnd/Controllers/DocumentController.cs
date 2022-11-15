using AssessmentFrontEnd.Manger;
using AssessmentFrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentFrontEnd.Controllers
{
    public class DocumentController : Controller
    {
        [HttpGet]
        public IActionResult Index(string Msg)
        {
            if (!string.IsNullOrEmpty(Msg))
            {
                ViewBag.Msg = Msg;

            }
            return View();
        }
        [HttpGet]
        public IActionResult upload()
        {
            ViewBag.PrioritiesSelectList = PriorityManger.GetPriorities();
            return View();
        }
        [HttpPost]
        public IActionResult upload(DocumentVM document)
        {
            if (ModelState.IsValid)
            {
                if (document.DocumentFiles == null)
                {
                    ModelState.AddModelError("", "at Least upload one file to the document");
                    ViewBag.PrioritiesSelectList = PriorityManger.GetPriorities();
                    return View();

                }
                DocumentManger.UploadDocument(document);
                return Redirect("/Document#AvalableDocs");
            }
            ViewBag.PrioritiesSelectList = PriorityManger.GetPriorities();
            return View();

        }
        [HttpGet]
        public IActionResult details(int Id = 0)
        {

            return View();
        }
        [HttpGet]
        public IActionResult update(int Id = 0)
        {
            
            return View();
        }
    }
}
