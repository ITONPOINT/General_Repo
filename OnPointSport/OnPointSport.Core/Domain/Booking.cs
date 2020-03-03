using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPointSport.Core.Domain
{
    public class Booking: AuditableEntity
    {
        public string Code { get; set; }
        public string CustomerCode { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime BookingDebutTime { get; set; }
        public DateTime BookingFinTime { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
