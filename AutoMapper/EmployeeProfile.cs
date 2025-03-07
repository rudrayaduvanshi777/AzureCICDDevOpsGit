using System;
using AutoMapper;
using EmployeeService.DTO;
using EmployeeService.Model;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EmployeeService.AutoMapper
{
    public class EmployeeProfile: Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee,EmployeeDTO>().ReverseMap();
        }
    }
}