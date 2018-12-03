using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UAMovie.Models;

namespace UAMovie.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.goodLogin = null;
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountUser user)
        {
            if(user.login())
            {
                ViewBag.goodLogin = true;
                return RedirectToAction("Login", "Accountuser", new {username = user.Username });
            }
            //Error message?
            ViewBag.goodLogin = false;
            return View();
        }
        public IActionResult SignUp()
        {
            //View Data["Message"] = "";
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
