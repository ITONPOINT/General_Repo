using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Interfaces;

namespace OnPointSport.Data.DataAccess
{
    public class ExchangeRateRepository: EntityRepository<Core.Domain.ExchangeRate>, IExchangeRateRepository
    {
        public ExchangeRateRepository(OnPointSportDbContext context): base(context) { }
        public Core.Domain.ExchangeRate GetByCode(string code)
        {
            return dbset.Where(x => x.Code == code).FirstOrDefault();
        }
        public List<Core.Models.ExchangeRate> GetExchangeRates()
        {
            return dbset.Select(p => new Core.Models.ExchangeRate
            {
                Id = p.Id,
                Code = p.Code,
                Name = p.Name,
                FromAmount = p.FromAmount,
                ToAmount = p.ToAmount,
                Active = p.Active,
                Description = p.Description
            }).ToList();
        }
    }
}
