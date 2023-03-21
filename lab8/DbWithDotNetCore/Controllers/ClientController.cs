using DbWithDotNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DbWithDotNetCore.Controllers
{
    public class ClientController : Controller
    {
        IdentityDBContext Context { get; }
        public ClientController(IdentityDBContext context)
        {
            Context = context;
        }

        // GET: ClientController
        public ActionResult Index()
        {
            return View(Context.Clients.ToList());
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View(Context.Clients.FirstOrDefault(c=>c.Id == id));
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Context.Clients.Add(client);
                    Context.SaveChanges();
                }    
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            var clnt = Context.Clients.FirstOrDefault(c => c.Id == id);
            if (clnt == null)
                return View();
            return View(clnt);
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Client client)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Client clnt =  Context.Clients.FirstOrDefault(c=>c.Id == id);
                    clnt.ClientName = client.ClientName;
                    clnt.Password = client.Password;
                    clnt.Address = client.Address;
                    clnt.Mobile = client.Mobile;
                    clnt.Email = client.Email;
                    Context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Context.Clients.FirstOrDefault(c => c.Id == id));
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Context.Clients.Remove(Context.Clients.FirstOrDefault(c => c.Id == id));
                    Context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
