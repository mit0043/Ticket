using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticket_Web.Modal
{
    public class TicketBook
    {
        [Key]
        public int iBookingId { get; set; }

        public int iUserId { get; set; }
        
        [ForeignKey("iUserId")]
        public User? User { get; set; }

        public int iTicketId { get; set; }

        [ForeignKey("iTicketId")]
        public Ticket? Ticket { get; set; }
        public int iCount { get; set; }
    }
}
