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
        /// Delete method
        /// </summary>
        /// <param name="id">id as input</param>
        /// <returns>returns boolean value</returns>
        public bool Delete(int id)
        {
            try
            {
                bool result = this.repository.Delete(id);
                return result;
            }
            catch
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Get all employees method
        /// </summary>
        /// <returns>returns boolean result</returns>
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                return this.repository.GetAllEmployees();
            }
            catch
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Login method
        /// </summary>
        /// <param name="id">input as id</param>
        /// <param name="mobile">input as mobile number</param>
        /// <returns>returns boolean value</returns>
        public EmployeeModel Login(string email, string mobile)
        {
            try
            {
                return this.repository.Login(email, mobile);
            }
            catch
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Register method
        /// </summary>
        /// <param name="employee">employee model as parameter</param>
        /// <returns>returns boolean result</returns>
        public EmployeeModel Register(EmployeeModel employee)
        {
            try
            {
                return this.repository.Register(employee);
            }
            catch
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Update method
        /// </summary>
        /// <param name="employeeModel">employee model as input</param>
        /// <returns>returns boolean value</returns>
        public EmployeeModel Update(EmployeeModel employeeModel)
        {
            try
            {
                return this.repository.Update(employeeModel);
            }
            catch
            {
                throw new Exception();
            }
        }
    }

}
