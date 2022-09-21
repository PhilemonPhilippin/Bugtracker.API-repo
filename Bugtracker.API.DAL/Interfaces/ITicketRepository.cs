using Bugtracker.API.DAL.Entities;

namespace Bugtracker.API.DAL.Interfaces
{
    public interface ITicketRepository
    {
        bool TicketTitleExist(string title);
        bool TicketTitleExistWithId(string title, int id);
        IEnumerable<TicketEntity> GetAll();
        TicketEntity GetById(int id);
        int Add(TicketEntity entity);
        bool Remove(int id);
        bool Edit(TicketEntity entity);
    }
}
