using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPointSport.Core.Domain
{
    public class Import: AuditableEntity
    {
        public string Code { get; set; }
        public string SupplierCode { get; set; }
        public string DiscountCode { get; set; }
        public Double TotalPrice { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
