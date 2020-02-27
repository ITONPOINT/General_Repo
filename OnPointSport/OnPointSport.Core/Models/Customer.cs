using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnPointSport.Core.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessage = "Please Input Customer Name")]
        public string Name { get; set; }
        public Boolean Gender { get; set; }
        public string GenderName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }

    }
}
