using AspNetCoreAssessment.Manger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;

namespace AspNetCoreAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentListController : ControllerBase
    {
        private readonly DocumentManger documentManger;

        public DocumentListController(DocumentManger documentManger)
        {
            this.documentManger = documentManger;
        }
        [HttpPost]
        public IActionResult ListCustomer()
        {
            var pageSize = int.Parse(Request.Form["length"]);
            var skip = int.Parse(Request.Form["start"]);

            var searchValue = Request.Form["search[value]"];

            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];

            var Documents = documentManger.SearchDocument(searchValue);

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                Documents = Documents.OrderBy(string.Concat(sortColumn, " ", sortColumnDirection));

            var data = Documents.Skip(skip).Take(pageSize).ToList();

            var recordsTotal = Documents.Count();

            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };

            return Ok(jsonData);
        }
    }
}
