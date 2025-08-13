using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OnlineGallery.Controllers
{

    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        [Route("Home/Error")]
        public IActionResult Error()
        {
            var exceptionFeature = HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
            return View(exceptionFeature);
        }
    }
}