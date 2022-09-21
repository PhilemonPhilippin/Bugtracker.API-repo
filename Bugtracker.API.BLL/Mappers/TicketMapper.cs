using Bugtracker.API.BLL.DataTransferObjects;
using Bugtracker.API.DAL.Entities;

namespace Bugtracker.API.BLL.Mappers
{
    internal static class TicketMapper
    {
        public static TicketDto ToDto(this TicketEntity entity)
        {
            return new TicketDto()
            {
                IdTicket = entity.IdTicket,
                Title = entity.Title,
                Status = entity.Status,
                Priority = entity.Priority,
                Type = entity.Type,
                Description = entity.Description,
                SubmitTime = entity.SubmitTime,
                SubmitMember = entity.SubmitMember,
                AssignedMember = entity.AssignedMember,
                Project = entity.Project,
            };
        }
        public static TicketEntity ToEntity(this TicketDto dto)
        {
            return new TicketEntity()
            {
                IdTicket = dto.IdTicket,
                Title = dto.Title,
                Status = dto.Status,
                Priority = dto.Priority,
                Type = dto.Type,
                Description = dto.Description,
                SubmitTime = dto.SubmitTime,
                SubmitMember = dto.SubmitMember,
                AssignedMember = dto.AssignedMember,
                Project = dto.Project,
            };
        }
    }
}
