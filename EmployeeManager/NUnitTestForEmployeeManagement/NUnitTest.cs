using Manager;
using NUnit.Framework;
using EmployeeModelLibrary;
using Repository;
using Moq;
using Microsoft.Extensions.Configuration;

namespace NUnitTestForEmployeeManagement
{
    public class Tests
    {
        [Test]
        public void IfSendEmployeeModelWith_CorrectEntries_ReturnTrue()
        {
            var configure = new Mock<IConfiguration>();
            var Employeerepo = new EmployeeRepository(configure.Object);
            EmployeeModel emp = new EmployeeModel{
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Mobile = "91 7894561230",
                Email = "Bhush@gmail.com",
                City = "Karnataka"
            };
            EmployeeModel result = Employeerepo.Register(emp);
            Assert.AreEqual(emp, result);
        }
        [Test]
        public void IfSendEmployeeModelWith_InCorrectEntries_ReturnFalse()
        {
            var configure = new Mock<IConfiguration>();
            var Employeerepo = new EmployeeRepository(configure.Object);
            EmployeeModel emp = new EmployeeModel
            {
                FirstName = "Te",
                LastName = "TestLastName",
                Mobile = "91 7894561230",
                Email = "Bhush@gmail.com",
                City = "Karnataka"
            };
            EmployeeModel result = Employeerepo.Register(emp);
            Assert.AreNotEqual(emp, result);
        }
        [Test]
        public void IfTryToLogin_WithValidInputs_ReturnTrue()
        {
            var configure = new Mock<IConfiguration>();
            var Employeerepo = new EmployeeRepository(configure.Object);
            string email = "john@gmail.com";
            string mobile = "91 96547896547";
            EmployeeModel expected = new EmployeeModel { Email = email, Mobile = mobile};
            EmployeeModel result = Employeerepo.Login(email, mobile);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void IfTryToLogin_WithInvalidInputs_ReturnFalse()
        {
            var configure = new Mock<IConfiguration>();
            var Employeerepo = new EmployeeRepository(configure.Object);
            string email = "john@gmail.com";
            string mobile = "91 96547891111";
            EmployeeModel expected = new EmployeeModel { Email = email, Mobile = mobile };
            EmployeeModel result = Employeerepo.Login(email, mobile);
            Assert.AreNotEqual(expected, result);
        }
        [Test]
        public void GivenInputs_AreValidForUpdate_ThenReturnTrue()
        {
            var configure = new Mock<IConfiguration>();
            var Employeerepo = new EmployeeRepository(configure.Object);
            EmployeeModel emp = new EmployeeModel
            {
                EmployeeID = 4005,
                FirstName = "Test",
                LastName = "TestLastName",
                Mobile = "91 7894561230",
                Email = "abc@gmail.com",
                City = "Karnataka"
            };
            EmployeeModel result = Employeerepo.Register(emp);
            Assert.AreEqual(emp, result);
        }
        [Test]
        public void GivenInputs_AreInValidForUpdate_ThenReturnTrue()
        {
            var configure = new Mock<IConfiguration>();
            var Employeerepo = new EmployeeRepository(configure.Object);
            EmployeeModel emp = new EmployeeModel
            {
                EmployeeID = 5000,
                FirstName = "Test",
                LastName = "TestLastName",
                Mobile = "91 7894561230",
                Email = "abc@gmail.com",
                City = "Karnataka"
            };
            EmployeeModel result = Employeerepo.Register(emp);
            Assert.AreNotEqual(emp, result);
        }
        [Test]
        public void GivenEmployeeID_IsEmployeePresent_ForDeleteEmployee_ThenReturnTrue()
        {
            var configure = new Mock<IConfiguration>();
            var Employeerepo = new EmployeeRepository(configure.Object);
            int id = 3004;
            bool result = Employeerepo.Delete(id);
            Assert.IsTrue(result);
        }
        [Test]
        public void GivenEmployeeID_IsNotEmployeePresent_ForDeleteEmployee_ThenReturnFalse()
        {
            var configure = new Mock<IConfiguration>();
            var Employeerepo = new EmployeeRepository(configure.Object);
            int id = 3004;
            bool result = Employeerepo.Delete(id);
            Assert.IsFalse(result);
        }
        [Test]
        public void GetAllEmployees_EmployeesPresent_GiveAllEntries_ReturnsTrue()
        {
            var configure = new Mock<IConfiguration>();
            var Employeerepo = new EmployeeRepository(configure.Object);
            var result = Employeerepo.GetAllEmployees();
            Assert.IsNotNull(result);
        }
    }

}