using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnPointSport.Core.Domain;
using OnPointSport.Core.Interfaces;
using System.Data.Entity;

namespace OnPointSport.Data.DataAccess
{
    public class EntityRepository<T> : IEntityRepository<T> where T : Entity
    {
        protected OnPointSportDbContext context;
        protected IDbSet<T> dbset;

        public EntityRepository(OnPointSportDbContext context)
        {
            this.context = context;
            this.dbset = context.Set<T>();
        }

        public virtual T Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            dbset.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            dbset.Remove(entity);
            context.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var entity = dbset.Find(id);

            if (entity != null)
            {
                Delete(entity);
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.AsEnumerable<T>();
        }

        public virtual T GetById(int id)
        {
            return dbset.Find(id);
        }
        // Todo: Save data & Update
        public virtual T Save(T entity)
        {
            if (entity.Id == 0)
            {
                return Create(entity);
            }
            else
            {
                return Update(entity);
            }
        }

        public virtual T Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }
    }
}
