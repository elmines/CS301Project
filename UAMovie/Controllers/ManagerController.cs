using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UAMovie.Models;

namespace UAMovie.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index(AccountUser user)
        {
            return View(user);
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