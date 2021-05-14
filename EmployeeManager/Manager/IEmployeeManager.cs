using EmployeeModelLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
    public interface IEmployeeManager
    {
        /// <summary>
        /// Register manager
        /// </summary>
        /// <param name="employee">employee model is input parameter</param>
        /// <returns>returns boolean result</returns>
        bool Register(EmployeeModel employee);
    }
}
