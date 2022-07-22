using Bugtracker.API.BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.BLL.Interfaces
{
    public interface IAssignService
    {
        int Add(int projectId, int memberId);
        bool Remove(int projectId, int memberId);
        IEnumerable<AssignDto> GetAll();
        AssignDto Get(int projectId, int memberId);
    }
}
