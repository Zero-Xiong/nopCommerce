using Nop.Data.Mapping;
using Nop.Plugin.Widgets.PromoSilder.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.PromoSilder.Data
{
    public class PromoSilderImageMap : NopEntityTypeConfiguration<PromoSilderImageRecord>
    {
        public PromoSilderImageMap()
        {
            ToTable("PromoSilderImage");

            HasKey(k => k.Id);

            Property(p => p.Caption);
            Property(p => p.DisplayOrder);
            Property(p => p.FilePath);
            Property(p => p.PromoSilderId);
            Property(p => p.Url);

            HasRequired(i => i.PromoSilderRecord)
                .WithMany(w => w.PromoSilderImages)
                .HasForeignKey(f => f.PromoSilderId);
        }
    }
}
