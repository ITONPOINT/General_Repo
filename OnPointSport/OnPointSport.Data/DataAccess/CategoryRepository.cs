using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Interfaces;

namespace OnPointSport.Data.DataAccess
{
    public class CategoryRepository: EntityRepository<Core.Domain.Category>, ICategoryRepository
    {
        public CategoryRepository(OnPointSportDbContext context) : base(context) { }

        public Core.Domain.Category GetByCode(string code)
        {
            return dbset.Where(x => x.Code == code).FirstOrDefault();
        }
        public List<Core.Models.Category> GetCategories()
        {
            return dbset.Select(p => new Core.Models.Category
            {
                Id = p.Id,
                Code = p.Code,
                Name = p.Name,
                Active = p.Active,
                Description = p.Description

            }).ToList();
        }
    }
}
