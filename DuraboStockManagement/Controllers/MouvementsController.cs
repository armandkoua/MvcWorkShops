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
    public class MouvementsController : Controller
    {
        private StockContext db = new StockContext();

        // GET: Mouvements
        public ActionResult Index()
        {
            var mouvements = db.Mouvements.Include(m => m.MagasinEntree).Include(m => m.MagasinSortie);
            return View(mouvements.ToList());
        }

        // GET: Mouvements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mouvement mouvement = db.Mouvements.Find(id);
            if (mouvement == null)
            {
                return HttpNotFound();
            }
            return View(mouvement);
        }

        // GET: Mouvements/Create
        public ActionResult Create()
        {
            ViewBag.EntreeMagasinID = new SelectList(db.Magasins, "MagasinID", "NomMagasin");
            ViewBag.SortieMagasinID = new SelectList(db.Magasins, "MagasinID", "NomMagasin");
            ViewBag.TypeMouvementID = new SelectList(db.TypeMouvements, "TypeMouvementID", "Designation");
            return View();
        }

        // POST: Mouvements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MouvementID,DateMouvement,EntreeMagasinID,SortieMagasinID,TypeMouvementID,QuantitéDemandée,EstApprouvee,EstRefusee,NomApprobateur,NomDemandeur")] Mouvement mouvement)
        {
            if (ModelState.IsValid)
            {
                db.Mouvements.Add(mouvement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EntreeMagasinID = new SelectList(db.Magasins, "MagasinID", "NomMagasin", mouvement.EntreeMagasinID);
            ViewBag.SortieMagasinID = new SelectList(db.Magasins, "MagasinID", "NomMagasin", mouvement.SortieMagasinID);
            ViewBag.TypeMouvementID = new SelectList(db.TypeMouvements, "TypeMouvementID", "Designation");
            return View(mouvement);
        }

        // GET: Mouvements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mouvement mouvement = db.Mouvements.Find(id);
            if (mouvement == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntreeMagasinID = new SelectList(db.Magasins, "MagasinID", "NomMagasin", mouvement.EntreeMagasinID);
            ViewBag.SortieMagasinID = new SelectList(db.Magasins, "MagasinID", "NomMagasin", mouvement.SortieMagasinID);
            ViewBag.TypeMouvementID = new SelectList(db.TypeMouvements, "TypeMouvementID", "Designation",mouvement.TypeMouvementID);
            return View(mouvement);
        }

        // POST: Mouvements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MouvementID,DateMouvement,EntreeMagasinID,SortieMagasinID,TypeMouvementID,QuantitéDemandée,EstApprouvee,EstRefusee,NomApprobateur,NomDemandeur")] Mouvement mouvement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mouvement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EntreeMagasinID = new SelectList(db.Magasins, "MagasinID", "NomMagasin", mouvement.EntreeMagasinID);
            ViewBag.SortieMagasinID = new SelectList(db.Magasins, "MagasinID", "NomMagasin", mouvement.SortieMagasinID);
            ViewBag.TypeMouvementID = new SelectList(db.TypeMouvements, "TypeMouvementID", "Designation",mouvement.TypeMouvementID);
            return View(mouvement);
        }

        // GET: Mouvements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mouvement mouvement = db.Mouvements.Find(id);
            if (mouvement == null)
            {
                return HttpNotFound();
            }
            return View(mouvement);
        }

        // POST: Mouvements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mouvement mouvement = db.Mouvements.Find(id);
            db.Mouvements.Remove(mouvement);
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
