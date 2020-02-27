using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPointSport.Core.Models
{
    public class ItemDetail
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string SaleCode { get; set; }
        public string ProductServiceCode { get; set; }
        public string ProductServiceName { get; set; }
        public float Quantity { get; set; }
        public float UnitPrice { get; set; }
        public float SubTotalPrice { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
