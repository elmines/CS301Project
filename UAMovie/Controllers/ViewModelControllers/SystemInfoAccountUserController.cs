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
        // GET: SystemInfoAccountUser
        public ActionResult Index()
        {
            return View();
        }

        // GET: SystemInfoAccountUser/Create
        public ActionResult CreatePage()
        {
            ViewBag.errorMessage = null;
            SystemInfoAccountUser user = new SystemInfoAccountUser();
            user.user = new AccountUser();
            user.info = new SystemInfo();
            return View("~/Views/AccountUser/Create.cshtml",user);
        }

        public ActionResult Create(String errorMessage)
        {
            ViewBag.errorMessage = errorMessage;
            SystemInfoAccountUser user = new SystemInfoAccountUser();
            user.user = new AccountUser();
            user.info = new SystemInfo();
            return View("~/Views/AccountUser/Create.cshtml", user);
        }

        // POST: SystemInfoAccountUser/Create
        [HttpPost]
        public ActionResult Create(SystemInfoAccountUser systemInfoAccountUser)
        {
            ViewBag.errorMessage = null;

            if (String.IsNullOrEmpty(systemInfoAccountUser.user.Username))
            {
                String errorMessage = "Please specify a Username";
                return RedirectToAction("Create", "SystemInfoAccountUser",
                    new { errorMessage = errorMessage });
            }
            if (String.IsNullOrEmpty(systemInfoAccountUser.user.EmailAddress))
            {
                String errorMessage = "Please specify an Email Address";
                return RedirectToAction("Create", "SystemInfoAccountUser",
                    new { errorMessage = errorMessage });
            }
            if (String.IsNullOrEmpty(systemInfoAccountUser.user.Password))
            {
                String errorMessage = "Please specify a Password";
                return RedirectToAction("Create", "SystemInfoAccountUser",
                    new { errorMessage = errorMessage });
            }

            Database db = new Database();

            //CHECKING FOR IDENTICAL EMAILS
            OracleCommand emailCmd = new OracleCommand();
            emailCmd.Connection = db.conn;
            emailCmd.CommandText = String.Format("SELECT * FROM AccountUser WHERE" +
                " EmailAddress='{0}'", systemInfoAccountUser.user.EmailAddress);
            if (emailCmd.ExecuteReader().HasRows)
            {
                String errorMessage = String.Format("Email address {0} is already used.",
                                                       systemInfoAccountUser.user.EmailAddress);
                emailCmd.Dispose();
                db.Dispose();
                return RedirectToAction("Create", "SystemInfoAccountUser",
                    new { errorMessage = errorMessage });
            }
            emailCmd.Dispose();

            //CHECKING FOR IDENTICAL USERNAMES
            OracleCommand nameCmd = new OracleCommand();
            nameCmd.Connection = db.conn;
            nameCmd.CommandText = String.Format("SELECT * FROM AccountUser WHERE" +
                " Username='{0}'", systemInfoAccountUser.user.Username);
            if (nameCmd.ExecuteReader().HasRows)
            {
                String errorMessage = String.Format("Username {0} is already used.",
                                       systemInfoAccountUser.user.Username);
                nameCmd.Dispose();
                db.Dispose();
                return RedirectToAction("Create", "SystemInfoAccountUser",
                    new { errorMessage = errorMessage });
            }

            //CREATING A MANAGER
            String managerPassword = "";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select ManagerPassword from SystemInfo";
            cmd.Connection = db.conn;
            cmd.CommandType = System.Data.CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            managerPassword = reader.GetString(0);
            reader.Dispose();
            String inputPassword = systemInfoAccountUser.info.ManagerPassword;
            if (!String.IsNullOrEmpty(inputPassword))
            {
                if (inputPassword.Equals(managerPassword))
                {
                    systemInfoAccountUser.user.insert();
                    Manager manager = new Manager();
                    manager.user = systemInfoAccountUser.user;
                    manager.Username = systemInfoAccountUser.user.Username;
                    manager.insert();
                    cmd.Dispose();
                    db.Dispose();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    String errorMessage = "Incorrect manager password";
                    cmd.Dispose();
                    db.Dispose();
                    return RedirectToAction("Create", "SystemInfoAccountUser",
                        new { errorMessage = errorMessage });
                }
            }
            cmd.Dispose();
            db.Dispose();


            systemInfoAccountUser.user.insert();
            Customer customer = new Customer();
            customer.username = systemInfoAccountUser.user.Username;
            customer.insert();
                    

            return RedirectToAction("Index", "Home");
        }
    }
}