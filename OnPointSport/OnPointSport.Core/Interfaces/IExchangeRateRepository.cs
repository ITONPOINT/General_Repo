using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Domain;

namespace OnPointSport.Core.Interfaces
{
    public interface IExchangeRateRepository: IEntityRepository<ExchangeRate>
    {
        ExchangeRate GetByCode(string code);
        List<Core.Models.ExchangeRate> GetExchangeRates();
    }
}
