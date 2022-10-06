using AssessmentFrontEnd.Manger;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentFrontEnd.Controllers
{
    public class DocumentController : Controller
    {
        [HttpGet]
        public IActionResult Index(string Msg)
        {
            DocumentManger.GetDocument();
            return View();
        }
        [HttpGet]
        public IActionResult upload()
        {
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
