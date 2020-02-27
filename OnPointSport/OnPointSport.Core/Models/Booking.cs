using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnPointSport.Core.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Please Input Date")]
        public DateTime BookingDate { get; set; }
        [Required(ErrorMessage = "Please Input Date")]
        public DateTime BookingDebutTime { get; set; }
        [Required(ErrorMessage = "Please Input Date")]
        public DateTime BookingFinTime { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
    }
}
