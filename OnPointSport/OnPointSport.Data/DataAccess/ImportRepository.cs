using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Interfaces;

namespace OnPointSport.Data.DataAccess
{
    public class ImportRepository: EntityRepository<Core.Domain.Import>, IImportRepository
    {
        public ImportRepository(OnPointSportDbContext context) : base(context) { }
        public Core.Domain.Import GetByCode(string code)
        {
            return dbset.Where(x => x.Code == code).FirstOrDefault();
        }
        public List<Core.Models.Import> GetImports()
        {
            return dbset.Select(p => new Core.Models.Import
            {
                Id = p.Id,
                Code = p.Code,
                SupplierCode = p.SupplierCode,
                DiscountCode = p.DiscountCode,
                TotalPrice = p.TotalPrice,
                Active = p.Active,
                Description = p.Description
            }).ToList();
        }
        public List<Core.Models.Import> GetFullImports(List<Core.Models.Import> imports, ISupplierRepository supplierRepository, IDiscountRepository discountRepository)
        {
            return dbset.Select(p => new Core.Models.Import
            {
                Id = p.Id,
                Code = p.Code,
                SupplierCode = p.SupplierCode,
                DiscountCode = p.DiscountCode,
                TotalPrice = p.TotalPrice,
                Active = p.Active,
                Description = p.Description
            }).ToList();
        }
    }
}
