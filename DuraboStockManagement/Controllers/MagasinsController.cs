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
    public class MagasinsController : Controller
    {
        private StockContext db = new StockContext();

        // GET: Magasins
        public ActionResult Index()
        {
            return View(db.Magasins.ToList());
        }

        // GET: Magasins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Magasin magasin = db.Magasins.Find(id);
            if (magasin == null)
            {
                return HttpNotFound();
            }
            return View(magasin);
        }

        // GET: Magasins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Magasins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MagasinID,NomMagasin,QuantitéMaximale")] Magasin magasin)
        {
            if (ModelState.IsValid)
            {
                db.Magasins.Add(magasin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(magasin);
        }

        // GET: Magasins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Magasin magasin = db.Magasins.Find(id);
            if (magasin == null)
            {
                return HttpNotFound();
            }
            return View(magasin);
        }

        // POST: Magasins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MagasinID,NomMagasin,QuantitéMaximale")] Magasin magasin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(magasin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(magasin);
        }

        // GET: Magasins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Magasin magasin = db.Magasins.Find(id);
            if (magasin == null)
            {
                return HttpNotFound();
            }
            return View(magasin);
        }

        // POST: Magasins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Magasin magasin = db.Magasins.Find(id);
            db.Magasins.Remove(magasin);
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
