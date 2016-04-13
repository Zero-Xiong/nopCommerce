
using Nop.Core;
using Nop.Web.Framework.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.Widgets.PromoSilder.Models
{

    public class PromoSilderModel : BaseNopEntityModel
    {
        public PromoSilderModel()
        {
            Images = new List<PromoSilderImageModel>();
        }

        public virtual int StoreId { get; set; }

        public virtual string StoreName { get; set; }


        public virtual string PromoSilderName { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual string ZoneName { get; set; }

        public virtual int Interval { get; set; }

        public virtual bool PauseOnHover { get; set; }



        public virtual IList<PromoSilderImageModel> Images { get; set; }
    }
}
