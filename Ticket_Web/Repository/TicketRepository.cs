using Ticket_Web.Data;
using Ticket_Web.Modal;
using Ticket_Web.Repository.IRepository;

namespace Ticket_Web.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _Context;
        public TicketRepository(ApplicationDbContext context)
        {
            _Context = context;
        }

        public bool CreateTicket(Ticket ticket)
        {
            _Context.Tickets.Add(ticket);
            return Save();
        }

        public bool DeleteTicket(Ticket ticket)
        {
            _Context.Tickets.Remove(ticket);
            return Save();
        }

        public ICollection<Ticket> GetAllTicket()
        {
            return _Context.Tickets.ToList();
        }

        public Ticket GetTicket(int ticketId)
        {
            return _Context.Tickets.Find(ticketId);
        }

        public bool Save()
        {
           return _Context.SaveChanges() == 1 ? true : false;
        }

        public bool TickeNameExist(string ticketName)
        {
            return _Context.Tickets.Any(t => t.vTicketName == ticketName);
        }

        public bool TicketIdExist(int ticketId)
        {
            return _Context.Tickets.Any(T => T.iTicketId == ticketId);
        }

        public bool UpdateTicket(Ticket ticket)
        {
             _Context.Tickets.Update(ticket);
            return Save();
        }
    }
}
