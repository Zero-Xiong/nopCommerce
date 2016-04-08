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
using Nop.Web.Framework.Mvc;
using Nop.Plugin.Widgets.PromoSilder.Data;
using Nop.Data;
using Nop.Core.Data;

namespace Nop.Plugin.Widgets.PromoSilder.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        private const string CONTEXT_NAME = "no_object_context_promo_sider";

        public int Order
        {
            get
            {
                return 1;
            }
        }

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            this.RegisterPluginDataContext<PromoSilderDbContext>(builder, CONTEXT_NAME);

            builder.RegisterType<EfRepository<Models.PromoSilder>>()
                .As<IRepository<Models.PromoSilder>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<Models.PromoSilderImage>>()
                .As<IRepository<Models.PromoSilderImage>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            //we cache presentation models between requests
            //builder.RegisterType<PromoSilderController>()
            //    .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("nop_cache_static"));
        }
    }
}
