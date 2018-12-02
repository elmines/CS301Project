using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UAMovie.Models;
using UAMovie.Models.ViewModels;
namespace UAMovie.Controllers.ViewModelControllers
{
    public class TheaterViewModelController : Controller
    {
        public ActionResult SearchForTheaters(String userName, String movieName,String errorText)//The asterisk in String* allows errorText to be null
        {
            TheaterViewModel theaterViewModel = new TheaterViewModel();
            theaterViewModel.customer = new Customer();
            theaterViewModel.customer.username = userName;
            theaterViewModel.GetPreferredTheaters();
            return View("~/Views/Theater/SearchForTheaters.cshtml",theaterViewModel);
        }
        [HttpPost]
        public ActionResult DisplaySearchedTheaters(String searchName, String userName)
        {
            TheaterViewModel theaterViewModel = new TheaterViewModel();
            theaterViewModel.customer = new Customer();
            theaterViewModel.customer.username = userName;
            

            theaterViewModel.foundTheaters = Theater.SearchTheaters(searchName);
            if (theaterViewModel.foundTheaters.Count == 0)//no theaters found
            {
                return RedirectToAction("SearchForTheaters", "Theater", new { errorText = "No results found." });
            }
            return View("~/Views/Theater/DisplaySearchedTheaters.cshtml", theaterViewModel);
        }
        public ActionResult GetPreferredTheaters(String username)
        {
            TheaterViewModel theaterViewModel = new TheaterViewModel();
            theaterViewModel.customer = new Customer(username);
            theaterViewModel.GetPreferredTheaters();
            return null;// View("")
        }
        // GET: TheaterViewModel
        public ActionResult Index()
        {
            return View();
        }

        // GET: TheaterViewModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TheaterViewModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TheaterViewModel/Create
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

        // GET: TheaterViewModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TheaterViewModel/Edit/5
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

        // GET: TheaterViewModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TheaterViewModel/Delete/5
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