using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Services.Media;
using Nop.Web.Framework.Controllers;
using System;
using System.Web.Mvc;
using Nop.Plugin.Widgets.PromoSilder.Models;
using System.Linq;
using Nop.Core;
using Nop.Services.Stores;
using Nop.Web.Framework.Kendoui;
using Nop.Plugin.Widgets.PromoSilder.Services;
using Nop.Services.Security;
using System.Web.Routing;
using Nop.Web.Framework.Security;
using Nop.Web.Framework.Mvc;
using Nop.Plugin.Widgets.PromoSilder.Domain;
using System.Collections.Generic;

namespace Nop.Plugin.Widgets.PromoSilder.Controllers
{

    public class WidgetsPromoSilderController : BasePluginController
    {
        private readonly ICacheManager _cacheManager;
        private readonly IPictureService _pictureService;

        private readonly IPromoSilderService _promoSilderService;
        private readonly IPromoSilderImageService _promoSiderImageService;

        private readonly IStoreService _storeService;
        private readonly IWorkContext _workContext;
        private readonly IPermissionService _permissionService;

        public WidgetsPromoSilderController(
            IWorkContext workContext,
            IStoreService storeService,
            ICacheManager cacheManager,
            IPictureService pictureService,
            IPromoSilderService promoSilderService,
            IPromoSilderImageService promoSiderService,
            IPermissionService permissionService
            )
        {
            _storeService = storeService;
            _workContext = workContext;
            _cacheManager = cacheManager;
            _pictureService = pictureService;
            _promoSilderService = promoSilderService;
            _promoSiderImageService = promoSiderService;
            _permissionService = permissionService;
        }

        protected override void Initialize(RequestContext requestContext)
        {
            //little hack here
            //always set culture to 'en-US' (Telerik has a bug related to editing decimal values in other cultures). Like currently it's done for admin area in Global.asax.cs
            //CommonHelper.SetTelerikCulture();

            base.Initialize(requestContext);
        }

        [ChildActionOnly]
        [AdminAuthorize]
        public ActionResult PromoSilderList()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return Content("Access denied");

            return View();
        }

        [HttpPost]
        [AdminAntiForgery]
        public ActionResult ActualList(DataSourceRequest command)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return Content("Access denied");

            var silders = _promoSilderService.GetAllPromoSilders(command.Page - 1, command.PageSize); //command.Page starts from 1.
            var model = silders
                .Select(x =>
               {
                   var m = new PromoSilderModel()
                   {
                       Id = x.Id,
                       Interval = x.Interval,
                       IsActive = x.IsActive,
                       PauseOnHover = x.PauseOnHover,
                       PromoSilderName = x.PromoSilderName,
                       StoreId = x.StoreId,
                       ZoneName = x.ZoneName
                   };

                   //store
                   var store = _storeService.GetStoreById(x.StoreId);
                   m.StoreName = (store != null) ? store.Name : "*";

                   return m;

               }).ToList();

            var gridModel = new DataSourceResult
            {
                Data = model,
                Total = silders.Count()
            };

            return Json(gridModel);
        }

        [HttpPost]
        [AdminAntiForgery]
        public ActionResult PromoSilderUpdate(PromoSilderModel silder)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return Content("Access denied");

            var entity = _promoSilderService.GetPromoSilderById(silder.Id);
            entity.Interval = silder.Interval;
            entity.IsActive = silder.IsActive;
            entity.PauseOnHover = silder.PauseOnHover;
            entity.PromoSilderName = silder.PromoSilderName;

            _promoSilderService.UpdatePromoSilder(entity);

            _cacheManager.Clear();

            return new NullJsonResult();
            
        }

        [HttpPost]
        [AdminAntiForgery]
        public ActionResult PromoSilderDelete(PromoSilderModel silder)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return Content("Access denied");

            var entity = _promoSilderService.GetPromoSilderById(silder.Id);

            if (silder != null)
                _promoSilderService.DeletePromoSilder(entity);

            _cacheManager.Clear();

            return new NullJsonResult();
        }

        public ActionResult DisplayWidget()
        {
            return Content("DisplayWidget");
        }
    
    }
}