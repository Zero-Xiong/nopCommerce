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
using Nop.Plugin.Widgets.PromoSilder.Services;
using Nop.Plugin.Widgets.PromoSilder.Domain;

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
            builder.RegisterType<PromoSilderService>().As<IPromoSilderService>().InstancePerLifetimeScope();

            builder.RegisterType<PromoSilderImageService>().As<IPromoSilderImageService>().InstancePerLifetimeScope();

            this.RegisterPluginDataContext<PromoSilderDbContext>(builder, CONTEXT_NAME);

            builder.RegisterType<EfRepository<PromoSilderRecord>>()
                .As<IRepository<PromoSilderRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<PromoSilderImageRecord>>()
                .As<IRepository<PromoSilderImageRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            //we cache presentation models between requests
            //builder.RegisterType<PromoSilderController>()
            //    .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("nop_cache_static"));
        }
    }
}
