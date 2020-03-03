using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Interfaces;

namespace OnPointSport.Data.DataAccess
{
    public class SupplierRepository: EntityRepository<Core.Domain.Supplier>, ISupplierRepository
    {
        public SupplierRepository(OnPointSportDbContext context) : base(context) { }
        public Core.Domain.Supplier GetByCode(string code)
        {
            return dbset.Where(x => x.Code == code).FirstOrDefault();
        }
        public List<Core.Models.Supplier> GetSuppliers()
        {
            return dbset.Select(p => new Core.Models.Supplier
            {
                Id = p.Id,
                Code = p.Code,
                Name = p.Name,
                Phone = p.Phone,
                Phone2 = p.Phone2,
                Email = p.Email,
                Address = p.Address,
                Active = p.Active,
                Description = p.Description
            }).ToList();
        }
    }
}
