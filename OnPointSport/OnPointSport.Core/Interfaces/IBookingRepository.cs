using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Domain;

namespace OnPointSport.Core.Interfaces
{
    public interface IBookingRepository: IEntityRepository<Booking>
    {
        Booking GetByCode(string code);
        List<Core.Models.Booking> GetBookings();
        List<Core.Models.Booking> GetFullBookings(List<Core.Models.Booking> booking, ICustomerRepository customerRepository);
    }
}
