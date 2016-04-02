using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DataAccess
{
    abstract public class BaseEFRepository<TContext>
        where TContext : DbContext, new()
    {
        protected DbContext _BaseDataContext;
        public BaseEFRepository()
        {
            _BaseDataContext = new TContext();
            _BaseDataContext.Database.Connection.ConnectionString = BrandShareConfigurations.GlobalDatabaseConnectionString;
            _BaseDataContext.Configuration.ProxyCreationEnabled = false;
            _BaseDataContext.Configuration.LazyLoadingEnabled = false;
        }


        public int SaveEntity(IEntity entity)
        {
            _BaseDataContext.Entry(entity).State = entity.Id > 0 ? EntityState.Modified : EntityState.Added;
            _BaseDataContext.SaveChanges();
            return entity.Id;

        }
       

        public T GetById<T>(int id) where T : class
        {
            return _BaseDataContext.Set<T>().Find(id);

        }

        public void DeleteEntity(IEntity entity)
        {
            _BaseDataContext.Entry(entity).State = EntityState.Deleted;
            _BaseDataContext.SaveChanges();
        }
    }
}
