using Nop.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.PromoSilder.Domain
{
    public class PromoSilderImageRecord : BaseEntity
    {
        public virtual int PromoSilderId { get; set; }

        public virtual string Caption { get; set; }

        public virtual string Url { get; set; }

        public virtual string FilePath { get; set; }

        public virtual int DisplayOrder { get; set; }



        public virtual PromoSilderRecord PromoSilderRecord { get; set; }
    }
}
