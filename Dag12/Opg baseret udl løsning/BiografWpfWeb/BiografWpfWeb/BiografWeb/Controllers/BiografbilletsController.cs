using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EntityFrameworkModel;

namespace BiografWeb.Controllers
{
    public class BiografbilletsController : Controller
    {
        private KunderIBioEntities db = new KunderIBioEntities();

        // GET: Biografbillets
        public ActionResult Index(string phone)
        {
            if (phone == null)
                return View(db.Biografbillet.Include(b => b.Kunde).ToList());
            else
                return View(db.Kunde.Find(phone).Biografbillet.ToList());
        }

        // GET: Biografbillets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biografbillet biografbillet = db.Biografbillet.Find(id);
            if (biografbillet == null)
            {
                return HttpNotFound();
            }
            return View(biografbillet);
        }

        // GET: Biografbillets/Create
        public ActionResult Create()
        {
            ViewBag.kundeNr = new SelectList(db.Kunde, "tlfNr", "navn");
            return View();
        }

        // POST: Biografbillets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "filmnavn,dato,tid,sæderække,stolenummer,kundeNr,id")] Biografbillet biografbillet)
        {
            if (ModelState.IsValid)
            {
                db.Biografbillet.Add(biografbillet);
                db.SaveChanges();
                return RedirectToAction("Index", new {phone = biografbillet.kundeNr});
            }

            ViewBag.kundeNr = new SelectList(db.Kunde, "tlfNr", "navn", biografbillet.kundeNr);
            return View(biografbillet);
        }

        // GET: Biografbillets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biografbillet biografbillet = db.Biografbillet.Find(id);
            if (biografbillet == null)
            {
                return HttpNotFound();
            }
            ViewBag.kundeNr = new SelectList(db.Kunde, "tlfNr", "navn", biografbillet.kundeNr);
            return View(biografbillet);
        }

        // POST: Biografbillets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "filmnavn,dato,tid,sæderække,stolenummer,kundeNr,id")] Biografbillet biografbillet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biografbillet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kundeNr = new SelectList(db.Kunde, "tlfNr", "navn", biografbillet.kundeNr);
            return View(biografbillet);
        }

        // GET: Biografbillets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biografbillet biografbillet = db.Biografbillet.Find(id);
            if (biografbillet == null)
            {
                return HttpNotFound();
            }
            return View(biografbillet);
        }

        // POST: Biografbillets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Biografbillet biografbillet = db.Biografbillet.Find(id);
            db.Biografbillet.Remove(biografbillet);
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
