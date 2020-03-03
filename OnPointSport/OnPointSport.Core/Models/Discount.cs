using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPointSport.Core.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessage = "Please enter name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "please select date!")]
        public DateTime Debut { get; set; }
        [Required(ErrorMessage = "Please, select date!")]
        public DateTime Fin { get; set; }
        [Required(ErrorMessage = "Please enter rate!")]
        public float Rate { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
