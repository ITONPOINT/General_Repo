using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPointSport.Core.Domain
{
    public class User: AuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }

    }
}
