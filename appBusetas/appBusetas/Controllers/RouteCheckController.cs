using Buseta_DataAccess;
using appBusetas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appBusetas.Controllers
{
    public class RouteCheckController : Controller
    {
        private BusetasEntities db = new BusetasEntities();

        //
        // GET: /Search/

        public ActionResult Index()
        {
            // get data from database
            var routes = db.Route.ToList();

            // create model
            var model = new RouteCheckModel();

            // fill routes in the given model
            model.routes = routes;

            // return model to the view
            return View(model);
        }

        //
        // POST: /Search/
        [HttpPost]
        public ActionResult Index(RouteCheckModel model)
        {
            var search =(model.SearchText);
            var search2 = Convert.ToInt32(model.SearchText);

            if (String.IsNullOrEmpty(search))
            {
                model.routes = db.Route.ToList();
            }
            else
            {
                // run the query to get the desired results
                
                model.routes = db.Route.Where((x => x.RouteSchedule.id.Equals(search2))).ToList();
            }
            // return model to the view
            return View(model);
        }
    }
}