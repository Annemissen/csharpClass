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
    public class ToolsController : Controller
    {
        private ToolRentalDbContext db = new ToolRentalDbContext();

        // GET: Tools
        public ActionResult Index()
        {
            var toolSet = db.ToolSet.Include(t => t.ToolType);
            return View(toolSet.ToList());
        }

        // GET: Tools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tool tool = db.ToolSet.Find(id);
            if (tool == null)
            {
                return HttpNotFound();
            }
            return View(tool);
        }

        // GET: Tools/Create
        public ActionResult Create()
        {
            ViewBag.ToolTypeRefId = new SelectList(db.ToolTypeSet, "Id", "Name");
            return View();
        }

        // POST: Tools/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ToolTypeRefId")] Tool tool)
        {
            if (ModelState.IsValid)
            {
                db.ToolSet.Add(tool);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ToolTypeRefId = new SelectList(db.ToolTypeSet, "Id", "Name", tool.ToolTypeRefId);
            return View(tool);
        }

        // GET: Tools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tool tool = db.ToolSet.Find(id);
            if (tool == null)
            {
                return HttpNotFound();
            }
            ViewBag.ToolTypeRefId = new SelectList(db.ToolTypeSet, "Id", "Name", tool.ToolTypeRefId);
            return View(tool);
        }

        // POST: Tools/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ToolTypeRefId")] Tool tool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ToolTypeRefId = new SelectList(db.ToolTypeSet, "Id", "Name", tool.ToolTypeRefId);
            return View(tool);
        }

        // GET: Tools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tool tool = db.ToolSet.Find(id);
            if (tool == null)
            {
                return HttpNotFound();
            }
            return View(tool);
        }

        // POST: Tools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tool tool = db.ToolSet.Find(id);
            db.ToolSet.Remove(tool);
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
