using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEnggBackendApp.Models.RequestModels;

namespace WebEnggBackendApp.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            if(IsUserAuthenticated())
            {
                return RedirectToAction("Index", "Orders");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Authenticate(AuthenticateRequestModel model)
        {
            if (IsUserAuthenticated())
            {
                return RedirectToAction("Index", "Orders");
            }

            //if (model.username == null || model.password == null)
            //{
            //    TempData["errorMessage"] = "Username or password cannot be empty.";
            //    return RedirectToAction("Login", "User");
            //}

            if(!AuthenticateUser(model.username, model.password))
            {
                TempData["errorMessage"] = "Username or password is not correct.";
                return RedirectToAction("Login", "User");
            }

            Session["shu"] = "true";
            return RedirectToAction("Index", "Orders");
        }

        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult Profile()
        {
            // User must be logged in

            return View();
        }

        public ActionResult Logout()
        {
            if(Session != null && Session["shu"] != null)
            {
                Session.Clear();
                Session.Abandon();
            }

            return RedirectToAction("Login", "User");
        }

        private bool AuthenticateUser(string username, string password)
        {
            string connectionString = "Server=.;Database=WebEnggBackendApp;Trusted_Connection=True;";

            // 1. Create connection with DB
            SqlConnection connection = new SqlConnection(connectionString);

            // 2. Open DB connection
            connection.Open();

            // 3. Set up SQL command
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from [users] where [username] = @username and [password] = @password";
            command.Parameters.Add("@username", username);
            command.Parameters.Add("@password", password);


            // 4. Execute SQL query
            SqlDataReader reader = command.ExecuteReader();

            bool isUserAuthenticated = false;

            if (reader.HasRows)
                isUserAuthenticated = true;

            // 5. Close DB connection
            connection.Close();

            return isUserAuthenticated;
        }

        private bool IsUserAuthenticated()
        {
            return Session != null && Session["shu"] != null;
        }
    }
}