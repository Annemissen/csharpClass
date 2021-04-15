using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToolRentalClassLibrary;

namespace ToolRentalWebApplication.Controllers
{
    public class CustomersController : Controller
    {
        private ToolRentalDbContext db = new ToolRentalDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.CustomerSet.ToList());
        }

        public ActionResult Details()
        {

            Customer customer = new Customer()
            {
                CustomerId = (string)HttpContext.Session["email"],
                Name = (string)HttpContext.Session["name"],
                Address = (string)HttpContext.Session["address"],
            };

            //IEnumerable<SelectListItem> selectlist = new ObservableCollection<SelectListItem>();
            //foreach (Tool tool in db.ToolSet)
            //{

            //    SelectListItem item = new SelectListItem();
            //    item.Value = tool.Id.ToString();
            //    item.Text = tool.ToolType.Name + "(" + tool.Id + ")";
            //    selectlist.Append(item);
            //}
            //ViewBag.tools = selectlist;

            return View(customer);
        }


        public ActionResult SelectTool()
        {
            return RedirectToAction("Index", "Tools");
        }


        /*
        // GET: Customers/Details/email
        public ActionResult Details(string email)
        {
            if (email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Console.WriteLine("EMAIL: " + email);
            Console.WriteLine();
            Customer customer = db.CustomerSet.Find(email);
            Console.WriteLine("TEST: " + customer.ToString());
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        */

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,Password,Name,Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.CustomerSet.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.CustomerSet.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,Password,Name,Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.CustomerSet.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Customer customer = db.CustomerSet.Find(id);
            db.CustomerSet.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
