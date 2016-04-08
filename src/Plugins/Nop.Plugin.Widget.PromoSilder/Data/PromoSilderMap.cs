using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Nop.Plugin.Widgets.PromoSilder.Data
{
    public class PromoSilderMap : EntityTypeConfiguration<Models.PromoSilder>
    {
        public PromoSilderMap()
        {
            ToTable("PromoSilder");

            HasKey(k => k.PromoSilderId);

            Ignore(i => i.Id);

            Property(p => p.PromoSilderName);
            Property(p => p.ZoneName);
            Property(p => p.Interval);
            Property(p => p.KeyBoard);
            Property(p => p.PauseOnHover);
            Property(p => p.Wrap);
        }
    }
}