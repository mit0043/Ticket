using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticket_Web.Modal
{
    public class User
    {
        [Key]
        public int iUserId { get; set; }

        public string vUserName { get; set; }

        public string vAddress { get; set; }

        public string vEmail { get; set; }

        public string vPassword { get; set; }

        public DateTime dRegistrationDate { get; set; }

        public DateTime dExpireDate { get; set; }

        public DateTime dRefreshDate { get; set; }

        public int iDepartmentId { get; set; }

        [ForeignKey("iDepartmentId")]
        public Department? Department { get; set; }

        public int iRoleId { get; set; }

        [ForeignKey("iRoleId")]
        public Role? Role { get; set; }

        [NotMapped]
        public string Token { get; set; }
    }
}
