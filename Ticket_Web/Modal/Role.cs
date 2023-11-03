using System.ComponentModel.DataAnnotations;

namespace Ticket_Web.Modal
{
    public class Role
    {
        [Key]
        public int iRoleId { get; set; }
        public String vRoleName { get; set; }
    }
}
