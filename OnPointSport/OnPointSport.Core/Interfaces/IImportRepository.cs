using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Domain;

namespace OnPointSport.Core.Interfaces
{
    public interface IImportRepository: IEntityRepository<Import>
    {
        Import GetByCode(string code);
        List<Core.Models.Import> GetImports();
        List<Core.Models.Import> GetFullImports(List<Core.Models.Import> imports, ISupplierRepository supplierRepository, IDiscountRepository discountRepository);

    }
}
