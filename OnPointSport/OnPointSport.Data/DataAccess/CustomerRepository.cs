using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Interfaces;

namespace OnPointSport.Data.DataAccess
{
    public class CustomerRepository: EntityRepository<Core.Domain.Customer>, ICustomerRepository
    {
        public CustomerRepository(OnPointSportDbContext context) : base(context) { }

        public Core.Domain.Customer GetByCode(string code)
        {
            return dbset.Where(x => x.Code == code).FirstOrDefault();
        }
        public List<Core.Models.Customer> GetCustomers()
        {
            return dbset.Select(p => new Core.Models.Customer
            {
                Id = p.Id,
                Code = p.Code,
                Name = p.Name,
                Gender = p.Gender,
                GenderName = p.Gender == true ? "Male" : "Female",
                Phone = p.Phone,
                Email = p.Email,
                Address = p.Address,
                Active = p.Active,
                Description = p.Description

            }).ToList();
        }
    }
}
