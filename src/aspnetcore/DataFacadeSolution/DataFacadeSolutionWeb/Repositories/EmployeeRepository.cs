using DataFacadeRdbms;
using DataFacadeSolutionWeb.Dtos;
using DataFacadeSolutionWeb.Helpers;

namespace DataFacadeSolutionWeb.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDataFacade dataFacade = null!;
        private readonly string connectionString = string.Empty;

        public EmployeeRepository(IDataFacade dataFacade, IConfigSetting configSetting)
        {
            this.dataFacade = dataFacade;
            connectionString = configSetting.GetConnectionString("DefaultConnection");
        }

        public EmployeeDto? GetEmployee(int id)
        {
            EmployeeDto? employee = null;

            using (var dbConnection = this.dataFacade.GetDbConnection(connectionString))
            {
                dbConnection.Open();

                using (var dbCommand = dataFacade.GetDbCommand($"SELECT * FROM [dbo].[Employee] WHERE Id={id}", dbConnection))
                {
                    using (var dbReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.SingleResult))
                    {
                        while (dbReader != null && dbReader.Read())
                        {
                            employee = new EmployeeDto
                            {
                                Id = Convert.ToInt32(dbReader["Id"]),
                                Name = Convert.ToString(dbReader["Name"]) ?? string.Empty,
                                Email = Convert.ToString(dbReader["email"]) ?? string.Empty,
                                PhoneNumber = Convert.ToString(dbReader["PhoneNumber"]) ?? string.Empty,
                                Address = Convert.ToString(dbReader["Address"]) ?? string.Empty,
                                Country = Convert.ToString(dbReader["Country"]) ?? string.Empty,
                                State = Convert.ToString(dbReader["State"]) ?? string.Empty,
                                City = Convert.ToString(dbReader["City"]) ?? string.Empty,
                                PostalCode = Convert.ToString(dbReader["PostalCode"]) ?? string.Empty,
                                FaxNumber = Convert.ToString(dataFacade.SafeConvertFromDBNull(dbReader, "FaxNumber")) ?? string.Empty
                            };
                        }

                        dbReader!.Close();
                    }
                }
                dataFacade.CloseConnection(dbConnection);
            }
            return employee;
        }
    }
}
