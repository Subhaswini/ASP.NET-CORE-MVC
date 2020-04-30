using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TestMVCCore.Models;
using Microsoft.Extensions.Options;

namespace TestMVCCore.Controllers
{
    public class HomeController : Controller
    {
        /*private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }*/
        /*public ActionResult Index()
        {
            //return Content("Welcome to " + _configuration.GetValue<string>("WebsiteTitle"));
            return View();
        }*/
        private WebOptions _webOptions;
        public HomeController(IOptions<WebOptions> websiteOptions)
        {
            this._webOptions = websiteOptions.Value;
        }
        public IActionResult Index()
        {
            return Content("Welcome to " + _webOptions.Title);
        }
    }
}
