using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnPointSport.Core.Models
{
    public class StockAdjustment
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessage = "please, select Itim!")]
        public string ProductServiceCode { get; set; }
        public string ProductServiceName { get; set; }
        [Required(ErrorMessage = "please, enter Quantity!")]
        public Double Quantity { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
