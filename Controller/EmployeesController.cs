using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.DTO;
using EmployeeService.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;//DI

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService=employeeService;            
        }

        [HttpGet]
        public  ActionResult<EmployeeDTO> GetEmployees()
        {
            var employes= _employeeService.GetEmployees();
            return Ok(employes);
        }
        [HttpGet("{id}")]
        public  ActionResult<EmployeeDTO> GetEmployee(int id)
        {
            var employee= _employeeService.GetEmployeeById(id);
            if(employee==null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public  ActionResult<EmployeeDTO> PostEmployee(EmployeeDTO employeeDTO)
        {
           var createdEmployee =  _employeeService.CreateEmployee(employeeDTO);
            return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId }, createdEmployee);
        }

        [HttpPut("{id}")]
        public  IActionResult PutEmployee(int id, EmployeeDTO employeeDTO)
        {
            var result= _employeeService.UpdateEmployee(id,employeeDTO);
            if(!result) return BadRequest("Employee not found or not updated!");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public  IActionResult DeleteEmployee(int id)
        {
            var result= _employeeService.DeleteEmployee(id);
            if(!result) return NotFound();

            return NoContent();
        }
    }
}