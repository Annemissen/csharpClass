using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToolRentalClassLibrary;

namespace ToolRentalWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private ToolRentalDbContext db = new ToolRentalDbContext();

        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            if (email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customer customer = db.CustomerSet.Find(email);
            if (customer == null)
            {
                return RedirectToAction("Create", "Customers"); // Redirect to create customer
            }
            else
            {
                if (customer.Password == password)
                {
                    Session["email"] = customer.CustomerId;
                    Session["name"] = customer.Name;
                    Session["address"] = customer.Address;

                    string name = customer.Name;
                    return RedirectToAction("Details/" + name , "Customers");// Redirect to customer details
                }
                ViewBag.Message = "Incorrect password";
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}