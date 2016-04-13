using Nop.Web.Framework.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.PromoSilder.Infrastructure
{
    public class PromoSilderViewEngine : ThemeableRazorViewEngine
    {
        public PromoSilderViewEngine()
        {
            ViewLocationFormats = new[] { "~/Plugins/Widgets.PromoSilder/Views/{1}/{0}.cshtml" };
            PartialViewLocationFormats = new[] { "~/Plugins/Widgets.PromoSilder/Views/{1}/{0}.cshtml" };
        }
    }
}
