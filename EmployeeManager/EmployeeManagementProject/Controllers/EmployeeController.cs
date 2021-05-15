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
    using System;

    /// <summary>
    /// Controller class for employee
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// boolean variable for receiving result
        /// </summary>
        private EmployeeModel response;

        /// <summary>
        /// Interface for manager
        /// </summary>
        private IEmployeeManager _manager;

        /// <summary>
        /// constructor for employee
        /// </summary>
        /// <param name="manager"></param>
        public EmployeeController(IEmployeeManager manager)
        {
            this._manager = manager;
        }
        /// <summary>
        /// Register method
        /// </summary>
        /// <param name="employeeModel">employee model as input parameters</param>
        /// <returns>return action results</returns>
        [HttpPost]
        public ActionResult Register(EmployeeModel employeeModel)
        {
            try
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
                if (this.response != null)
                {
                    return this.Ok(new { Status = true, Message = "Registered in successfully", Data = this.response });
                }

                return this.BadRequest(new { Status = false, Message = "Not registered", Data = this.response });

            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = "Not registered", Data = e });
            }
        }

        /// <summary>
        /// Login method
        /// </summary>
        /// <param name="id">id as input</param>
        /// <param name="mobile">mobile number as input</param>
        /// <returns>return action result</returns>
        [HttpPost]
        [Route("login")]
        public ActionResult Login(string email, string mobile)
        {
            try
            {
                this.response = this._manager.Login(email, mobile);
                if (this.response != null)
                {
                    return this.Ok(new { Status = true, Message = "Logged in successfully", Data = this.response });
                }

                return this.BadRequest(new { Status = false, Message = "Not Logged in", Data = this.response });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = "Not registered", Data = e });
            }
        }

        /// <summary>
        /// Updates method
        /// </summary>
        /// <param name="employeeModel">employee model as input parameter</param>
        /// <returns>returns action result</returns>
        [HttpPut]
        public ActionResult Update(EmployeeModel employeeModel)
        {
            try
            {
                this.response = this._manager.Update(employeeModel);
                if (this.response != null)
                {
                    return this.Ok(new { Status = true, Message = "Updated in successfully", Data = this.response });
                }

                return this.BadRequest(new { Status = false, Message = "Update failed", Data = this.response });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = "Not registered", Data = e });
            }
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>returns action results</returns>
        [HttpGet]
        public ActionResult GetAllEmployees()
        {
            try
            {
                var result = this.Ok(this._manager.GetAllEmployees());
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Employee List", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Empty Employee List", Data = result });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = "Employees Not present", Data = e });
            }
        }

        /// <summary>
        /// Delete method
        /// </summary>
        /// <param name="id">id as input</param>
        /// <returns>returns action result</returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                bool result = this._manager.Delete(id);
                if (result)
                {
                    return this.Ok(new { Status = true, Message = "Deleted", Data = this.response });
                }

                return this.BadRequest(new { Status = false, Message = "Employee Not present", Data = this.response });
            }
            
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = "Employee Not present", Data = e });
            }
        }
    }
}
