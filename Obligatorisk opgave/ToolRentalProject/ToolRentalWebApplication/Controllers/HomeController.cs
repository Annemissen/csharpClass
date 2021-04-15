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

                    return RedirectToAction("Details", "Customers");// Redirect to customer details
                }
                ViewBag.Message = "Incorrect password";
                return View();
            }
        }
        
        /*public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            //var data = loginData.Split();
            //string email = data[0];
            //string password = data[1];

            if (email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customer customer = db.CustomerSet.ToList().Find(c => c.CustomerId == email);
            //Customer customer = db.CustomerSet.Find(email);
            if (customer == null)
            {
                return RedirectToAction("Create", "Customers"); // Redirect to create customer
            }
            else
            {
                if (customer.Password == password)
                {
                    return RedirectToAction("Details/" + email, "Customers");// Redirect to customer details
                }
                ViewBag.Message = "Incorrect password";
                return View();
            }
        }*/

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

        //public ActionResult Login()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}