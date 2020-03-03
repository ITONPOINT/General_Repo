using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Interfaces;

namespace OnPointSport.Data.DataAccess
{
    public class EmployeeRepository: EntityRepository<Core.Domain.Employee>, IEmployeeRepository
    {
        public EmployeeRepository(OnPointSportDbContext context) : base(context) { }

        public Core.Domain.Employee GetByCode(string code)
        {
            return dbset.Where(x => x.Code == code).FirstOrDefault();
        }
        public List<Core.Models.Employee> GetEmployees()
        {
            return dbset.Select(p => new Core.Models.Employee
            {
                Id = p.Id,
                Code = p.Code,
                IdCard = p.IdCard,
                Name = p.Name,
                Gender = p.Gender,
                GenderName = p.Gender == true ? "Male" : "Female",
                DateOfBirth = p.DateOfBirth,
                Phone = p.Phone,
                Email = p.Email,
                Address = p.Address,
                Active = p.Active,
                Description = p.Description

            }).ToList();
        }
    }
}
