using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiffanysCakesV4.Models;

namespace TiffanysCakesV4.Controllers
{
    public class CakeFlavoursController : Controller
    {
        private DataContext db = new DataContext();

        // GET: CakeFlavours
        public ActionResult Index()
        {
            var cakeFlavours = db.CakeFlavours.Include(c => c.Cake).Include(c => c.Flavour);
            return View(cakeFlavours.ToList());
        }

        // GET: CakeFlavours/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CakeFlavour cakeFlavour = db.CakeFlavours.Find(id);
            if (cakeFlavour == null)
            {
                return HttpNotFound();
            }
            return View(cakeFlavour);
        }

        // GET: CakeFlavours/Create
        public ActionResult Create()
        {
            ViewBag.CakeId = new SelectList(db.Cakes, "CakeId", "Name");
            ViewBag.FlavourId = new SelectList(db.Flavours, "FlavourId", "Name");
            return View();
        }

        // POST: CakeFlavours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CakeFlavourId,CreateDate,EditDate,CakeId,FlavourId")] CakeFlavour cakeFlavour)
        {
            if (ModelState.IsValid)
            {
                db.CakeFlavours.Add(cakeFlavour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CakeId = new SelectList(db.Cakes, "CakeId", "Name", cakeFlavour.CakeId);
            ViewBag.FlavourId = new SelectList(db.Flavours, "FlavourId", "Name", cakeFlavour.FlavourId);
            return View(cakeFlavour);
        }

        // GET: CakeFlavours/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CakeFlavour cakeFlavour = db.CakeFlavours.Find(id);
            if (cakeFlavour == null)
            {
                return HttpNotFound();
            }
            ViewBag.CakeId = new SelectList(db.Cakes, "CakeId", "Name", cakeFlavour.CakeId);
            ViewBag.FlavourId = new SelectList(db.Flavours, "FlavourId", "Name", cakeFlavour.FlavourId);
            return View(cakeFlavour);
        }

        // POST: CakeFlavours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CakeFlavourId,CreateDate,EditDate,CakeId,FlavourId")] CakeFlavour cakeFlavour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cakeFlavour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CakeId = new SelectList(db.Cakes, "CakeId", "Name", cakeFlavour.CakeId);
            ViewBag.FlavourId = new SelectList(db.Flavours, "FlavourId", "Name", cakeFlavour.FlavourId);
            return View(cakeFlavour);
        }

        // GET: CakeFlavours/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CakeFlavour cakeFlavour = db.CakeFlavours.Find(id);
            if (cakeFlavour == null)
            {
                return HttpNotFound();
            }
            return View(cakeFlavour);
        }

        // POST: CakeFlavours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CakeFlavour cakeFlavour = db.CakeFlavours.Find(id);
            db.CakeFlavours.Remove(cakeFlavour);
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
