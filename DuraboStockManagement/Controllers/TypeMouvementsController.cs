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
    public class TypeMouvementsController : Controller
    {
        private StockContext db = new StockContext();

        // GET: TypeMouvements
        public ActionResult Index()
        {
            return View(db.TypeMouvements.ToList());
        }

        // GET: TypeMouvements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeMouvement typeMouvement = db.TypeMouvements.Find(id);
            if (typeMouvement == null)
            {
                return HttpNotFound();
            }
            return View(typeMouvement);
        }

        // GET: TypeMouvements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeMouvements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeMouvementID,Designation,Sens")] TypeMouvement typeMouvement)
        {
            if (ModelState.IsValid)
            {
                db.TypeMouvements.Add(typeMouvement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeMouvement);
        }

        // GET: TypeMouvements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeMouvement typeMouvement = db.TypeMouvements.Find(id);
            if (typeMouvement == null)
            {
                return HttpNotFound();
            }
            return View(typeMouvement);
        }

        // POST: TypeMouvements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeMouvementID,Designation,Sens")] TypeMouvement typeMouvement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeMouvement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeMouvement);
        }

        // GET: TypeMouvements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeMouvement typeMouvement = db.TypeMouvements.Find(id);
            if (typeMouvement == null)
            {
                return HttpNotFound();
            }
            return View(typeMouvement);
        }

        // POST: TypeMouvements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeMouvement typeMouvement = db.TypeMouvements.Find(id);
            db.TypeMouvements.Remove(typeMouvement);
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
