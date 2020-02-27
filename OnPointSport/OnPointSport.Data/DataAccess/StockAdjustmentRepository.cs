using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Interfaces;

namespace OnPointSport.Data.DataAccess
{
    public class StockAdjustmentRepository: EntityRepository<Core.Domain.StockAdjustment>, IStockAdjustmentRepository
    {
        public StockAdjustmentRepository(OnPointSportDbContext context) : base(context) { }
        public Core.Domain.StockAdjustment GetByCode(string code)
        {
            return dbset.Where(x => x.Code == code).FirstOrDefault();
        }
        public List<Core.Models.StockAdjustment> GetStockAdjustments()
        {
            return dbset.Select(p => new Core.Models.StockAdjustment
            {
                Id = p.Id,
                Code = p.Code,
                ProductServiceCode = p.ProductServiceCode,
                Quantity = p.Quantity,
                Active = p.Active,
                Description = p.Description
            }).ToList();
        }
        public List<Core.Models.StockAdjustment> GetFullStockAdjustments(List<Core.Models.StockAdjustment> stockAdjustments, IProductServiceRepository productServicesRepository)
        {
            return stockAdjustments.Select(p => new Core.Models.StockAdjustment
            {
                Id = p.Id,
                Code = p.Code,
                ProductServiceCode = p.ProductServiceCode,
                ProductServiceName = productServicesRepository.GetByCode(p.ProductServiceCode).Name,
                Quantity = p.Quantity,
                Active = p.Active,
                Description = p.Description
            }).ToList();
        }
    }
}
