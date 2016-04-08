using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.PromoSilder.Data
{
    public class PromoSilderImageMap : EntityTypeConfiguration<Models.PromoSilderImage>
    {
        public PromoSilderImageMap()
        {
            ToTable("PromoSilderImage");

            HasKey(k => k.PromoSilderImageId);

            Ignore(i => i.Id);

            Property(p => p.Caption);
            Property(p => p.DisplayOrder);
            Property(p => p.FilePath);
            Property(p => p.PromoSilderId);
            Property(p => p.Url);

            HasRequired(i => i.PromoSilder)
                .WithMany(w => w.Images)
                .HasForeignKey(f => f.PromoSilderId);
        }
    }
}
