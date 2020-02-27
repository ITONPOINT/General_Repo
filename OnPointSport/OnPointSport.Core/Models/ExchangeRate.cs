using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnPointSport.Core.Models
{
    public class ExchangeRate
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessage = "Please Input Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Input Amount")]
        public float FromAmount { get; set; }
        [Required(ErrorMessage = "Please Input Amount")]
        public float ToAmount { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
