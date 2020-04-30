using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestMVCCore.Controllers
{
    public class QueryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult QueryTest()
        {
            string name = "John Doe";
            if (!String.IsNullOrEmpty(HttpContext.Request.Query["name"]))
                name = HttpContext.Request.Query["name"];

            return Content("Name from query string: " + name);
        }
        [HttpGet]
        public IActionResult FormsTest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FormsTestPost()
        {
            return Content("Hello, " + HttpContext.Request.Form["UserName"] + ". You are " + HttpContext.Request.Form["UserAge"] + " years old!");
        }
    }
}