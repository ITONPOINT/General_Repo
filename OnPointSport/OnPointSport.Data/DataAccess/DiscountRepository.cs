using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Interfaces;

namespace OnPointSport.Data.DataAccess
{
    public class DiscountRepository : EntityRepository<Core.Domain.Discount>, IDiscountRepository
    {
        public DiscountRepository(OnPointSportDbContext context) : base(context) { }
        public Core.Domain.Discount GetByCode(string code)
        {
            return dbset.Where(x => x.Code == code).FirstOrDefault();
        }
        public List<Core.Models.Discount> GetDiscounts()
        {
            return dbset.Select(p => new Core.Models.Discount
            {
                Id = p.Id,
                Code = p.Code,
                Name = p.Name,
                Debut = p.Debut,
                Fin = p.Fin,
                Rate = p.Rate,
                Active = p.Active,
                Description = p.Description
            }).ToList();
        }
    }
}
