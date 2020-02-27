using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPointSport.Core.Domain
{
    public abstract class AuditableEntity : Entity
    {
        public virtual DateTime DateCreation { get; set; }
        public virtual DateTime DateModification { get; set; }
    }
}
