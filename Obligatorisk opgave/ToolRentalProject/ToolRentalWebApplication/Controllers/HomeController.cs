using System;
using System.Collections.Generic;
using System.Linq;
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
        /*
        [HttpPost]
        public ActionResult Index(string email)
        {
            Customer customer = db.CustomerSet.ToList().Find(c => c.CustomerId == email);
            if (customer == null)
            {
                //return RedirectToAction("Create", "Customer"); // Redirect to create customer
            }
            else
            {
                // return RedirectToAction("Details", "Customer")// Redirect to customer details
            }
        }
        */
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

        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}