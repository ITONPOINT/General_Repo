using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPointSport.Core.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string DiscountCode { get; set; }
        public string DiscountName { get; set; }
        public float TotalPrice { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
