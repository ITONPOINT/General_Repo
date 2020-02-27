using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Interfaces;

namespace OnPointSport.Data.DataAccess
{
    public class SalaryRepository: EntityRepository<Core.Domain.Salary>, ISalaryRepository
    {
        public SalaryRepository(OnPointSportDbContext context) : base(context) { }
        public Core.Domain.Salary GetByCode(string code)
        {
            return dbset.Where(x => x.Code == code).FirstOrDefault();
        }
        public List<Core.Models.Salary> GetSalaries()
        {
            return dbset.Select(p => new Core.Models.Salary
            {
                Id = p.Id,
                Code = p.Code,
                EmployeeCode = p.EmployeeCode,
                BasicSalary = p.BasicSalary,
                Active = p.Active,
                Description = p.Description
            }).ToList();
        }
        public List<Core.Models.Salary> GetFullSalaries(List<Core.Models.Salary> salary, IEmployeeRepository employeeRepository)
        {
            return salary.Select(p => new Core.Models.Salary
            {
                Id = p.Id,
                Code = p.Code,
                EmployeeCode = p.EmployeeCode,
                EmployeeName = employeeRepository.GetByCode(p.EmployeeCode).Name,
                BasicSalary = p.BasicSalary,
                Active = p.Active,
                Description = p.Description
            }).ToList();
        }
    }
}
