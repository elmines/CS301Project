using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UAMovie.Models;
namespace UAMovie.Controllers
{
    public class TheaterController : Controller
    {
        //[HttpPost]
        //public ActionResult DisplaySearchedTheaters(String name, String city, String state, String userName)
        //{
        //    List<Theater> theaters = Theater.SearchTheaters(name, city, state);
        //    if (theaters.Count == 0)//no theaters found
        //    {
        //        return RedirectToAction("SearchForTheaters","Theater",new { errorText = "No results found." });
        //    }
        //    return View("~/Views/Theater/DisplaySearchedTheaters.cshtml",theaters);
        //}
        
       
        // GET: Theater
        public ActionResult Index()
        {
            return View();
        }

        // GET: Theater/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Theater/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Theater/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Theater/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Theater/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Theater/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Theater/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}