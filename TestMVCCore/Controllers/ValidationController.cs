using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestMVCCore.Models;
using TestMVCCore.ViewModels;


namespace TestMVCCore.Controllers
{
    public class ValidationController : Controller
    {
        [HttpGet]
        public IActionResult SimpleValidation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SimpleValidation(WebUser webUser)
        {
            if (ModelState.IsValid)
                return Content("Thank you!");
            else
                return View(webUser);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(WebUser user1)
        {
            if (ModelState.IsValid)
                return Content("Thanks!");
            else
                return View(user1);
        }

        public ViewResult EditUser()
        {
            EditUserViewModel viewModel = new EditUserViewModel();
            viewModel.User = new WebUser()
            {
                FirstName = "John",
                LastName = "Doe",
                Country = "USA"
            };
            viewModel.Countries = new List<string>()
            {
                "USA",
                "Great Britain",
                "Germany"
            };
            return View(viewModel);
        }
    }
}