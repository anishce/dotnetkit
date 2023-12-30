using DataFacadeSolutionWeb.Dtos;

namespace DataFacadeSolutionWeb.Services
{
    public interface IEmployeeService
    {
        EmployeeDto? GetEmployee(int id);
    }
}