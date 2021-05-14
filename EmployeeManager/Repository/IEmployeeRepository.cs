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
        bool Register(EmployeeModel employee);

        /// <summary>
        /// Login repository
        /// </summary>
        /// <param name="id">id is the input parameter</param>
        /// <param name="mobile">mobile is the input parameter</param>
        /// <returns>returns boolean result</returns>
        bool Login(int id, string mobile);

        /// <summary>
        /// Update repository
        /// </summary>
        /// <param name="employeeModel">employee model is input parameter</param>
        /// <returns>returns boolean result</returns>
        bool Update(EmployeeModel employeeModel);
    }
}
