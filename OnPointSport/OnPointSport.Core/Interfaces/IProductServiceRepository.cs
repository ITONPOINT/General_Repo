using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Domain;

namespace OnPointSport.Core.Interfaces
{
    public interface IProductServiceRepository: IEntityRepository<ProductService>
    {
        ProductService GetByCode(string code);
        List<Core.Models.ProductService> GetProductServices();
        List<Core.Models.ProductService> GetFullProductServices(List<Core.Models.ProductService> productService, ICategoryRepository categorieRepository);
    }
}
