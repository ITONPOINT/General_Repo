using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPointSport.Core.Domain
{
    public class StockUnitPrice: AuditableEntity
    {
        public string Code { get; set; }
        public string ProductService { get; set; }
        public Double UnitCost { get; set; }
        public Double UnitPrice { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
