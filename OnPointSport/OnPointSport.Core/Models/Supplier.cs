using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnPointSport.Core.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessage = "please enter name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "please enter phone!")]
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
