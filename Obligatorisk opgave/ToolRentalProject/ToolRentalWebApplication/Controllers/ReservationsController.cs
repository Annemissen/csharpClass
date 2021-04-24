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
    public class ReservationsController : Controller
    {
        private ToolRentalDbContext db = new ToolRentalDbContext();

        // GET: Reservations
        public ActionResult Index()
        {
            var reservationSet = db.ReservationSet.Include(r => r.Customer).Include(r => r.Tool);
            return View(reservationSet.ToList());
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.ReservationSet.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        //public ActionResult CreateReservationView(string email)
        //{
        //    Customer customer = db.CustomerSet.ToList().Find(c => c.CustomerId == email);
        //    ViewData["customer"] = customer;

        //    List<Tool> tools = db.ToolSet.ToList();
        //    ViewData["tools"] = db.ToolSet.ToList();

        //    return View(new { customer = customer, tools = tools, });
        //}

        // GET: Reservations/Create
        public ActionResult Create(int toolId, string startDate, string endDate)
        {
            Customer customer = db.CustomerSet.ToList().Find(c => c.CustomerId == Session["email"].ToString());
            Tool tool = db.ToolSet.ToList().Find(t => t.Id == toolId);


            DateTime start = stringToDateTime(startDate);
            DateTime end = stringToDateTime(endDate);
            Reservation res = new Reservation(tool, customer, start, end);
            db.ReservationSet.Add(res);
            db.SaveChanges();

            return View(res);

        }

        // GET: Reservations/Create
        public ActionResult CreateReservation(int toolId, string startDate, string endDate)
        {
            Customer customer = db.CustomerSet.ToList().Find(c => c.CustomerId == Session["email"].ToString());
            Tool tool = db.ToolSet.ToList().Find(t => t.Id == toolId);


            DateTime start = stringToDateTime(startDate);
            DateTime end = stringToDateTime(endDate);
            Reservation res = new Reservation(tool, customer, start, end);
            db.ReservationSet.Add(res);
            db.SaveChanges();
            //context.ReservationSet.Add(new Reservation(havetromle1, andersHansen, new DateTime(2021, 4, 2), new DateTime(2021, 4, 4)));

            return RedirectToAction("Details/" + Session["email"], "Customers");

        }

        private DateTime stringToDateTime(string date)
        {
            //string[] args = date.Split('-');
            System.Diagnostics.Debug.WriteLine("TEST TEST TEST: " + date);
            DateTime dateObj = DateTime.Parse(date);
            return dateObj;
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationId,ToolRefId,CustomerRefId,ReservationStatus,Start,End")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.ReservationSet.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerRefId = new SelectList(db.CustomerSet, "CustomerId", "Password", reservation.CustomerRefId);
            ViewBag.ToolRefId = new SelectList(db.ToolSet, "Id", "Id", reservation.ToolRefId);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.ReservationSet.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerRefId = new SelectList(db.CustomerSet, "CustomerId", "Password", reservation.CustomerRefId);
            ViewBag.ToolRefId = new SelectList(db.ToolSet, "Id", "Id", reservation.ToolRefId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationId,ToolRefId,CustomerRefId,ReservationStatus,Start,End")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerRefId = new SelectList(db.CustomerSet, "CustomerId", "Password", reservation.CustomerRefId);
            ViewBag.ToolRefId = new SelectList(db.ToolSet, "Id", "Id", reservation.ToolRefId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.ReservationSet.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.ReservationSet.Find(id);
            db.ReservationSet.Remove(reservation);
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
