using Bugtracker.API.BLL.DataTransferObjects;
using Bugtracker.API.DAL.Entities;

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
