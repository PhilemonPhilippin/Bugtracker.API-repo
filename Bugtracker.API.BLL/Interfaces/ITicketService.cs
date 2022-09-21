using Bugtracker.API.BLL.DataTransferObjects;

namespace Bugtracker.API.BLL.Interfaces
{
    public interface ITicketService
    {
        bool Edit(TicketDto dto);
        IEnumerable<TicketDto> GetAll();
        TicketDto GetById(int id);
        int Add(TicketDto ticketDto);
        bool Remove(int id);
    }
}
