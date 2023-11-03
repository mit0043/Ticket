using Ticket_Web.Modal;

namespace Ticket_Web.Repository.IRepository
{
    public interface ITicketRepository
    {
        ICollection<Ticket> GetAllTicket();

        Ticket GetTicket(int ticketId);

        bool TicketIdExist(int ticketId);

        bool TickeNameExist(string ticketName);
        bool CreateTicket(Ticket ticket);
        bool UpdateTicket(Ticket ticket);
        bool DeleteTicket(Ticket ticket);
        bool Save();



    }
}
