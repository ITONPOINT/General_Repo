using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPointSport.Core.Domain
{
    public class ExchangeRate: AuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public float FromAmount { get; set; }
        public float ToAmount { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
