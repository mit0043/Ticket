using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using Ticket_Web.Modal;
using Ticket_Web.Repository.IRepository;

namespace Ticket_Web.Controllers
{
    [Route("api/TicketBook")]
    [ApiController]
    public class TicketBookController : ControllerBase
    {
        private readonly ITicketBookRepository _BookRepository;

        public TicketBookController(ITicketBookRepository bookRepository)
        {
            _BookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult GetALLBooking()
        {
            return Ok(_BookRepository.GetAlltBooking().ToList());
        }
        [HttpPost]
        public IActionResult InsertBooking([FromBody] TicketBook ticketBook)
        {
            if (ticketBook == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest();

            _BookRepository.CreateBooking(ticketBook);
            return Ok();

        }
        [HttpPut]
        [Route("UpdateBooking/{iBookingId}")]
        public IActionResult UpdateBooking([FromBody] TicketBook ticketBook)
        {
            if (ticketBook == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest();

            _BookRepository.UpdateBooking(ticketBook);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteBooking(int id)
        { 
            var BookingInDb=_BookRepository.GetBooking(id);
            if(BookingInDb==null) return NotFound();

            _BookRepository.DeleteBooking(BookingInDb);
            return Ok();
        }
    }
}
