using Bugtracker.API.ASP.ApiModels;
using Bugtracker.API.BLL.DataTransferObjects;
using System.Reflection;

namespace Bugtracker.API.ASP.ApiMappers
{
    internal static class TicketApiMapper
    {
        public static TicketDto ToDto(this TicketModel model)
        {
            return new TicketDto()
            {
                IdTicket = model.IdTicket,
                Title = model.Title,
                Status = model.Status,
                Priority = model.Priority,
                Type = model.Type,
                Description = model.Description,
                SubmitTime = model.SubmitTime,
                SubmitMember = model.SubmitMember,
                AssignedMember = model.AssignedMember,
                Project = model.Project,
            };
        }
        public static TicketModel ToModel(this TicketDto dto)
        {
            return new TicketModel()
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
