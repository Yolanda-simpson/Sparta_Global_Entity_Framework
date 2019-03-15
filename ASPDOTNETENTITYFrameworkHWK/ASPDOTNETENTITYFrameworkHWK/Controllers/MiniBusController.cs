using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPDOTNETENTITYFrameworkHWK;

namespace ASPDOTNETENTITYFrameworkHWK.Controllers
{
    public class MiniBusController : Controller
    {
        private CarsEntities10 db = new CarsEntities10();

        // GET: MiniBus
        public ActionResult Index()
        {
            return View(db.MiniBus.ToList());
        }

        // GET: MiniBus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiniBu miniBu = db.MiniBus.Find(id);
            if (miniBu == null)
            {
                return HttpNotFound();
            }
            return View(miniBu);
        }

        // GET: MiniBus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MiniBus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MiniBusMake,Colour,NumberOfSeats,EngineSize")] MiniBu miniBu)
        {
            if (ModelState.IsValid)
            {
                db.MiniBus.Add(miniBu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(miniBu);
        }

        // GET: MiniBus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiniBu miniBu = db.MiniBus.Find(id);
            if (miniBu == null)
            {
                return HttpNotFound();
            }
            return View(miniBu);
        }

        // POST: MiniBus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MiniBusMake,Colour,NumberOfSeats,EngineSize")] MiniBu miniBu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miniBu).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(miniBu);
        }

        // GET: MiniBus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiniBu miniBu = db.MiniBus.Find(id);
            if (miniBu == null)
            {
                return HttpNotFound();
            }
            return View(miniBu);
        }

        // POST: MiniBus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MiniBu miniBu = db.MiniBus.Find(id);
            db.MiniBus.Remove(miniBu);
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
