using Nop.Core.Plugins;
using Nop.Plugin.Widgets.PromoSilder.Data;
using Nop.Services.Cms;
using System;
using System.Collections.Generic;
using System.Web.Routing;

namespace Nop.Plugin.Widgets.PromoSilder
{
    public class PromoSilderPlugin : BasePlugin, IWidgetPlugin
    {
        private PromoSilderDbContext _context;

        public PromoSilderPlugin(PromoSilderDbContext context)
        {
            _context = context;
        }

        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "PromoSilderList";
            controllerName = "WidgetsPromoSilder";
            routeValues = new RouteValueDictionary()
            {
                { "Namespace", "Nop.Plugin.Widgets.PromoSilder.Controllers" },
                { "area", null }
            };
        }

        public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "DisplayWidget";
            controllerName = "WidgetsPromoSilder";
            routeValues = new RouteValueDictionary()
            {
                { "Namespace", "Nop.Plugin.Widgets.PromoSilder.Controllers" },
                { "area", null },
                { "widgetZone", widgetZone }
            };
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string>();
        }

        public override void Install()
        {
            _context.Install();
            base.Install();
        }

        public override void Uninstall()
        {
            _context.UnInstall();
            base.Uninstall();
        }
    }

}
