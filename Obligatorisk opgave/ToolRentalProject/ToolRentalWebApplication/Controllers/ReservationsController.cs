using System;
using System.Collections.Generic;
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

        // GET: Reservations/Create
        public ActionResult Create()
        {
            ViewBag.CustomerRefId = new SelectList(db.CustomerSet, "CustomerId", "Password");
            ViewBag.ToolRefId = new SelectList(db.ToolSet, "Id", "Id");
            return View();
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
