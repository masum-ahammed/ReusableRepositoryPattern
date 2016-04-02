using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepository
    {
        int SaveEntity(IEntity entity);
        T GetById<T>(int id) where T : class;
        void DeleteEntity(IEntity entity);


    }
}
