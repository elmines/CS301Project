using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UAMovie.Models;
using UAMovie.Models.ViewModels;
using Oracle.ManagedDataAccess.Client;
namespace UAMovie.Controllers.ViewModelControllers
{
    public class SystemInfoAccountUserController : Controller
    {
        private String managerPassword;
        // GET: SystemInfoAccountUser
        public ActionResult Index()
        {
            return View();
        }

        // GET: SystemInfoAccountUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SystemInfoAccountUser/Create
        public ActionResult Create()
        {
            SystemInfoAccountUser user = new SystemInfoAccountUser();
            user.user = new AccountUser();
            user.info = new SystemInfo();
            return View("~/Views/AccountUser/Create.cshtml",user);
        }

        // POST: SystemInfoAccountUser/Create
        [HttpPost]
        public ActionResult Create(SystemInfoAccountUser systemInfoAccountUser)
        {
            Database db = new Database();
            String managerPassword = "";
            OracleCommand cmd = new OracleCommand();
            String getManagerPassword = "select ManagerPassword from SystemInfo";

            cmd.CommandText = getManagerPassword;
            cmd.Connection = db.conn;
            cmd.CommandType = System.Data.CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                managerPassword = reader.GetString(0);
                reader.Dispose();
            }
            String inputPassword = systemInfoAccountUser.info.ManagerPassword;
            if (inputPassword.Length > 0)
            {
                if (inputPassword.Equals(managerPassword))
                {
                    systemInfoAccountUser.user.insert();
                    Manager manager = new Manager();
                    manager.user = systemInfoAccountUser.user;
                    manager.Username = systemInfoAccountUser.user.Username;
                    manager.insert();
                }
                else
                {
                    //TODO: send error for invalid manager password
                }
            }
            else
            {
                systemInfoAccountUser.user.insert();
                Customer customer = new Customer();
                customer.Username = systemInfoAccountUser.user.Username;
                customer.insert();
            }
                    

            return RedirectToAction("Index", "Home");
        }

        // GET: SystemInfoAccountUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SystemInfoAccountUser/Edit/5
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

        // GET: SystemInfoAccountUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SystemInfoAccountUser/Delete/5
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