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
        TKey Add(TDto dto);
        bool Remove(TKey id);
        bool Edit(TKey id, TDto dto);
    }
}
