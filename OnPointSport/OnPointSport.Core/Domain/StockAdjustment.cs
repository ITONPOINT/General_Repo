using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPointSport.Core.Domain
{
    public class StockAdjustment: AuditableEntity
    {
        public string Code { get; set; }
        public string ProductServiceCode { get; set; }
        public Double Quantity { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
