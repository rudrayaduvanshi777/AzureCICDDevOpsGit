using System;
using System.Threading.Tasks;
using EmployeeService.DTO;

namespace EmployeeService.Service
{
    public interface IEmployeeService
        {
            List<EmployeeDTO> GetEmployees();
            EmployeeDTO GetEmployeeById(int id);
            EmployeeDTO CreateEmployee(EmployeeDTO employeeDTO);
            bool UpdateEmployee(int id, EmployeeDTO employeeDTO);
            bool DeleteEmployee(int id);
        }
}