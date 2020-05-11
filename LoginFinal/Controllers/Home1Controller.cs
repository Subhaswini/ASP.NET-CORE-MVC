using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginFinal.Controllers
{
    public class Home1Controller : Controller
    {
       /* private IEmployeeRepository _employeeRepository;
        public Home1Controller(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }*/
        public IActionResult Index()
        {
            return View();
        }
    }
}