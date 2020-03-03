using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Domain;

namespace OnPointSport.Core.Interfaces
{
    public interface ISalaryRepository: IEntityRepository<Salary>
    {
        Salary GetByCode(string code);
        List<Core.Models.Salary> GetSalaries();
        List<Core.Models.Salary> GetFullSalaries(List<Core.Models.Salary> salary, IEmployeeRepository employeeRepository);
    }
}
