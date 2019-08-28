using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DuraboStockManagement.Models;

namespace DuraboStockManagement.Controllers
{
    public class CooperativesController : Controller
    {
        private StockContext db = new StockContext();

        // GET: Cooperatives
        public ActionResult Index()
        {
            return View(db.Cooperatives.ToList());
        }

        // GET: Cooperatives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cooperative cooperative = db.Cooperatives.Find(id);
            if (cooperative == null)
            {
                return HttpNotFound();
            }
            return View(cooperative);
        }

        // GET: Cooperatives/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cooperatives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CooperativeID,NomCooperative")] Cooperative cooperative)
        {
            if (ModelState.IsValid)
            {
                db.Cooperatives.Add(cooperative);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cooperative);
        }

        // GET: Cooperatives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cooperative cooperative = db.Cooperatives.Find(id);
            if (cooperative == null)
            {
                return HttpNotFound();
            }
            return View(cooperative);
        }

        // POST: Cooperatives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CooperativeID,NomCooperative")] Cooperative cooperative)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cooperative).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cooperative);
        }

        // GET: Cooperatives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cooperative cooperative = db.Cooperatives.Find(id);
            if (cooperative == null)
            {
                return HttpNotFound();
            }
            return View(cooperative);
        }

        // POST: Cooperatives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cooperative cooperative = db.Cooperatives.Find(id);
            db.Cooperatives.Remove(cooperative);
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
