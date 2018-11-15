using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UAMovie.Controllers
{
    public class MyAccountController : Controller
    {
        public IActionResult NowPlaying()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PaymentInfo()
        {
            return View();
        }

        public IActionResult PreferredTheater()
        {
            return View();
        }
    }
}