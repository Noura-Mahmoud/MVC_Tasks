using LoginsAndIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace LoginsAndIdentity.Controllers
{
    [AllowAnonymous]
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Client client)
        {
            if (ModelState.IsValid)
            {
                LoginContext Context = new LoginContext();
                Context.Clients.Add(client);
                Context.SaveChanges();

                var userIdentity = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, client.ClientName),
                    new Claim(ClaimTypes.Email, client.Email),
                    new Claim("Password", client.Password)
                }, "AppCookie");

                Request.GetOwinContext().Authentication.SignIn(userIdentity);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Client client)
        {
            LoginContext Context = new LoginContext();
            var loggedUser = Context.Clients.FirstOrDefault(c=>c.Email == client.Email && c.Password == client.Password);

            if (loggedUser != null)
            {
                var signinIdentity = new ClaimsIdentity(new List<Claim>()
                    {
                        new Claim(ClaimTypes.Email, client.Email),
                        new Claim("Password", client.Password)
                    }, "AppCookie");

                Request.GetOwinContext().Authentication.SignIn(signinIdentity);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Name", "User doesn't exist");
            }

            return View();
        }
        public ActionResult Logout(Client client)
        {
            Request.GetOwinContext().Authentication.SignOut("AppCookie");

            return RedirectToAction("Login");
        }
    }
}