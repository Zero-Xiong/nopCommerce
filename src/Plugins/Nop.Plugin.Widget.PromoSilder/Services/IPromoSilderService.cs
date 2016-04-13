using Nop.Core;
using Nop.Plugin.Widgets.PromoSilder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.PromoSilder.Services
{
    public partial interface IPromoSilderService
    {
        IPagedList<PromoSilderRecord> GetAllPromoSilders(int pageIndex = 0, int pageSize = int.MaxValue);

        IList<PromoSilderRecord> GetAllPromoSilders();

        PromoSilderRecord GetPromoSilderById(int promoSilderId);

        void InsertPromoSilder(PromoSilderRecord silder);

        void UpdatePromoSilder(PromoSilderRecord silder);

        void DeletePromoSilder(PromoSilderRecord silder);

        //void DeletePromoSilders(IList<Models.PromoSilder> silders);
    }
}
