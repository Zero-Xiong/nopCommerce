
using Nop.Core;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Nop.Plugin.Widgets.PromoSilder.Models
{

    public class PromoSilder : BaseEntity
    {
        public PromoSilder()
        {
            Images = new List<PromoSilderImage>();
        }

        public virtual int PromoSilderId { get; set; }

        public virtual string PromoSilderName { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual string ZoneName { get; set; }

        public virtual int Interval { get; set; }

        public virtual bool PauseOnHover { get; set; }

        public virtual bool Wrap { get; set; }

        public virtual bool KeyBoard { get; set; }


        public virtual IList<PromoSilderImage> Images { get; set; }

    }
}
