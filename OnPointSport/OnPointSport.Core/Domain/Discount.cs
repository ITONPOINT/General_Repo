using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPointSport.Core.Domain
{
    public class Discount: AuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }  
        public float Rate { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
