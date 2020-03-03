using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnPointSport.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessage ="Please Input User Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Input Password")]
        public string Password { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
