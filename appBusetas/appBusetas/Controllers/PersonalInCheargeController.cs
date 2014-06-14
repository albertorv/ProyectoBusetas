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
    public class PersonalInCheargeController : Controller
    {
        private BusetasEntities db = new BusetasEntities();

        //
        // GET: /PersonalInChearge/

        public ActionResult Index()
        {
            return View(db.PersonInCharge.ToList());
        }

        //
        // GET: /PersonalInChearge/Details/5

        public ActionResult Details(int id = 0)
        {
            PersonInCharge personincharge = db.PersonInCharge.Find(id);
            if (personincharge == null)
            {
                return HttpNotFound();
            }
            return View(personincharge);
        }

        //
        // GET: /PersonalInChearge/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PersonalInChearge/Create

        [HttpPost]
        public ActionResult Create(PersonInCharge personincharge)
        {
            if (ModelState.IsValid)
            {
                db.PersonInCharge.Add(personincharge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personincharge);
        }

        //
        // GET: /PersonalInChearge/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PersonInCharge personincharge = db.PersonInCharge.Find(id);
            if (personincharge == null)
            {
                return HttpNotFound();
            }
            return View(personincharge);
        }

        //
        // POST: /PersonalInChearge/Edit/5

        [HttpPost]
        public ActionResult Edit(PersonInCharge personincharge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personincharge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personincharge);
        }

        //
        // GET: /PersonalInChearge/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PersonInCharge personincharge = db.PersonInCharge.Find(id);
            if (personincharge == null)
            {
                return HttpNotFound();
            }
            return View(personincharge);
        }

        //
        // POST: /PersonalInChearge/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonInCharge personincharge = db.PersonInCharge.Find(id);
            db.PersonInCharge.Remove(personincharge);
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