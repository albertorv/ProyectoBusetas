using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buseta_DataAccess;

namespace appBusetas.Controllers
{
    public class RouteScheduleController : Controller
    {
        private BusetasEntities db = new BusetasEntities();

        //
        // GET: /RouteSchedule/

        public ActionResult Index()
        {
            return View(db.RouteSchedule.ToList());
        }

        //
        // GET: /RouteSchedule/Details/5

        public ActionResult Details(int id = 0)
        {
            RouteSchedule routeschedule = db.RouteSchedule.Find(id);
            if (routeschedule == null)
            {
                return HttpNotFound();
            }
            return View(routeschedule);
        }

        //
        // GET: /RouteSchedule/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /RouteSchedule/Create

        [HttpPost]
        public ActionResult Create(RouteSchedule routeschedule)
        {
            if (ModelState.IsValid)
            {
                db.RouteSchedule.Add(routeschedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(routeschedule);
        }

        //
        // GET: /RouteSchedule/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RouteSchedule routeschedule = db.RouteSchedule.Find(id);
            if (routeschedule == null)
            {
                return HttpNotFound();
            }
            return View(routeschedule);
        }

        //
        // POST: /RouteSchedule/Edit/5

        [HttpPost]
        public ActionResult Edit(RouteSchedule routeschedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routeschedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(routeschedule);
        }

        //
        // GET: /RouteSchedule/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RouteSchedule routeschedule = db.RouteSchedule.Find(id);
            if (routeschedule == null)
            {
                return HttpNotFound();
            }
            return View(routeschedule);
        }

        //
        // POST: /RouteSchedule/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RouteSchedule routeschedule = db.RouteSchedule.Find(id);
            db.RouteSchedule.Remove(routeschedule);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}