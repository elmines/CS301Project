using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using UAMovie.Models;
using UAMovie.Models.ViewModels;
using Oracle.ManagedDataAccess.Client;

namespace UAMovie.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Create(MovieAccountUserViewModel movieAccountUserViewModel)
        {
            movieAccountUserViewModel.newReview.Username = movieAccountUserViewModel.user.Username;
            movieAccountUserViewModel.newReview.MovieName = movieAccountUserViewModel.movie.Name;
            try
            {
                movieAccountUserViewModel.newReview.insert();
                return RedirectToAction("NowPlaying","Customer",new { username = movieAccountUserViewModel.user.Username });
            }
            catch(Exception ex)
            {
                //error message???
                throw ex;
                return View("~/Views/Movie/WriteReview.cshtml",movieAccountUserViewModel);
            }
        }

        //<numRevies, avgRating>
        public static Tuple<Int32, float> getAverageRating(String movieName)
        {

            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            String readQuery = "SELECT AVG(r.Rating), COUNT(r.RATING) FROM Review r" +
                               "  WHERE r.MovieName=\'" + movieName + "\'";

            cmd.CommandText = readQuery;
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();

            int reviewCount = reader.GetInt32(1);
            float average = (reviewCount > 0) ? reader.GetFloat(0) : -1;

            db.Dispose();
            cmd.Dispose();
            return new Tuple<Int32, float>(reviewCount, average);
        }

        public static Boolean hasWatched(AccountUser user, String movieName)
        {
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            String readQuery = "SELECT FROM TicketOrder o" +
                               " INNER JOIN Customer    c ON o.Username=c.Username" +
                               " INNER JOIN Showing     s ON o.ShowingID=s.ID" +
                               " INNER JOIN Movie       m ON o.MovieName=m.Name" +
                               " WHERE                       o.Status<>\'Cancelled\'" +
                               "   AND                       c.Username=\'"+user.Username + "\'";
            cmd.CommandText = readQuery;
            Boolean hasRows = cmd.ExecuteReader().HasRows;
            cmd.Dispose();
            db.Dispose();
            return hasRows;
        }
    }
}