using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeService.Database;
using EmployeeService.DTO;
using EmployeeService.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public EmployeeService(ApplicationDbContext applicationDbContext,IMapper mapper)
        {
            _applicationDbContext=applicationDbContext;
            _mapper=mapper;
        }


        EmployeeDTO IEmployeeService.CreateEmployee(EmployeeDTO employeeDTO)
        {
            var employee=_mapper.Map<Employee>(employeeDTO);
            _applicationDbContext.Employees.Add(employee);
            _applicationDbContext.SaveChanges();
            return _mapper.Map<EmployeeDTO>(employee);
        }
        bool IEmployeeService.DeleteEmployee(int id)
        {
            var employee= _applicationDbContext.Employees.Find(id);
            if(employee==null) return false;
            _applicationDbContext.Employees.Remove(employee);
             _applicationDbContext.SaveChanges();
            return true;
        }

         EmployeeDTO IEmployeeService.GetEmployeeById(int id)
        {
           var employee= _applicationDbContext.Employees.Find(id);
           return employee==null?new EmployeeDTO():_mapper.Map<EmployeeDTO>(employee);
        }

         List<EmployeeDTO> IEmployeeService.GetEmployees()
        {
            var employees= _applicationDbContext.Employees.ToList();
            return _mapper.Map<List<EmployeeDTO>>(employees);
        }

         bool IEmployeeService.UpdateEmployee(int id, EmployeeDTO employeeDTO)
        {
            var employee= _applicationDbContext.Employees.Find(id);
            if(employee==null) return false;
            employeeDTO.EmployeeId = id;
            _mapper.Map(employeeDTO,employee);
            
            _applicationDbContext.Employees.Update(employee);
             _applicationDbContext.SaveChanges();
            return true;
        }
    }
}