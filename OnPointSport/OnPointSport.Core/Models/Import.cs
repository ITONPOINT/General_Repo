using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPointSport.Core.Models
{
    public class Import
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string DiscountCode { get; set; }
        public string DescountName { get; set; }
        public Double TotalPrice { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
