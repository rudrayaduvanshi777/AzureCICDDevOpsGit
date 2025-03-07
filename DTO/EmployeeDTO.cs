using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeService.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Department { get; set; }
    }

}