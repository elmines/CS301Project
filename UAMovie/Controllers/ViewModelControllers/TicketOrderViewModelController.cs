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
    public class TicketOrderViewModelController : Controller
    {
        
        
        
        // GET: TicketOrderViewModel
        public ActionResult Index()
        {
            return View();
        }

        // GET: TicketOrderViewModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TicketOrderViewModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TicketOrderViewModel/Create
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

        // GET: TicketOrderViewModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TicketOrderViewModel/Edit/5
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

        // GET: TicketOrderViewModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TicketOrderViewModel/Delete/5
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