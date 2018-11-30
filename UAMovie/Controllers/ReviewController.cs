using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using UAMovie.Models;
using Oracle.ManagedDataAccess.Client;

namespace UAMovie.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public static Boolean hasWatched(AccountUser user, String movieName)
        {
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();

            //FIXME: Need to check if the movie showing as happened yet
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