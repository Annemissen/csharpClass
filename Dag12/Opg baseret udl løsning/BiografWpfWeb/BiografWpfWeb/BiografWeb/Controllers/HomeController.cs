using EntityFrameworkModel;
using System.Web.Mvc;

namespace BiografWeb.Controllers
{
    public class HomeController : Controller
    {
        private KunderIBioEntities db = new KunderIBioEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string phone)
        {
            Kunde kunde = db.Kunde.Find(phone);
            if (kunde==null)
            {
                kunde = new Kunde
                {
                    tlfNr = phone,
                    navn = ""
                };
                db.Kunde.Add(kunde);
                try
                {
                db.SaveChanges();

                }
                catch
                {
                    System.Console.WriteLine(db.GetValidationErrors());
                }
            }
            return RedirectToAction("Edit/" + phone, "Kundes");
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