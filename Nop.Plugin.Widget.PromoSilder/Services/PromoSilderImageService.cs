using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Plugin.Widgets.PromoSilder.Models;
using Nop.Core.Caching;
using Nop.Services.Events;
using Nop.Core.Data;
using Nop.Plugin.Widgets.PromoSilder.Domain;

namespace Nop.Plugin.Widgets.PromoSilder.Services
{
    public partial class PromoSilderImageService : IPromoSilderImageService
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<PromoSilderImageRecord> _repository;

        public PromoSilderImageService(
            IEventPublisher eventPublisher,
            IRepository<PromoSilderImageRecord> repository)
        {
            _eventPublisher = eventPublisher;
            _repository = repository;
        }

        public void DeletePromoSilderImage(PromoSilderImageRecord silderImage)
        {
            throw new NotImplementedException();
        }

        public IList<PromoSilderImageRecord> GetAllPromoSilderImages(int promoSilderId)
        {
            throw new NotImplementedException();
        }

        public IPagedList<PromoSilderImageRecord> GetAllPromoSilderImages(int promoSilderId, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public PromoSilderImageRecord GetPromoSilderImageById(int promoSilderImageId)
        {
            throw new NotImplementedException();
        }

        public void InsertPromoSilderImage(PromoSilderRecord promoSilder, PromoSilderImageRecord silderImage)
        {
            throw new NotImplementedException();
        }

        public void InsertPromoSilderImage(int promoSilderId, PromoSilderImageRecord silderImage)
        {
            throw new NotImplementedException();
        }

        public void UpdatePromoSilderImage(PromoSilderRecord promoSilder, PromoSilderImageRecord silderImage)
        {
            throw new NotImplementedException();
        }

        public void UpdatePromoSilderImage(int promoSilderId, PromoSilderImageRecord silderImage)
        {
            throw new NotImplementedException();
        }
    }
}
