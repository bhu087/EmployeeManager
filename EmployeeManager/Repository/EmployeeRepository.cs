/////------------------------------------------------------------------------
////<copyright file="EmployeeRepository.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------

namespace Repository
{
    using EmployeeModelLibrary;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// 
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
        private string conString;

        /// <summary>
        /// constructor for Employee Repository
        /// </summary>
        /// <param name="configuration">configuration parameter</param>
        public EmployeeRepository(IConfiguration configuration)
        {
            appConfig = configuration;
        }
        public string ConnectionString()
        {
            conString = appConfig["ConnectionStrings:DefaultConnection"];
            return conString;
        }

        /// <summary>
        /// Register method
        /// </summary>
        /// <param name="employeeModel">Employee model</param>
        /// <returns>returns boolean result</returns>
        public EmployeeModel Register(EmployeeModel employeeModel)
        {
            string conn = ConnectionString();
            SqlConnection connection = new SqlConnection(conn);
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("spAddEmployeeToTable", connection))
                {
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
                        return employeeModel;
                    }

                    return null;
                }
            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Login method
        /// </summary>
        /// <param name="id">input as Id</param>
        /// <param name="mobile">input as mobile</param>
        /// <returns>returns boolean result</returns>
        public EmployeeModel Login(string email, string mobile)
        {
            string conn = ConnectionString();
            SqlConnection connection = new SqlConnection(conn);
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                employeeModel.Email = email;
                employeeModel.Mobile = mobile;
                using (SqlCommand command = new SqlCommand("spEmployeeLogin", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Email", email);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (mobile.ToString().Equals(reader["Mobile"].ToString()))
                        {
                            return employeeModel;
                        }
                    }

                    return null;
                }
            }
            catch(Exception e)
            {
                throw new Exception();
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Update method
        /// </summary>
        /// <param name="employeeModel">employee model</param>
        /// <returns>returns boolean result</returns>
        public EmployeeModel Update(EmployeeModel employeeModel)
        {
            string conn = ConnectionString();
            SqlConnection connection = new SqlConnection(conn);
            try
            {
                using (SqlCommand command1 = new SqlCommand("spUpdateEmployeeToTable", connection))
                {
                    command1.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command1.Parameters.AddWithValue("EmployeeID", employeeModel.EmployeeID);
                    command1.Parameters.AddWithValue("FirstName", employeeModel.FirstName);
                    command1.Parameters.AddWithValue("LastName", employeeModel.LastName);
                    command1.Parameters.AddWithValue("Mobile", employeeModel.Mobile);
                    command1.Parameters.AddWithValue("Email", employeeModel.Email);
                    command1.Parameters.AddWithValue("City", employeeModel.City);
                    var result = command1.ExecuteNonQuery();
                    if (result == 1)
                    {
                        return employeeModel;
                    }
                    return null;
                }
            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Get all employees method
        /// </summary>
        /// <returns>returns list of employees</returns>
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> employeesList = new List<EmployeeModel>();
            string conn = ConnectionString();
            SqlConnection connection = new SqlConnection(conn);
            try
            {
                SqlCommand command = new SqlCommand("spGetAllEmployees", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EmployeeModel employee = new EmployeeModel
                        {
                            EmployeeID = (int)reader["EmployeeID"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Mobile = reader["Mobile"].ToString(),
                            Email = reader["Email"].ToString(),
                            City = reader["City"].ToString()
                        };
                        employeesList.Add(employee);
                    }
                    if (employeesList.Count != 0)
                    {
                        return employeesList;
                    }
                    return null;
                }    
                    
            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Delete method
        /// </summary>
        /// <param name="id">id as input</param>
        /// <returns>returns boolean result</returns>
        public bool Delete(int id)
        {
            string conn = ConnectionString();
            SqlConnection connection = new SqlConnection(conn);
            try
            {
                using (SqlCommand command = new SqlCommand("spDeleteEmployee", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("EmployeeID", id);
                    int result = command.ExecuteNonQuery();
                    if (result == 1)
                    {
                        connection.Close();
                        return true;
                    }
                    connection.Close();
                    return false;
                }  
            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
