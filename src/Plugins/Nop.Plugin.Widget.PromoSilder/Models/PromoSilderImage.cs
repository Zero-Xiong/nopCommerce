using Nop.Core;
using System;

namespace Nop.Plugin.Widgets.PromoSilder.Models
{
    public class PromoSilderImage : BaseEntity
    {

        public virtual int PromoSilderImageId { get; set; }

        public virtual int PromoSilderId { get; set; }

        public virtual string Caption { get; set; }

        public virtual string Url { get; set; }

        public virtual string FilePath { get; set; }

        public virtual int DisplayOrder { get; set; }

        public PromoSilder PromoSilder { get; set; }
    }
}