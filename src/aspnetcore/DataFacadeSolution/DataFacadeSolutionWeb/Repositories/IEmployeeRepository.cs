// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using DataFacadeSolutionWeb.Dtos;

namespace DataFacadeSolutionWeb.Repositories
{
    public interface IEmployeeRepository
    {
        EmployeeDto? GetEmployee(int id);
    }
}