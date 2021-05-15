/////------------------------------------------------------------------------
////<copyright file="IEmployeeRepository.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace Repository
{
    using EmployeeModelLibrary;
    using System.Collections.Generic;

    /// <summary>
    /// interface for employee repository
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Register repository
        /// </summary>
        /// <param name="employee">employee model is input parameter</param>
        /// <returns>returns boolean result</returns>
        EmployeeModel Register(EmployeeModel employee);

        /// <summary>
        /// Login repository
        /// </summary>
        /// <param name="id">id is the input parameter</param>
        /// <param name="mobile">mobile is the input parameter</param>
        /// <returns>returns boolean result</returns>
        EmployeeModel Login(string email, string mobile);

        /// <summary>
        /// Update repository
        /// </summary>
        /// <param name="employeeModel">employee model is input parameter</param>
        /// <returns>returns boolean result</returns>
        EmployeeModel Update(EmployeeModel employeeModel);

        /// <summary>
        /// Get all employees repository
        /// </summary>
        /// <returns>return all employees in the table</returns>
        IEnumerable<EmployeeModel> GetAllEmployees();

        /// <summary>
        /// Delete repository
        /// </summary>
        /// <param name="id">id is the input parameter</param>
        /// <returns>returns boolean result</returns>
        bool Delete(int id);
    }
}
