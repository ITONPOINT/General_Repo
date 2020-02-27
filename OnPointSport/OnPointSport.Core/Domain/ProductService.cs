using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPointSport.Core.Domain
{
    public class ProductService: AuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string CategoryCode { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
