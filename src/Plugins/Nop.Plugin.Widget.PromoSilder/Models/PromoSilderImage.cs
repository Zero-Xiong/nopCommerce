using Nop.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.Widgets.PromoSilder.Models
{
    public class PromoSilderImage : BaseEntity
    {
        public PromoSilderImage()
        {
            Id = 0; //bug? Ignored
        }
        public virtual int PromoSilderImageId { get; set; }

        //[UIHint("Int32")]
        public virtual int PromoSilderId { get; set; }

        public virtual string Caption { get; set; }

        public virtual string Url { get; set; }

        public virtual string FilePath { get; set; }

        //[UIHint("Int32")]
        public virtual int DisplayOrder { get; set; }

        public PromoSilder PromoSilder { get; set; }
    }
}