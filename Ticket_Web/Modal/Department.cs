using System.ComponentModel.DataAnnotations;

namespace Ticket_Web.Modal
{
    public class Department
    {
        [Key]
        public int iDepartmentId { get; set; }
        public String vDepartmentName { get; set; }
    }
}
