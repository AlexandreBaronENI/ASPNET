using BO;
using Dojo.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Dojo.Controllers
{
    public class ArtsMartiauxController : Controller
    {
        private DojoContext db = new DojoContext();

        // GET: ArtMartials
        public ActionResult Index()
        {
            return View(db.ArtsMartiaux.ToList());
        }

        // GET: ArtMartials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtMartial artMartial = db.ArtsMartiaux.Find(id);
            if (artMartial == null)
            {
                return HttpNotFound();
            }
            return View(artMartial);
        }

        // GET: ArtMartials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtMartials/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom")] ArtMartial artMartial)
        {
            if (ModelState.IsValid)
            {
                db.ArtsMartiaux.Add(artMartial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artMartial);
        }

        // GET: ArtMartials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtMartial artMartial = db.ArtsMartiaux.Find(id);
            if (artMartial == null)
            {
                return HttpNotFound();
            }
            return View(artMartial);
        }

        // POST: ArtMartials/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom")] ArtMartial artMartial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artMartial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artMartial);
        }

        // GET: ArtMartials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtMartial artMartial = db.ArtsMartiaux.Find(id);
            if (artMartial == null)
            {
                return HttpNotFound();
            }
            return View(artMartial);
        }

        // POST: ArtMartials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtMartial artMartial = db.ArtsMartiaux.Find(id);
            db.ArtsMartiaux.Remove(artMartial);
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
