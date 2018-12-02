using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UAMovie.Models;
namespace UAMovie.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Me(AccountUser user)
        {
            return View("~/Views/MyAccount/Index.cshtml",user);
        }
        public ActionResult NowPlaying(String username)
        {
            return RedirectToAction("GetNowPlaying", "MovieAccountUserViewModel",new { username = username });
        }
        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        
    }
}