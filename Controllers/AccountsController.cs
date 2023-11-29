using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using part3.Models;

namespace part3.Controllers
{
    public class AccountsController : Controller
    {
        WEBREGEntities1 entity = new WEBREGEntities1();

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel credentials)
        {
            // Retrieve the user based on the username
            REGISTRATION user = entity.REGISTRATIONs.FirstOrDefault(x => x.UserName == credentials.Username);

            // Check if the user exists and the password is correct
            if (user != null && VerifyPassword(credentials.Password, user.UserPassword))
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Username or Password is incorrect");
            return View();
        }

        [HttpPost]
        public ActionResult Signup(REGISTRATION userinfo)
        {
            // Hash the user's password before storing it in the database
            userinfo.UserPassword = HashPassword(userinfo.UserPassword);

            entity.REGISTRATIONs.Add(userinfo);
            entity.SaveChanges();
            return RedirectToAction("Login");
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        #region Password Hashing Methods

        private string HashPassword(string password)
        {
            // Implement your password hashing logic here (e.g., using bcrypt or another secure hashing algorithm)
            // For simplicity, let's use a basic example using SHA-256
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            // Implement your password verification logic here
            // For simplicity, let's use a basic example using SHA-256
            string enteredPasswordHash = HashPassword(enteredPassword);
            return string.Equals(enteredPasswordHash, hashedPassword);
        }

        #endregion
    }
}
