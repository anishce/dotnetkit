// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using DataFacadeSolutionWeb.Dtos;
using DataFacadeSolutionWeb.Repositories;

namespace DataFacadeSolutionWeb.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public EmployeeDto? GetEmployee(int id)
        {
            return employeeRepository.GetEmployee(id);
        }
    }
}
