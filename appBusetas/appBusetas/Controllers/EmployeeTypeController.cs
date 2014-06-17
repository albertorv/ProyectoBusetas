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
    public class EmployeeTypeController : Controller
    {
        private BusetasEntities db = new BusetasEntities();

        //
        // GET: /EmployeeType/

        public ActionResult Index()
        {
            return View(db.EmployeeType.ToList());
        }

        //
        // GET: /EmployeeType/Details/5

        public ActionResult Details(int id = 0)
        {
            EmployeeType employeetype = db.EmployeeType.Find(id);
            if (employeetype == null)
            {
                return HttpNotFound();
            }
            return View(employeetype);
        }

        //
        // GET: /EmployeeType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /EmployeeType/Create

        [HttpPost]
        public ActionResult Create(EmployeeType employeetype)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeType.Add(employeetype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeetype);
        }

        //
        // GET: /EmployeeType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EmployeeType employeetype = db.EmployeeType.Find(id);
            if (employeetype == null)
            {
                return HttpNotFound();
            }
            return View(employeetype);
        }

        //
        // POST: /EmployeeType/Edit/5

        [HttpPost]
        public ActionResult Edit(EmployeeType employeetype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeetype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeetype);
        }

        //
        // GET: /EmployeeType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EmployeeType employeetype = db.EmployeeType.Find(id);
            if (employeetype == null)
            {
                return HttpNotFound();
            }
            return View(employeetype);
        }

        //
        // POST: /EmployeeType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeType employeetype = db.EmployeeType.Find(id);
            db.EmployeeType.Remove(employeetype);
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