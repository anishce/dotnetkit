// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using DataFacadeSolutionWeb.Dtos;

namespace DataFacadeSolutionWeb.Services
{
    public interface IEmployeeService
    {
        EmployeeDto? GetEmployee(int id);
    }
}