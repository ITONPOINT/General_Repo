using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Domain;

namespace OnPointSport.Core.Interfaces
{
    public interface IEmployeeRepository: IEntityRepository<Employee>
    {
        Employee GetByCode(string code);
        List<Core.Models.Employee> GetEmployees();

    }
}
