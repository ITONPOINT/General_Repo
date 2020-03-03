using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Interfaces;

namespace OnPointSport.Data.DataAccess
{
    public class ProductServiceRepository: EntityRepository<Core.Domain.ProductService>, IProductServiceRepository
    {
        public ProductServiceRepository(OnPointSportDbContext context) : base(context) { }

        public Core.Domain.ProductService GetByCode(string code)
        {
            return dbset.Where(x => x.Code == code).FirstOrDefault();
        }
        public List<Core.Models.ProductService> GetProductServices()
        {
            return dbset.Select(p => new Core.Models.ProductService
            {
            Id = p.Id,           
            Name = p.Name,
            Code = p.Code,
            CategoryCode = p.CategoryCode,
            Quantity = p.Quantity,
            Price = p.Price,
            Active = p.Active,
            Description = p.Description
            }).ToList();
        }

        public List<Core.Models.ProductService> GetFullProductServices(List<Core.Models.ProductService> productService, ICategoryRepository categoryRepository)
        {
            return productService.Select(p => new Core.Models.ProductService
            {
                Id = p.Id,
                Name = p.Name,
                Code = p.Code,
                CategoryCode = p.CategoryCode,
                Quantity = p.Quantity,
                Price = p.Price,
                CategoryName = categoryRepository.GetByCode(p.CategoryCode).Name,
                Active = p.Active,
                Description = p.Description
            }).ToList();
        }
    }
}
