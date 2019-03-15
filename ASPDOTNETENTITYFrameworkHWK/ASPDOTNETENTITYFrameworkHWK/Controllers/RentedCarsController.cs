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
    public class RentedCarsController : Controller
    {
        private CarsEntities10 db = new CarsEntities10();

        // GET: RentedCars
        public ActionResult Index()
        {
            return View(db.RentedCars.ToList());
        }

        // GET: RentedCars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentedCar rentedCar = db.RentedCars.Find(id);
            if (rentedCar == null)
            {
                return HttpNotFound();
            }
            return View(rentedCar);
        }

        // GET: RentedCars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentedCars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RentedCarName,HireDate,Duration,RentedBy")] RentedCar rentedCar)
        {
            if (ModelState.IsValid)
            {
                db.RentedCars.Add(rentedCar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentedCar);
        }

        // GET: RentedCars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentedCar rentedCar = db.RentedCars.Find(id);
            if (rentedCar == null)
            {
                return HttpNotFound();
            }
            return View(rentedCar);
        }

        // POST: RentedCars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RentedCarName,HireDate,Duration,RentedBy")] RentedCar rentedCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentedCar).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentedCar);
        }

        // GET: RentedCars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentedCar rentedCar = db.RentedCars.Find(id);
            if (rentedCar == null)
            {
                return HttpNotFound();
            }
            return View(rentedCar);
        }

        // POST: RentedCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentedCar rentedCar = db.RentedCars.Find(id);
            db.RentedCars.Remove(rentedCar);
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
