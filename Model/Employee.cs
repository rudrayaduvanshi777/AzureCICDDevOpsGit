using System;

namespace EmployeeService.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Department { get; set; }
    }

}