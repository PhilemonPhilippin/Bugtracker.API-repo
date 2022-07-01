using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.DAL.Interfaces
{
    public interface IRepository<TKey, TEntity>
    {
        //TKey Insert(TEntity entity);
        IEnumerable<TEntity> GetAll();
        //int Update(TKey id, TEntity entity);
        //bool Delete(TKey id);
    }
}
