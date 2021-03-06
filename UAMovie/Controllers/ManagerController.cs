﻿using System;
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
            List<TicketOrder> orders = GetRevenueStats();
            return View("~/Views/Manager/RevenueReport.cshtml", orders);
        }

        public static List<TicketOrder> GetRevenueStats()
        {
            List<TicketOrder> stats = new List<TicketOrder>();
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            cmd.CommandText = "SELECT o.AdultTickets, o.ChildTickets, o.SeniorTickets, o.Status, o.ShowingID" +
                    " FROM TicketOrder o";
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                stats.Add(new TicketOrder
                {
                    AdultTickets = reader.GetInt32(0),
                    ChildTickets = reader.GetInt32(1),
                    SeniorTickets = reader.GetInt32(2),
                    Status = reader.GetString(3),
                    ShowingID = reader.GetString(4)
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