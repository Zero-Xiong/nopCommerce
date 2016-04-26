using Nop.Web.Framework.Mvc.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nop.Plugin.Widgets.PromoSilder.Infrastructure
{
    public class PromoSilderRouteProvider : IRouteProvider
    {
        public int Priority { get { return 1; } }

        public void RegisterRoutes(System.Web.Routing.RouteCollection routes)
        {
            ViewEngines.Engines.Insert(0, new PromoSilderViewEngine());
        }
    }
}
