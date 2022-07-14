using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.DAL.Interfaces
{
    public interface IAssignRepository
    {
        int Add(int projectId, int memberId);
        bool Remove(int assignId);
    }
}
