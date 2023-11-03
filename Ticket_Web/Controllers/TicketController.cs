using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Ticket_Web.Data;
using Ticket_Web.Modal;
using Ticket_Web.Repository.IRepository;

namespace Ticket_Web.Controllers
{
    [Route("api/Ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _TicketRespository;
        private readonly ApplicationDbContext _Context;
        public TicketController(ITicketRepository ticketRepository, ApplicationDbContext context)
        {
            _TicketRespository = ticketRepository;
            _Context = context;
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetAllTicket()
        {
            return Ok(_TicketRespository.GetAllTicket().ToList());
        }

        [HttpPost]
        public IActionResult InsertTicket([FromBody] Ticket ticket)
        {
            if (ticket == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest();

            _TicketRespository.CreateTicket(ticket);

            return Ok();
        }

        [HttpPut]
        [Route("UpdateTicket/{iTicketId}")]
        public IActionResult UpdateTicket([FromBody] Ticket ticket)
        {
            if (ticket == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest();

            _TicketRespository.UpdateTicket(ticket);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteTicket(int id)
        {
            var ticketDB = _TicketRespository.GetTicket(id);
            if (ticketDB == null) return NotFound();

            _TicketRespository.DeleteTicket(ticketDB);

            return Ok();
        }

        [HttpPut("Plus")]
        public IActionResult Plus([FromBody] Ticket ticket, int id)
        {
            if (id != ticket.iTicketId) return NotFound();

            var TicketDB = _Context.Tickets.Where(t => t.iTicketId==id).FirstOrDefault();
            TicketDB.iCount += 1;
            _Context.Tickets.Update(TicketDB);
            _Context.SaveChanges();

            return Ok();
        }
    }
}
