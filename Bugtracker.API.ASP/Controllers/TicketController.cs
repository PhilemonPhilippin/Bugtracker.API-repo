using Bugtracker.API.ASP.ApiMappers;
using Bugtracker.API.ASP.ApiModels;
using Bugtracker.API.BLL.DataTransferObjects;
using Bugtracker.API.BLL.Interfaces;
using Bugtracker.API.BLL.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bugtracker.API.ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<TicketDto> tickets = _ticketService.GetAll();
            if (tickets.Count() == 0)
                return NotFound("Tickets list empty or not found.");
            else
                return Ok(tickets.Select(dto => dto.ToModel()));
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            TicketDto ticketDto = _ticketService.GetById(id);
            return (ticketDto is null) ? NotFound("Ticket id not found.") : Ok(ticketDto.ToModel());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Remove([FromRoute] int id)
        {
            bool isRemoved = _ticketService.Remove(id);
            return isRemoved ? NoContent() : NotFound("Ticket id not found.");
        }
        [HttpPut]
        public IActionResult Edit(TicketModel ticketModel)
        {
            try
            {
                bool isEdited = _ticketService.Edit(ticketModel.ToDto());
                return isEdited ? NoContent() : NotFound("Ticket id not found.");
            }
            catch (TicketException exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpPost]
        public IActionResult Add(TicketModel ticketModel)
        {
            try
            {
                int idTicket = _ticketService.Add(ticketModel.ToDto());
                ticketModel.IdTicket = idTicket;
                return new CreatedResult("/api/Ticket", ticketModel);
            }
            catch (TicketException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
