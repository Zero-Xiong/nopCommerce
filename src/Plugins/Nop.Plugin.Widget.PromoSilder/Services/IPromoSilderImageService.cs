using Nop.Core;
using Nop.Plugin.Widgets.PromoSilder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.PromoSilder.Services
{
    public partial interface IPromoSilderImageService
    {
        IPagedList<PromoSilderImageRecord> GetAllPromoSilderImages(int promoSilderId, int pageIndex = 0, int pageSize = int.MaxValue );

        IList<PromoSilderImageRecord> GetAllPromoSilderImages(int promoSilderId);

        PromoSilderImageRecord GetPromoSilderImageById(int promoSilderImageId);

        void InsertPromoSilderImage(int promoSilderId, PromoSilderImageRecord silderImage);

        void InsertPromoSilderImage(PromoSilderRecord promoSilder, PromoSilderImageRecord silderImage);

        void UpdatePromoSilderImage(int promoSilderId, PromoSilderImageRecord silderImage);

        void UpdatePromoSilderImage(PromoSilderRecord promoSilder, PromoSilderImageRecord silderImage);

        void DeletePromoSilderImage(PromoSilderImageRecord silderImage);
    }
}
