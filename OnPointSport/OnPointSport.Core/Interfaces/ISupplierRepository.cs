using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Domain;

namespace OnPointSport.Core.Interfaces
{
    public interface ISupplierRepository: IEntityRepository<Supplier>
    {
        Supplier GetByCode(string code);
        List<Core.Models.Supplier> GetSuppliers();
    }
}
