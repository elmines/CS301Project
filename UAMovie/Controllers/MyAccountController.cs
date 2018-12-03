using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UAMovie.Models.ViewModels;

using Oracle.ManagedDataAccess.Client;
using UAMovie.Models;



namespace UAMovie.Controllers
{
    public class MyAccountController : Controller
    {
        public IActionResult NowPlaying()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PaymentInfo()
        {
            return View();
        }

        public IActionResult PreferredTheater(String username)
        {
            TheaterViewModel theaters = new TheaterViewModel();
            theaters.userName = username;
            theaters.GetPreferredTheaters();
            return View("~/Views/MyAccount/PreferredTheater.cshtml", theaters);
        }

        public ActionResult RemoveTheater(String username, String theaterID)
        {
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;

            cmd.CommandText = String.Format("DELETE FROM PreferredTheater WHERE Username='{0}' AND TheaterID='{1}'",
                username, theaterID);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            db.Dispose();

            return RedirectToAction("PreferredTheater", "MyAccount", new { username = username });
        }

        public IActionResult OrderHistory()
        {
            return View();
        }
    }
}