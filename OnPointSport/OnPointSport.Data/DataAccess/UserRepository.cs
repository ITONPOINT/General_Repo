using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Interfaces;

namespace OnPointSport.Data.DataAccess
{
    public class UserRepository: EntityRepository<Core.Domain.User>, IUserRepository
    {
        public UserRepository(OnPointSportDbContext context) : base(context) { }

        public Core.Domain.User GetByCode(string code)
        {
            return dbset.Where(x => x.Code == code).FirstOrDefault();
        }
        public List<Core.Models.User> GetUsers()
        {
            return dbset.Select(p => new Core.Models.User
            {
                Id = p.Id,
                Code = p.Code,
                Name = p.Name,
                Password = p.Password,
                Active = p.Active,
                Description = p.Description

            }).ToList();
        }
    }
}
