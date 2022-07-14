using Bugtracker.API.BLL.DataTransferObjects;
using Bugtracker.API.BLL.Interfaces;
using Bugtracker.API.BLL.Mappers;
using Bugtracker.API.BLL.Tools;
using Bugtracker.API.DAL.Entities;
using Bugtracker.API.DAL.Interfaces;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.BLL.Services
{
    public class TicketService : ITicketService, IService<int, TicketDto>
{
        private ITicketRepository _ticketRepository;

        public TicketService (ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public IEnumerable<TicketDto> GetAll()
        {
            return _ticketRepository.GetAll().Select(ticket => ticket.ToDto());
        }
        public TicketDto GetById(int id)
        {
            TicketEntity entity = _ticketRepository.GetById(id);
            if (entity is null)
                return null;
            else
                return entity.ToDto();
        }
        public int Add(TicketDto ticketDto)
        {
            bool titleExist = _ticketRepository.TicketTitleExist(ticketDto.Title);
            if (titleExist)
                throw new TicketException("Title already exists.");
            else
                return _ticketRepository.Add(ticketDto.ToEntity());
        }
        public bool Remove(int id)
        {
            return _ticketRepository.Remove(id);
        }
        public bool Edit(TicketDto ticketDto)
        {
            bool titleExist = _ticketRepository.TicketTitleExist(ticketDto.Title);
            if (titleExist)
                throw new TicketException("Title already exists.");
            else
                return _ticketRepository.Edit(ticketDto.ToEntity());
        }
    }
}
