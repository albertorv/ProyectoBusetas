using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appBusetas.Models
{
    public class RouteCheckModel
    {
        public string SearchText { get; set; }

       
        public List<Buseta_DataAccess.Route> routes { get; set; }

    }
}