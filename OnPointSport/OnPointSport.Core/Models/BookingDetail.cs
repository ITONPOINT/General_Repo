using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPointSport.Core.Models
{
    public class BookingDetail
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string BookingCode { get; set; }
        public string ProductServiceCode { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
