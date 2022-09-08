using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error(int code)
        {
            return View();
        }
    }
}
