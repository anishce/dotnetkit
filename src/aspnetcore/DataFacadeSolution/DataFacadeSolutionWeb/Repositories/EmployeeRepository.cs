using DataFacadeRdbms;
using DataFacadeSolutionWeb.Dtos;
using DataFacadeSolutionWeb.Helpers;

namespace DataFacadeSolutionWeb.Repositories
{
    public class EmployeeRepository
    {
        private readonly IDataFacade dataFacade = null!;
        private readonly string connectionString = string.Empty;

        public EmployeeRepository(IDataFacade dataFacade, IConfigSetting configSetting)
        {
            this.dataFacade = dataFacade;
            connectionString = configSetting.GetConnectionString("DefaultConnection");
        }

        public EmployeeDto GetEmployee(int id)
        {
            using (var dbConnection = this.dataFacade.GetDbConnection(connectionString))
            {
                dbConnection.Open();

                dataFacade.CloseConnection(dbConnection);
            }
            return new EmployeeDto();
        }
    }
}
