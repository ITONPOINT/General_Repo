using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Domain;

namespace OnPointSport.Core.Interfaces
{
    public interface ISaleReposity: IEntityRepository<Sale>
    {
        Sale GetByCode(string code);
        List<Core.Models.Sale> GetSales();
        List<Core.Models.Sale> GetFullSales(List<Core.Models.Sale> sales, ICustomerRepository customerRepository, IDiscountRepository discountRepository);

    }
}
