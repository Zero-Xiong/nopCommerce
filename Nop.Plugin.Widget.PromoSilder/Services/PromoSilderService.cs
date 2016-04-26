using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Widgets.PromoSilder.Models;
using Nop.Core.Caching;
using Nop.Services.Events;
using Nop.Core.Data;
using Nop.Core;
using Nop.Plugin.Widgets.PromoSilder.Domain;

namespace Nop.Plugin.Widgets.PromoSilder.Services
{
    public class PromoSilderService : IPromoSilderService
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<PromoSilderRecord> _repository;

        public PromoSilderService(
            IEventPublisher eventPublisher,
            IRepository<PromoSilderRecord> repository)
        {
            _eventPublisher = eventPublisher;
            _repository = repository;
        }

        public void DeletePromoSilder(PromoSilderRecord silder)
        {
            if (silder == null)
                throw new ArgumentNullException("silder");

            _repository.Delete(silder);

            //event notification
            _eventPublisher.EntityDeleted(silder);
        }

        public IList<PromoSilderRecord> GetAllPromoSilders()
        {
            var query = from s in _repository.Table
                        orderby s.PromoSilderName
                        select s;
            var silders = query.ToList();

            return silders;
        }

        public IPagedList<PromoSilderRecord> GetAllPromoSilders(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = from s in _repository.Table
                        orderby s.PromoSilderName
                        select s;
            var records = new PagedList<PromoSilderRecord>(query, pageIndex, pageSize);

            return records;
        }

        public PromoSilderRecord GetPromoSilderById(int promoSilderId)
        {
            if (promoSilderId == 0)
                return null;

            return _repository.GetById(promoSilderId);
        }

        public void InsertPromoSilder(PromoSilderRecord silder)
        {
            if (silder == null)
                throw new ArgumentNullException("silder");

            _repository.Insert(silder);

            //event notification
            _eventPublisher.EntityInserted(silder);
        }

        public void UpdatePromoSilder(PromoSilderRecord silder)
        {
            if (silder == null)
                throw new ArgumentNullException("silder");

            _repository.Update(silder);

            //event notification
            _eventPublisher.EntityUpdated(silder);
        }
    }
}
