using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.PromoSilder.Domain
{
    public class PromoSilderRecord : BaseEntity
    {
        public virtual int StoreId { get; set; }

        public virtual string PromoSilderName { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual string ZoneName { get; set; }

        public virtual int Interval { get; set; }

        public virtual bool PauseOnHover { get; set; }

        public virtual bool Wrap { get; set; }

        public virtual bool KeyBoard { get; set; }


        public virtual ICollection<PromoSilderImageRecord> PromoSilderImages { get; set; }
    }
}
