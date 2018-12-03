using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

            return View();
        }
    }
}