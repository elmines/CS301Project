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
        public ActionResult SelectShowing(String theaterID,String userName,String movieName)
        {
            TicketOrderViewModel ticketOrderViewModel = new TicketOrderViewModel();
            ticketOrderViewModel.userName = userName;
            ticketOrderViewModel.showings = Showing.GetFutureShowings(movieName, theaterID);
            ticketOrderViewModel.theater = Theater.GetTheater(theaterID);
            ticketOrderViewModel.movieName = movieName;
            ticketOrderViewModel.theaterID = theaterID;
            return View("~/Views/TicketOrder/SelectShowing.cshtml", ticketOrderViewModel);
        }
        public ActionResult EnterTickets(String theaterID, String userName, String movieName, String showingID)
        {
            TicketOrderViewModel ticketOrderViewModel = new TicketOrderViewModel();
            ticketOrderViewModel.userName = userName;
            ticketOrderViewModel.theaterID = theaterID;
            ticketOrderViewModel.systemInfo.GetDiscounts();
            ticketOrderViewModel.movieName = movieName;
            ticketOrderViewModel.showingID = showingID;
            
            return View("~/Views/TicketOrder/EnterTickets.cshtml", ticketOrderViewModel);
        }
        public ActionResult EnterCardNumber(TicketOrderViewModel ticketOrderViewModel)
        {
            //TicketOrderViewModel ticketOrderViewModel = new TicketOrderViewModel();
            //ticketOrderViewModel.userName = userName;
            //ticketOrderViewModel.theaterID = theaterID;
            //ticketOrderViewModel.systemInfo.GetDiscounts();
            //ticketOrderViewModel.movieName = movieName;
            //ticketOrderViewModel.ticketOrder.AdultTickets = adultTickets;
            //ticketOrderViewModel.ticketOrder.ChildTickets = childTickets;
            //ticketOrderViewModel.ticketOrder.SeniorTickets = seniorTickets;

            CreditCardAccountUserViewModel creditCardAccountUserViewModel = new CreditCardAccountUserViewModel();
            creditCardAccountUserViewModel.user = new AccountUser();
            creditCardAccountUserViewModel.user.Username = ticketOrderViewModel.userName;
            creditCardAccountUserViewModel.loadSavedCards();

            ticketOrderViewModel.creditCards = creditCardAccountUserViewModel.savedCards;
            return View("~/Views/TicketOrder/EnterCardNumber.cshtml", ticketOrderViewModel);
        }
        public ActionResult Buy(String creditCard, int adultTickets, int childTickets, int seniorTickets, String userName, String theaterID, String movieName, String showingID)
        {
            TicketOrderViewModel ticketOrderViewModel = new TicketOrderViewModel();
            ticketOrderViewModel.ticketOrder.CardNumber = creditCard;
            ticketOrderViewModel.ticketOrder.AdultTickets = adultTickets;
            ticketOrderViewModel.ticketOrder.ChildTickets = childTickets;
            ticketOrderViewModel.ticketOrder.SeniorTickets = seniorTickets;
            ticketOrderViewModel.ticketOrder.Username = userName;
            ticketOrderViewModel.ticketOrder.ShowingID = showingID;
            //ticketOrderViewModel.ticketOrder.Cost = 999.999;
            ticketOrderViewModel.ticketOrder.insert();
            return View("~/Views/TicketOrder/OrderSuccess.cshtml",ticketOrderViewModel);
        }
        public ActionResult Buy(TicketOrderViewModel ticketOrderViewModel)
        {
            ticketOrderViewModel.creditCard.insert();
            ticketOrderViewModel.ticketOrder.insert();
            return View("~/Views/TicketOrder/OrderSuccess.cshtml", ticketOrderViewModel);
        }
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