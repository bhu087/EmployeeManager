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
    }
}
