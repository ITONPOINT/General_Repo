using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Interfaces;

namespace OnPointSport.Data.DataAccess
{
    public class SaleRepository: EntityRepository<Core.Domain.Sale>, ISaleReposity
    {
        public SaleRepository(OnPointSportDbContext context) : base(context) { }
        public Core.Domain.Sale GetByCode(string code)
        {
            return dbset.Where(x => x.Code == code).FirstOrDefault();
        }
        public List<Core.Models.Sale> GetSales()
        {
            return dbset.Select(p => new Core.Models.Sale
            {
                Id = p.Id,
                Code = p.Code,
                CustomerCode = p.CustomerCode,
                DiscountCode = p.DiscountCode,
                TotalPrice = p.TotalPrice,
                Active = p.Active,
                Description = p.Description
            }).ToList();
        }
        public List<Core.Models.Sale> GetFullSales(List<Core.Models.Sale> sales, ICustomerRepository customerRepository, IDiscountRepository discountRepository)
        {
            return sales.Select(p => new Core.Models.Sale
            {
                Id = p.Id,
                Code = p.Code,
                CustomerCode = p.CustomerCode,
                CustomerName = customerRepository.GetByCode(p.CustomerCode).Name,
                DiscountCode = p.DiscountCode,
                DiscountName = discountRepository.GetByCode(p.DiscountCode).Name,
                TotalPrice = p.TotalPrice,
                Active = p.Active,
                Description = p.Description
            }).ToList();
        }
    }
}
