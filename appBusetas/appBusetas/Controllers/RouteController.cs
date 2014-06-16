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
    public class RouteController : Controller
    {
        private BusetasEntities db = new BusetasEntities();

        //
        // GET: /Route/

        public ActionResult Index()
        {
            var route = db.Route.Include(r => r.Bus).Include(r => r.Employee).Include(r => r.Employee1).Include(r => r.RouteSchedule);
            return View(route.ToList());
        }

        //
        // GET: /Route/Details/5

        public ActionResult Details(int id = 0)
        {
            Route route = db.Route.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        //
        // GET: /Route/Create

        public ActionResult Create()
        {
            ViewBag.busId = new SelectList(db.Bus, "id", "brand");
            ViewBag.copilotId = new SelectList(db.Employee, "id", "name");
            ViewBag.pilotId = new SelectList(db.Employee, "id", "name");
            ViewBag.routeScheduleId = new SelectList(db.RouteSchedule, "id", "dayOfTheWeek");
            return View();
        }

        //
        // POST: /Route/Create

        [HttpPost]
        public ActionResult Create(Route route)
        {
            if (ModelState.IsValid)
            {
                db.Route.Add(route);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.busId = new SelectList(db.Bus, "id", "brand", route.busId);
            ViewBag.copilotId = new SelectList(db.Employee, "id", "name", route.copilotId);
            ViewBag.pilotId = new SelectList(db.Employee, "id", "name", route.pilotId);
            ViewBag.routeScheduleId = new SelectList(db.RouteSchedule, "id", "dayOfTheWeek", route.routeScheduleId);
            return View(route);
        }

        //
        // GET: /Route/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Route route = db.Route.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            ViewBag.busId = new SelectList(db.Bus, "id", "brand", route.busId);
            ViewBag.copilotId = new SelectList(db.Employee, "id", "name", route.copilotId);
            ViewBag.pilotId = new SelectList(db.Employee, "id", "name", route.pilotId);
            ViewBag.routeScheduleId = new SelectList(db.RouteSchedule, "id", "dayOfTheWeek", route.routeScheduleId);
            return View(route);
        }

        //
        // POST: /Route/Edit/5

        [HttpPost]
        public ActionResult Edit(Route route)
        {
            if (ModelState.IsValid)
            {
                db.Entry(route).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.busId = new SelectList(db.Bus, "id", "brand", route.busId);
            ViewBag.copilotId = new SelectList(db.Employee, "id", "name", route.copilotId);
            ViewBag.pilotId = new SelectList(db.Employee, "id", "name", route.pilotId);
            ViewBag.routeScheduleId = new SelectList(db.RouteSchedule, "id", "dayOfTheWeek", route.routeScheduleId);
            return View(route);
        }

        //
        // GET: /Route/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Route route = db.Route.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        //
        // POST: /Route/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Route route = db.Route.Find(id);
            db.Route.Remove(route);
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