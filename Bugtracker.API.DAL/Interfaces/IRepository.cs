using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.DAL.Interfaces
{
    public interface IRepository<TKey, TEntity>
    {
        TKey Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TKey id);
        bool Edit(TKey id, TEntity entity);
        bool Remove(TKey id);
    }
}
