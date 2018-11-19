using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UAMovie.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MovieReport()
        {
            return View();
        }

        public IActionResult RevenueReport()
        {
            return View();
        }
    }
}