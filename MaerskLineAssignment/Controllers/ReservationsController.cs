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
    public class ReservationsController : Controller
    {
        private MaerskLineAssignmentContext db = new MaerskLineAssignmentContext();

        // GET: Reservations
        public ActionResult Index()
        {
            var reservations = db.Reservations.Include(r => r.Container).Include(r => r.Ship).Include(r => r.Shipyard).Include(r => r.Shipyard1);
            return View(reservations.ToList());
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerDescription");
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName");
            ViewBag.DepartureShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName");
            ViewBag.ArrivalShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationID,ShipID,ContainerID,Price,ArrivalDate,DepartureDate,DepartureShipyardID,ArrivalShipyardID")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerDescription", reservation.ContainerID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName", reservation.ShipID);
            ViewBag.DepartureShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName", reservation.DepartureShipyardID);
            ViewBag.ArrivalShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName", reservation.ArrivalShipyardID);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerDescription", reservation.ContainerID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName", reservation.ShipID);
            ViewBag.DepartureShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName", reservation.DepartureShipyardID);
            ViewBag.ArrivalShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName", reservation.ArrivalShipyardID);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationID,ShipID,ContainerID,Price,ArrivalDate,DepartureDate,DepartureShipyardID,ArrivalShipyardID")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerDescription", reservation.ContainerID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName", reservation.ShipID);
            ViewBag.DepartureShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName", reservation.DepartureShipyardID);
            ViewBag.ArrivalShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName", reservation.ArrivalShipyardID);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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
