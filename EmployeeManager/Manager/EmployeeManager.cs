using System;

namespace Manager
{
    using EmployeeModelLibrary;
    using Repository;
    using System.Collections.Generic;

    /// <summary>
    /// Employee manager class
    /// </summary>
    public class EmployeeManager : IEmployeeManager
    {
        /// <summary>
        /// employee repository interface
        /// </summary>
        public IEmployeeRepository repository;

        /// <summary>
        /// constructor for employee Manager
        /// </summary>
        /// <param name="repo">repository as a input</param>
        public EmployeeManager(IEmployeeRepository repo)
        {
            this.repository = repo;
        }

        /// <summary>
        /// Register method
        /// </summary>
        /// <param name="employee">employee model as parameter</param>
        /// <returns>returns boolean result</returns>
        public bool Register(EmployeeModel employee)
        {
            return this.repository.Register(employee);
        }
    }

}
