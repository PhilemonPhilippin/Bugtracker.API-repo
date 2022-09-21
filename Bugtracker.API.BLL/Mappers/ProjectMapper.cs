using Bugtracker.API.BLL.DataTransferObjects;
using Bugtracker.API.DAL.Entities;

namespace Bugtracker.API.BLL.Mappers
{
    internal static class ProjectMapper
    {
        public static ProjectDto ToDto(this ProjectEntity entity)
        {
            return new ProjectDto()
            {
                IdProject = entity.IdProject,
                Name = entity.Name,
                Description = entity.Description,
                Manager = entity.Manager,
                Disabled = entity.Disabled,
            };
        }
        public static ProjectEntity ToEntity(this ProjectDto dto)
        {
            return new ProjectEntity()
            {
                IdProject = dto.IdProject,
                Name = dto.Name,
                Description = dto.Description,
                Manager = dto.Manager,
                Disabled = dto.Disabled,
            };
        }
    }
}
