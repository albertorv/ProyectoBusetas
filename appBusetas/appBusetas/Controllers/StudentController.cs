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
    public class StudentController : Controller
    {
        private BusetasEntities db = new BusetasEntities();

        //
        // GET: /Student/

        public ActionResult Index()
        {
            var student = db.Student.Include(s => s.PersonInCharge).Include(s => s.School);
            return View(student.ToList());
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id = 0)
        {
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            ViewBag.personInChargeId = new SelectList(db.PersonInCharge, "id", "name");
            ViewBag.schoolId = new SelectList(db.School, "id", "name");
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Student.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.personInChargeId = new SelectList(db.PersonInCharge, "id", "name", student.personInChargeId);
            ViewBag.schoolId = new SelectList(db.School, "id", "name", student.schoolId);
            return View(student);
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.personInChargeId = new SelectList(db.PersonInCharge, "id", "name", student.personInChargeId);
            ViewBag.schoolId = new SelectList(db.School, "id", "name", student.schoolId);
            return View(student);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.personInChargeId = new SelectList(db.PersonInCharge, "id", "name", student.personInChargeId);
            ViewBag.schoolId = new SelectList(db.School, "id", "name", student.schoolId);
            return View(student);
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Student.Find(id);
            db.Student.Remove(student);
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