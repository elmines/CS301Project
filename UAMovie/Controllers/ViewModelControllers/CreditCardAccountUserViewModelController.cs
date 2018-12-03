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
    public class CreditCardAccountUserViewModelController : Controller
    {
        public ActionResult PaymentInfo(String username)
        {
            CreditCardAccountUserViewModel creditCardAccountUserViewModel =
                new CreditCardAccountUserViewModel();
            creditCardAccountUserViewModel.user = new AccountUser { Username = username };
            creditCardAccountUserViewModel.loadSavedCards();
            return View("~/Views/MyAccount/PaymentInfo.cshtml", creditCardAccountUserViewModel);
        }

        public ActionResult RemovePaymentInfo(String cardNumber, String username)
        {
            CreditCard selectedCard = CreditCard.Get(cardNumber, username);
            selectedCard.dePrefer();
            CreditCardAccountUserViewModel creditCardAccountUserViewModel = new CreditCardAccountUserViewModel();
            creditCardAccountUserViewModel.user = new AccountUser { Username = username };
            creditCardAccountUserViewModel.loadSavedCards();
            return View("~/Views/MyAccount/PaymentInfo.cshtml", creditCardAccountUserViewModel);
        }
 
    }
}