using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPointSport.Core.Domain
{
    public class Supplier: AuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
