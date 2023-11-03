using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticket_Web.Modal
{
    public class Ticket
    {
        [Key]
        public int iTicketId { get; set; }
        public string vTicketName { get; set; }
        public int iCount { get; set; }
        public string vImage { get; set; }
        [NotMapped]
        public IFormFile Files { get; set; }
    }
}
