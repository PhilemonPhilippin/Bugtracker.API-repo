using Bugtracker.API.BLL.DataTransferObjects;
using Bugtracker.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.BLL.Mappers
{
    internal static class AssignMapper
    {
        public static AssignDto ToDto(this AssignEntity entity)
        {
            return new AssignDto()
            {
                IdAssign = entity.IdAssign,
                AssignTime = entity.AssignTime,
                Project = entity.Project,
                Member = entity.Member
            };
        }
    }
}
