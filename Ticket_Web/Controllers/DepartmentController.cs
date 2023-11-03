using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticket_Web.Data;
using Ticket_Web.Modal;
using Ticket_Web.Repository.IRepository;

namespace Ticket_Web.Controllers
{
    [Route("api/Department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _DepartmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _DepartmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult GetDepartment()
        {
            //return Ok(_Context.Departments.ToList());

            return Ok(_DepartmentRepository.GetALLDepartment().ToList());
        }

        [HttpPost]
        public IActionResult InsertDepartment([FromBody] Department department)
        {
            if (department == null) return NotFound();
            if(!ModelState.IsValid) return BadRequest();

            //_Context.Departments.Add(department);
            //_Context.SaveChanges();

            _DepartmentRepository.CreateDepartment(department);

            return Ok();
        }

        [HttpPut]
        [Route("UpdateDepartment/{iDepartmentId}")]
        public IActionResult UpdateDepartment([FromBody] Department department)
        {
            if (department == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest();

            //_Context.Departments.Update(department);
            //_Context.SaveChanges();

            _DepartmentRepository.UpdateDepartment(department);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteDepartment(int id)
        {
            var departmentDB = _DepartmentRepository.GetDepartment(id);

            if (departmentDB == null) return NotFound();

            //_Context.Departments.Remove(departmentDB);
            //_Context.SaveChanges();

            _DepartmentRepository.DeleteDepartment(departmentDB);

            return Ok();
        }
    }

}
