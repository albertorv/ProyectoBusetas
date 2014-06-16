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
    public class RouteStudentController : Controller
    {
        private BusetasEntities db = new BusetasEntities();

        //
        // GET: /RouteStudent/

        public ActionResult Index()
        {
            var routestudent = db.RouteStudent.Include(r => r.Route).Include(r => r.Student);
            return View(routestudent.ToList());
        }

        //
        // GET: /RouteStudent/Details/5

        public ActionResult Details(int id = 0)
        {
            RouteStudent routestudent = db.RouteStudent.Find(id);
            if (routestudent == null)
            {
                return HttpNotFound();
            }
            return View(routestudent);
        }

        //
        // GET: /RouteStudent/Create

        public ActionResult Create()
        {
            ViewBag.routeId = new SelectList(db.Route, "id", "id");
            ViewBag.studentId = new SelectList(db.Student, "id", "name");
            return View();
        }

        //
        // POST: /RouteStudent/Create

        [HttpPost]
        public ActionResult Create(RouteStudent routestudent)
        {
            if (ModelState.IsValid)
            {
                db.RouteStudent.Add(routestudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.routeId = new SelectList(db.Route, "id", "id", routestudent.routeId);
            ViewBag.studentId = new SelectList(db.Student, "id", "name", routestudent.studentId);
            return View(routestudent);
        }

        //
        // GET: /RouteStudent/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RouteStudent routestudent = db.RouteStudent.Find(id);
            if (routestudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.routeId = new SelectList(db.Route, "id", "id", routestudent.routeId);
            ViewBag.studentId = new SelectList(db.Student, "id", "name", routestudent.studentId);
            return View(routestudent);
        }

        //
        // POST: /RouteStudent/Edit/5

        [HttpPost]
        public ActionResult Edit(RouteStudent routestudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routestudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.routeId = new SelectList(db.Route, "id", "id", routestudent.routeId);
            ViewBag.studentId = new SelectList(db.Student, "id", "name", routestudent.studentId);
            return View(routestudent);
        }

        //
        // GET: /RouteStudent/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RouteStudent routestudent = db.RouteStudent.Find(id);
            if (routestudent == null)
            {
                return HttpNotFound();
            }
            return View(routestudent);
        }

        //
        // POST: /RouteStudent/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RouteStudent routestudent = db.RouteStudent.Find(id);
            db.RouteStudent.Remove(routestudent);
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