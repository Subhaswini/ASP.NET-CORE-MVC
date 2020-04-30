using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace TestMVCCore.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if ((exceptionHandlerPathFeature != null) && (exceptionHandlerPathFeature.Error != null))
            {
                // In our example, the ExceptionHelper.LogException() method will take care of   
                // logging the exception to the database and perhaps even alerting the webmaster  
                // Make sure that this method doesn't throw any exceptions or you might end  
                // in an endless loop!  
                //ExceptionHelper.LogException(exceptionHandlerPathFeature.Error);
            }
            return Content("We're so sorry, but an error just occurred! We'll try to get it fixed ASAP!");
        }
        public IActionResult Http(int statusCode)
        {
            if (statusCode == 404)
            {
                // Log this error here, e.g. to a database. You can use the HttpContext.Request   
                // object to access important information like the requested URL  
            }
            // Return a View where the problem is explained. It can use the common Layout or not  
            // and you can even make specific views for the types of errors you want to handle,  
            // e.g. Error404.cshtml, as shown here...  
            if (statusCode == 404)
                return View("Error404");
            return View();
        }
    }
}