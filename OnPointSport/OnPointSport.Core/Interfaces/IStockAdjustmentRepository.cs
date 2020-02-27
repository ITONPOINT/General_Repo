using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Domain;

namespace OnPointSport.Core.Interfaces
{
    public interface IStockAdjustmentRepository:IEntityRepository<StockAdjustment>
    {
        StockAdjustment GetByCode(string code);
        List<Core.Models.StockAdjustment> GetStockAdjustments();
        List<Core.Models.StockAdjustment> GetFullStockAdjustments(List<Core.Models.StockAdjustment> stockAdjustment, IProductServiceRepository productServiceRepository);
    }
}
