using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Domain;

namespace OnPointSport.Core.Interfaces
{
    public interface IItemDetailRepository: IEntityRepository<ItemDetail>
    {
        ItemDetail GetByCode(string Code);
        List<Core.Models.ItemDetail> GetItemDetails();
        List<Core.Models.ItemDetail> GetFullItemDetails(List<Core.Models.ItemDetail> itemDetails, IProductServiceRepository productServiceRepository);
    }
}
