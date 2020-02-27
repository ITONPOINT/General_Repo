using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Domain;

namespace OnPointSport.Core.Interfaces
{
    public interface IEntityRepository<T> where T : Entity
    {
        T Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        T Update(T entity);
        T GetById(int id);
        void Delete(int id);
        T Save(T entity);
    }
}
