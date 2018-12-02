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

        public ActionResult LoginForm()
        {
            return View("~/Views/Home/Index.cshtml");
        }
        
        public ActionResult Login(String username)
        {
            AccountUser user = new AccountUser();
            user.Username = username;
            if (user.isManager())
            {
                return RedirectToAction("Index", "Manager", new { username = user.Username });
            }
            else//user is customer
            {
                return RedirectToAction("NowPlaying", "Customer", new { username = user.Username });
            }
        }
    }
}