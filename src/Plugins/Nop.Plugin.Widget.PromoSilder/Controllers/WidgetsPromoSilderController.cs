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

namespace Nop.Plugin.Widgets.PromoSilder.Controllers
{

    public class WidgetsPromoSilderController : BasePluginController
    {
        private ICacheManager _cacheManager;
        private IPictureService _pictureService;
        private IRepository<PromoSilderImage> _promoSilderImageRep;
        private IRepository<Models.PromoSilder> _promoSilderRep;
        private IStoreService _storeService;
        private IWorkContext _workContext;

        public WidgetsPromoSilderController(
            IWorkContext workContext,
            IStoreService storeService,
            ICacheManager cacheManager,
            IPictureService pictureService,
            IRepository<Models.PromoSilder> promoSiderRep,
            IRepository<Models.PromoSilderImage> promoSiderImageRep
            )
        {
            _storeService = storeService;
            _workContext = workContext;
            _cacheManager = cacheManager;
            _pictureService = pictureService;
            _promoSilderRep = promoSiderRep;
            _promoSilderImageRep = promoSiderImageRep;
        }

        public ActionResult Configuration(int PromoSilderId = 0)
        {
            var promoSilder = new Models.PromoSilder() { PromoSilderId = PromoSilderId, Interval = 3 };
            //var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
            //promoSilder.ActiveStoreScopeConfiguration = storeScope;

            if (PromoSilderId > 0)
            {
                promoSilder = _promoSilderRep.GetById(PromoSilderId);
            }

            return View("~/Plugins/Widgets.PromoSilder/Views/WidgetsPromoSilder/Configuration.cshtml", promoSilder);
        }

        [HttpPost]
        [AdminAuthorize]
        public ActionResult Configuration(Models.PromoSilder promoSilder)
        {
            ViewBag.ErrorMessage = null;

            if (ModelState.IsValid)
            {
                var silder = _promoSilderRep.GetById(promoSilder.PromoSilderId);

                if (silder == null)
                {
                    _promoSilderRep.Insert(promoSilder);
                    SuccessNotification("Promo Silder has been created successfully!");
                    ModelState.Clear();

                    return Configuration(promoSilder.PromoSilderId);
                }
                else
                {
                    silder.Interval = promoSilder.Interval;
                    silder.IsActive = promoSilder.IsActive;
                    silder.KeyBoard = promoSilder.KeyBoard;
                    silder.PauseOnHover = promoSilder.PauseOnHover;
                    silder.PromoSilderName = promoSilder.PromoSilderName;
                    silder.Wrap = promoSilder.Wrap;
                    silder.ZoneName = promoSilder.ZoneName;

                    _promoSilderRep.Update(silder);
                    _cacheManager.Clear();
                    SuccessNotification("The changes have been saved!");

                    ModelState.Clear();

                    return Configuration(silder.PromoSilderId);
                    //return View("~/Plugins/Widgets.PromoSilder/Views/WidgetsPromoSilder/Configuration.cshtml", silder);
                }
            }
            else { 
                ViewBag.ErrorMessage = String.Join(Environment.NewLine, ModelState.Values.SelectMany(v => v.Errors)
                                                           .Select(v => v.ErrorMessage + " " + v.Exception));
                return Configuration();
                //return View("~/Plugins/Widgets.PromoSilder/Views/WidgetsPromoSilder/Configuration.cshtml");
            }
        }

        public ActionResult DisplayWidget()
        {
            return Content("DisplayWidget");
        }
    }
}