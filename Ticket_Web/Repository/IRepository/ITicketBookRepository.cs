using Ticket_Web.Modal;

namespace Ticket_Web.Repository.IRepository
{
    public interface ITicketBookRepository
    {
        ICollection<TicketBook> GetAlltBooking();

        TicketBook GetBooking(int bookingId);

        bool BookingIdExist(int bookingId);

        bool CreateBooking(TicketBook ticketBook);

        bool UpdateBooking(TicketBook ticketBook);    

        bool DeleteBooking(TicketBook ticketBook);

        bool Save();
    }
}
