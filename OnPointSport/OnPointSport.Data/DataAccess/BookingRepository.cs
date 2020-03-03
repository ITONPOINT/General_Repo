using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Interfaces;

namespace OnPointSport.Data.DataAccess
{
    public class BookingRepository: EntityRepository<Core.Domain.Booking>, IBookingRepository
    {
        public BookingRepository(OnPointSportDbContext context): base(context) { }
        public Core.Domain.Booking GetByCode(string code)
        {
            return dbset.Where(x => x.Code == code).FirstOrDefault();
        }
        public List<Core.Models.Booking> GetBookings()
        {
            return dbset.Select(p => new Core.Models.Booking
            {
                Id = p.Id,
                Code = p.Code,
                CustomerCode = p.CustomerCode,
                BookingDate = p.BookingDate,
                BookingDebutTime = p.BookingDebutTime,
                BookingFinTime = p.BookingFinTime,
                Active = p.Active,
                Description = p.Description
            }).ToList();
        }
        public List<Core.Models.Booking> GetFullBookings(List<Core.Models.Booking> booking, ICustomerRepository customerRepository)
        {
            return dbset.Select(p => new Core.Models.Booking
            {
                Id = p.Id,
                Code = p.Code,
                CustomerCode = p.CustomerCode,
                BookingDate = p.BookingDate,
                BookingDebutTime = p.BookingDebutTime,
                BookingFinTime = p.BookingFinTime,
                Active = p.Active,
                Description = p.Description
            }).ToList();
        }
    }
}
