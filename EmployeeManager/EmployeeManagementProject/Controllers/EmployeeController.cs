/////------------------------------------------------------------------------
////<copyright file="EmployeeController.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------

namespace EmployeeManagementProject.Controllers
{
    using EmployeeModelLibrary;
    using Manager;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller class for employee
    /// </summary>
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// boolean variable for receiving result
        /// </summary>
        private bool response;

        /// <summary>
        /// Interface for manager
        /// </summary>
        private readonly IEmployeeManager _manager;

        /// <summary>
        /// constructor for employee
        /// </summary>
        /// <param name="manager"></param>
        public EmployeeController(IEmployeeManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Register method
        /// </summary>
        /// <param name="employeeModel">employee model as input parameters</param>
        /// <returns>return action results</returns>
        [HttpPost]
        [Route("api/register")]
        public ActionResult Register(EmployeeModel employeeModel)
        {
            EmployeeModel employee = new EmployeeModel
            {
                FirstName = employeeModel.FirstName,
                LastName = employeeModel.LastName,
                Mobile = employeeModel.Mobile,
                Email = employeeModel.Email,
                City = employeeModel.City
            };
            this.response = this._manager.Register(employee);
            if (this.response)
            {
                return this.Ok("Registered Successfully");
            }

            return this.BadRequest("Not registered");
        }
    }
}
