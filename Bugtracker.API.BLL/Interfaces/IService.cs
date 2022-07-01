using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.BLL.Interfaces
{
    public interface IService<TKey, TDto>
    {
        IEnumerable<TDto> GetAll();
        TDto GetById(TKey id);
        //public TDto Insert(TDto dto);
        //public int Update(TKey id, TDto dto);
        //public bool Delete(TKey id);
    }
}
