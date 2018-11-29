using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UAMovie.Models;

namespace UAMovie.Controllers
{
    public class AccountUserController : Controller
    {
        public IActionResult Create()
        {
            AccountUser user = new AccountUser();
            return View(user);
        }
        [HttpPost]
        public IActionResult Create(AccountUser user)
        {
            return RedirectToAction("CreateSuccess", "AccountUser",user);
        }

        public IActionResult CreateSuccess(AccountUser user)
        {
            return View(user);
        }
        [HttpPost]
        public ActionResult Login(AccountUser user)
        {
            if (user.isManager())
            {
                return RedirectToAction("Index", "Manager", new { user = user });
            }
            else//user is customer
            {
                return RedirectToAction("Me", "Customer", new { user = user });
            }
        }
    }
}