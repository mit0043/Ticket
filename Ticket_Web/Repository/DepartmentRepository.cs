using Ticket_Web.Data;
using Ticket_Web.Modal;
using Ticket_Web.Repository.IRepository;

namespace Ticket_Web.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _Context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _Context = context;
        }

        public bool CreateDepartment(Department department)
        {
            _Context.Departments.Add(department);
            return Save();
        }

        public bool DeleteDepartment(Department department)
        {
            _Context.Departments.Remove(department);
            return Save();
        }

        public bool DepartmentExist(int departmentId)
        {
            return _Context.Departments.Any(d => d.iDepartmentId == departmentId);
        }

        public bool DepartmentNameExist(string departmentName)
        {
            return _Context.Departments.Any(d => d.vDepartmentName == departmentName);
        }

        public ICollection<Department> GetALLDepartment()
        {
            return _Context.Departments.ToList();
        }

        public Department GetDepartment(int departmentId)
        {
            return _Context.Departments.Find(departmentId);
        }

        public bool Save()
        {
            return _Context.SaveChanges() == 1 ? true : false;
        }

        public bool UpdateDepartment(Department department)
        {
            _Context.Departments.Update(department);
            return Save();
        }
    }
}
