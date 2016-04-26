using Nop.Core;
using Nop.Web.Framework.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.Widgets.PromoSilder.Models
{
    public class PromoSilderImageModel : BaseNopEntityModel
    {
        public PromoSilderImageModel()
        {
        }

        public virtual int PromoSilderId { get; set; }

        public virtual string Caption { get; set; }

        public virtual string Url { get; set; }

        public virtual string FilePath { get; set; }

        public virtual int DisplayOrder { get; set; }



        public virtual PromoSilderModel PromoSilder { get; set; }
    }
}