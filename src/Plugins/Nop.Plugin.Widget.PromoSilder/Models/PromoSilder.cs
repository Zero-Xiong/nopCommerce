
using Nop.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.Widgets.PromoSilder.Models
{

    public class PromoSilder : BaseEntity
    {
        public PromoSilder()
        {
            Images = new List<PromoSilderImage>();
            Id = 0; //bug? Ignored
        }

        public virtual int PromoSilderId { get; set; }

        public virtual string PromoSilderName { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual string ZoneName { get; set; }

        //[UIHint("Integer")]
        public virtual int Interval { get; set; }

        public virtual bool PauseOnHover { get; set; }

        public virtual bool Wrap { get; set; }

        public virtual bool KeyBoard { get; set; }


        public virtual IList<PromoSilderImage> Images { get; set; }


        //public int ActiveStoreScopeConfiguration { get; set; }

    }
}
