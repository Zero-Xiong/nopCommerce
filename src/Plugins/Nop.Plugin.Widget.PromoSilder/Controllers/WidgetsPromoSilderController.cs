using Nop.Web.Framework.Controllers;
using System;
using System.Web.Mvc;

namespace Nop.Plugin.Widgets.PromoSilder.Controllers
{

    public class WidgetsPromoSilderController : BasePluginController
    {
        public WidgetsPromoSilderController()
        {

        }

        public ActionResult Configuration()
        {
            return Content("Configuration");
        }

        public ActionResult DisplayWidget()
        {
            return Content("DisplayWidget");
        }
    }
}