using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaerskLineAssignment.Models;

namespace MaerskLineAssignment.Controllers
{
    public class ShipyardsController : Controller
    {
        private MaerskLineAssignmentContext db = new MaerskLineAssignmentContext();

        // GET: Shipyards
        public ActionResult Index()
        {
            return View(db.Shipyards.ToList());
        }

        // GET: Shipyards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipyard shipyard = db.Shipyards.Find(id);
            if (shipyard == null)
            {
                return HttpNotFound();
            }
            return View(shipyard);
        }

        // GET: Shipyards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shipyards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShipyardID,ShipyardName,Location")] Shipyard shipyard)
        {
            if (ModelState.IsValid)
            {
                db.Shipyards.Add(shipyard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shipyard);
        }

        // GET: Shipyards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipyard shipyard = db.Shipyards.Find(id);
            if (shipyard == null)
            {
                return HttpNotFound();
            }
            return View(shipyard);
        }

        // POST: Shipyards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShipyardID,ShipyardName,Location")] Shipyard shipyard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipyard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipyard);
        }

        // GET: Shipyards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipyard shipyard = db.Shipyards.Find(id);
            if (shipyard == null)
            {
                return HttpNotFound();
            }
            return View(shipyard);
        }

        // POST: Shipyards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shipyard shipyard = db.Shipyards.Find(id);
            db.Shipyards.Remove(shipyard);
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
