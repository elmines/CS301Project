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
    public class TicketOrderAccountUserViewModelController : Controller
    {
        public ActionResult OrderHistory(String username)
        {

            TicketOrderAccountUserViewModel ticketOrderAccountUserViewModel =
                new TicketOrderAccountUserViewModel();
            ticketOrderAccountUserViewModel.username = username;
            ticketOrderAccountUserViewModel.loadOrders();
            return View("~/Views/MyAccount/OrderHistory.cshtml", ticketOrderAccountUserViewModel);
        }

        public ActionResult OrderDetails(String username, String orderID)
        {
            TicketOrderAccountUserViewModel ticketOrderAccountUserViewModel =
                new TicketOrderAccountUserViewModel();
            ticketOrderAccountUserViewModel.username = username;
            ticketOrderAccountUserViewModel.order = TicketOrder.Get(orderID);
            ticketOrderAccountUserViewModel.showing = Showing.GetShowing(ticketOrderAccountUserViewModel.order.ShowingID);
            ticketOrderAccountUserViewModel.theater = Theater.GetTheater(ticketOrderAccountUserViewModel.showing.TheaterID);
            ticketOrderAccountUserViewModel.movie = Movie.Get(ticketOrderAccountUserViewModel.showing.MovieName);
            return View("~/Views/MyAccount/OrderDetails.cshtml",ticketOrderAccountUserViewModel);
        }
        public ActionResult Cancel(String orderID, String userName)
        {
            TicketOrder.Cancel(orderID);
            return RedirectToAction("OrderHistory", new {username = userName });
        }
    }
}