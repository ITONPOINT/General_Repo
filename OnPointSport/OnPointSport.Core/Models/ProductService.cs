using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPointSport.Core.Models
{
    public class ProductService
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessage = "Please Input Product Name")]
        public string Name { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
