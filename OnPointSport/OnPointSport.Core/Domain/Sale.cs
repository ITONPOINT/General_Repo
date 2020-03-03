using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPointSport.Core.Domain
{
    public class Sale: AuditableEntity
    {
        public string Code { get; set; }
        public string CustomerCode { get; set; }
        public string DiscountCode { get; set; }
        public float TotalPrice { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
