using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using UAMovie.Models;

namespace UAMovie.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index(AccountUser user)
        {
            return View(user);
        }

        public IActionResult MovieReport()
        {
            List < OrderStats > stats = GetOrderStats();
            return View("~/Views/Manager/MovieReport.cshtml", stats);
        }

        public IActionResult RevenueReport()
        {
            List<RevStats> stats = GetRevenueStats();
            return View("~/Views/Manager/RevenueReport.cshtml", stats);
        }

        public static List<RevStats> GetRevenueStats()
        {
            List<RevStats> stats = new List<RevStats>();

            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            cmd.CommandText = "SELECT " +
                " EXTRACT(month from StartTime) AS ShowingMonth, AdultTickets, ChildTickets, SeniorTickets, MovieName" +
                " FROM TicketOrder o INNER JOIN Showing s ON o.ShowingID=s.ID" +
                "                    INNER JOIN Movie m   ON s.MovieName=m.Name";

            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                stats.Add(new RevStats
                {
                    monthCode = reader.GetInt32(0),
                    adultTickets = reader.GetInt32(1),
                    childTickets = reader.GetInt32(2),
                    seniorTickets = reader.GetInt32(3),
                    movieName = reader.GetString(4)
                });
            }
            reader.Dispose();
            cmd.Dispose();
            db.Dispose();

            return stats;
        }


        public static List<OrderStats> GetOrderStats()
        {
            List<OrderStats> stats = new List<OrderStats>();

            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            cmd.CommandText = "SELECT EXTRACT(month from StartTime) AS ShowingMonth, s.MovieName, COUNT(*) AS OrderCount" +
                " FROM TicketOrder o INNER JOIN Showing s ON o.ShowingID = s.ID" +
                " GROUP BY EXTRACT(month from StartTime), s.MovieName" +
                " ORDER BY ShowingMonth";

            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                stats.Add(new OrderStats
                {
                    monthCode = reader.GetInt32(0),
                    MovieName = reader.GetString(1),
                    OrderCount = reader.GetInt32(2)
                });
            }
            reader.Dispose();
            cmd.Dispose();
            db.Dispose();
            return stats;
        }
    }
}