using Bugtracker.API.BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
