using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Interfaces;
using OnPointSport.Core.Models;

namespace OnPointSport.Data.DataAccess
{
    public class ItemDetailRepository: EntityRepository<Core.Domain.ItemDetail>, IItemDetailRepository
    {
        public ItemDetailRepository(OnPointSportDbContext context) : base(context) { }

        public Core.Domain.ItemDetail GetByCode(string code)
        {
            return dbset.Where(x => x.Code == code).FirstOrDefault();
        }

        public List<ItemDetail> GetItemDetails()
        {
            return dbset.Select(p => new ItemDetail
            {
                Id = p.Id,
                Code = p.Code,
                SaleCode = p.SaleCode,
                ProductServiceCode = p.ProductServiceCode,
                Quantity = p.Quantity,
                UnitPrice = p.UnitPrice,
                SubTotalPrice = p.SubTotalPrice,
                Active = p.Active,
                Description = p.Description
            }).ToList();
        }

        public List<ItemDetail> GetFullItemDetails(List<Core.Models.ItemDetail> itemDetails, IProductServiceRepository productServiceRepository)
        {
            return dbset.Select(p => new ItemDetail
            {
                Id = p.Id,
                Code = p.Code,
                SaleCode = p.SaleCode,
                ProductServiceCode = p.ProductServiceCode,
                ProductServiceName = productServiceRepository.GetByCode(p.ProductServiceCode).Name,
                Quantity = p.Quantity,
                UnitPrice = p.UnitPrice,
                SubTotalPrice = p.SubTotalPrice,
                Active = p.Active,
                Description = p.Description
            }).ToList();
        }

    }
}
