using Microsoft.EntityFrameworkCore;
using Ticket_Web.Data;
using Ticket_Web.Modal;
using Ticket_Web.Repository.IRepository;

namespace Ticket_Web.Repository
{
    public class TicketBookRepository : ITicketBookRepository
    {
        private readonly ApplicationDbContext _Context;
        public TicketBookRepository(ApplicationDbContext context)
        {
            _Context = context;
        }

        public bool BookingIdExist(int bookingId)
        {
            return _Context.TicketBooks.Any(book => book.iBookingId == bookingId);
        }

        public bool CreateBooking(TicketBook ticketBook)
        {
            _Context.TicketBooks.Add(ticketBook);
            return Save();
        }

        public bool DeleteBooking(TicketBook ticketBook)
        {
            _Context.TicketBooks.Remove(ticketBook);
            return Save();
        }

        public ICollection<TicketBook> GetAlltBooking()
        {
            return _Context.TicketBooks.Include(book=>book.User).Include(book=>book.Ticket).ToList();
        }

        public TicketBook GetBooking(int bookingId)
        {
            return _Context.TicketBooks.Find(bookingId);
        }

        public bool Save()
        {
            return _Context.SaveChanges() == 1 ? true : false;
        }

        public bool UpdateBooking(TicketBook ticketBook)
        {
            _Context.TicketBooks.Update(ticketBook);
            return Save();
        }
    }
}
