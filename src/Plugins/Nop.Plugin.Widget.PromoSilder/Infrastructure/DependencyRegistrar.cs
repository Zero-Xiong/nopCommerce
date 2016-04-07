using Nop.Core.Infrastructure.DependencyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Autofac;
using Nop.Plugin.Widgets.PromoSilder.Controllers;
using Autofac.Core;
using Nop.Core.Caching;

namespace Nop.Plugin.Widgets.PromoSilder.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order
        {
            get
            {
                return 2;
            }
        }

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            //we cache presentation models between requests
            builder.RegisterType<PromoSilderController>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("nop_cache_static"));
        }
    }
}
