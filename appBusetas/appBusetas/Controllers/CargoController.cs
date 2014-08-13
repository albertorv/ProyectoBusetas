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
    public class CargoController : Controller
    {
        private BusetasEntities db = new BusetasEntities();

        //
        // GET: /Cargo/

        public ActionResult Index()
        {
            var cargo = db.cargo.Include(c => c.Bus).Include(c => c.Student);
            return View(cargo.ToList());
        }

        //
        // GET: /Cargo/Details/5

        public ActionResult Details(int id = 0)
        {
            cargo cargo = db.cargo.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        //
        // GET: /Cargo/Create

        public ActionResult Create()
        {
            ViewBag.Bus_Id = new SelectList(db.Bus, "id", "brand");
            ViewBag.studentId = new SelectList(db.Student, "id", "name");
            return View();
        }

        //
        // POST: /Cargo/Create

        [HttpPost]
        public ActionResult Create(cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.cargo.Add(cargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bus_Id = new SelectList(db.Bus, "id", "brand", cargo.Bus_Id);
            ViewBag.studentId = new SelectList(db.Student, "id", "name", cargo.studentId);
            return View(cargo);
        }

        //
        // GET: /Cargo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            cargo cargo = db.cargo.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            ViewBag.studentId = new SelectList(db.Student, "id", "name", cargo.studentId);
            ViewBag.Bus_Id = new SelectList(db.Bus, "id", "brand", cargo.Bus_Id);
            return View(cargo);
        }

        //
        // POST: /Cargo/Edit/5

        [HttpPost]
        public ActionResult Edit(cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.studentId = new SelectList(db.Student, "id", "name", cargo.studentId);
            ViewBag.Bus_Id = new SelectList(db.Bus, "id", "brand", cargo.Bus_Id);
            
            return View(cargo);
        }

        //
        // GET: /Cargo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            cargo cargo = db.cargo.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        //
        // POST: /Cargo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            cargo cargo = db.cargo.Find(id);
            db.cargo.Remove(cargo);
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