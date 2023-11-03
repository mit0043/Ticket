using Ticket_Web.Modal;

namespace Ticket_Web.Repository.IRepository
{
    public interface IDepartmentRepository
    {
        ICollection<Department> GetALLDepartment();

        Department GetDepartment(int departmentId);

        bool DepartmentExist(int departmentId);

        bool DepartmentNameExist(string departmentName);

        bool CreateDepartment(Department department);

        bool UpdateDepartment(Department department);

        bool DeleteDepartment(Department department);

        bool Save();


    }
}
