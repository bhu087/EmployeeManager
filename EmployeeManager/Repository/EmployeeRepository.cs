/////------------------------------------------------------------------------
////<copyright file="EmployeeRepository.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------

namespace Repository
{
    using EmployeeModelLibrary;
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Employee repository class
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        /// <summary>
        /// configuration interface
        /// </summary>
        private static IConfiguration appConfig;

        /// <summary>
        /// connection string
        /// </summary>
        private static string conString;

        /// <summary>
        /// constructor for Employee Repository
        /// </summary>
        /// <param name="configuration">configuration parameter</param>
        public EmployeeRepository(IConfiguration configuration)
        {
            appConfig = configuration;
            conString = appConfig.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Register method
        /// </summary>
        /// <param name="employeeModel">Employee model</param>
        /// <returns>returns boolean result</returns>
        public bool Register(EmployeeModel employeeModel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddEmployeeToTable", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("FirstName", employeeModel.FirstName);
                    sqlCommand.Parameters.AddWithValue("LastName", employeeModel.LastName);
                    sqlCommand.Parameters.AddWithValue("Mobile", employeeModel.Mobile);
                    sqlCommand.Parameters.AddWithValue("Email", employeeModel.Email);
                    sqlCommand.Parameters.AddWithValue("City", employeeModel.City);
                    connection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
                    if (result == 1)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Login method
        /// </summary>
        /// <param name="id">input as Id</param>
        /// <param name="mobile">input as mobile</param>
        /// <returns>returns boolean result</returns>
        public bool Login(int id, string mobile)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    SqlCommand command = new SqlCommand("spEmployeeLogin", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("EmployeeID", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (mobile.ToString().Equals(reader["Mobile"].ToString()))
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
