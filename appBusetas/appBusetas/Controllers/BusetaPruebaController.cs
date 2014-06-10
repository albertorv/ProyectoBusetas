using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appBusetas.Controllers
{
    public class BusetaPruebaController : Controller
    {
        //
        // GET: /BusetaPrueba/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /BusetaPrueba/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /BusetaPrueba/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BusetaPrueba/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /BusetaPrueba/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /BusetaPrueba/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /BusetaPrueba/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /BusetaPrueba/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
