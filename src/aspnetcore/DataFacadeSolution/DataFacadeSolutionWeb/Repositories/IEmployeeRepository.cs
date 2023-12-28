using DataFacadeSolutionWeb.Dtos;

namespace DataFacadeSolutionWeb.Repositories
{
    public interface IEmployeeRepository
    {
        EmployeeDto? GetEmployee(int id);
    }
}