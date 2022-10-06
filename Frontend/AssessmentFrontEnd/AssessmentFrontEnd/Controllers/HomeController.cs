using AssessmentFrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AssessmentFrontEnd.Controllers
{
    public class HomeController : Controller
    {


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

       
    }
}