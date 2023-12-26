using DataFacadeRdbms;
using DataFacadeSolutionWeb.Dtos;
using System.Data.Common;

namespace DataFacadeSolutionWeb.Repositories
{
    public class EmployeeRepository
    {
        private readonly IDataFacade dataFacade;

        public EmployeeRepository(IDataFacade dataFacade)
        {
            this.dataFacade = dataFacade;
        }

        public EmployeeDto GetEmployee(int id)
        {
            var dbConnection = this.dataFacade.GetDbConnection("");
            dbConnection.Open();

            return new EmployeeDto();
        }
    }
}
