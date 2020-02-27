using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Domain;

namespace OnPointSport.Core.Interfaces
{
    public interface ICustomerRepository: IEntityRepository<Customer>
    {
        Customer GetByCode(string code);
        List<Core.Models.Customer> GetCustomers();
    }
}
