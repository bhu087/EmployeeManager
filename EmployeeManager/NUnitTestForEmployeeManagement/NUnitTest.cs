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
        [SetUp]
        public void Setup()
        {
            
        }
        [Test]
        public void IfSendEmployeeModelWith_CorrectEntries_ReturnTrue()
        {
            var service = new Mock<IConfiguration>();
            var manager = new EmployeeRepository(service.Object);
            var register = new EmployeeModel
            {
                FirstName = "Bhushan",
                LastName = "Kumar",
                Mobile = "91 9632112369",
                Email = "bhush@gmail.com",
                City = "Bengaluru"
            };
            bool result = manager.Register(register);
            Assert.IsTrue(result);
        }
        [Test]
        public void IfSendEmployeeModelWith_InCorrectEntries_ReturnTrue()
        {
            var service = new Mock<IConfiguration>();
            var manager = new EmployeeRepository(service.Object);
            var register = new EmployeeModel
            {
                FirstName = "B",
                LastName = "Kumar",
                Mobile = "91 9632112369",
                Email = "bhush@gmail.com",
                City = "Bengaluru"
            };
            bool result = manager.Register(register);
            Assert.IsFalse(result);
        }
        [Test]
        public void IfTryToLogin_WithValidInputs_ReturnTrue()
        {
            var service = new Mock<IConfiguration>();
            var manager = new EmployeeRepository(service.Object);
            int EmployeeID = 3004;
            string mobile = "91 96547896547";
            bool result = manager.Login(EmployeeID, mobile);
            Assert.IsTrue(result);
        }
        [Test]
        public void IfTryToLogin_WithInvalidInputs_ReturnFalse()
        {
            var service = new Mock<IConfiguration>();
            var manager = new EmployeeRepository(service.Object);
            int EmployeeID = 2004;
            string mobile = "91 9632112111";
            bool result = manager.Login(EmployeeID, mobile);
            Assert.IsFalse(result);
        }
        [Test]
        public void GivenInputs_AreValidForUpdate_ThenReturnTrue()
        {
            var service = new Mock<IConfiguration>();
            var manager = new EmployeeRepository(service.Object);
            var employee = new EmployeeModel
            {
                EmployeeID = 3003,
                FirstName = "Bhush",
                LastName = "Kumar",
                Mobile = "91 9632111234",
                Email = "abc@gmail.com",
                City = "Bengaluru"
            };
            bool result = manager.Update(employee);
            Assert.IsFalse(result);
        }
        [Test]
        public void GivenInputs_AreInValidForUpdate_ThenReturnTrue()
        {
            var service = new Mock<IConfiguration>();
            var manager = new EmployeeRepository(service.Object);
            var employee = new EmployeeModel
            {
                EmployeeID = 4005,
                FirstName = "Bhush",
                LastName = "Kumar",
                Mobile = "91 9632111234",
                Email = "abc@gmail.com",
                City = "Bengaluru"
            };
            bool result = manager.Update(employee);
            Assert.IsFalse(result);
        }
        [Test]
        public void GivenEmployeeID_IsEmployeePresent_ThenReturnTrue()
        {
            var service = new Mock<IConfiguration>();
            var manager = new EmployeeRepository(service.Object);
            int id = 2004;
            bool result = manager.Delete(id);
            Assert.IsTrue(result);
        }
        [Test]
        public void GivenEmployeeID_IsNotEmployeePresent_ThenReturnFalse()
        {
            var service = new Mock<IConfiguration>();
            var manager = new EmployeeRepository(service.Object);
            int id = 5;
            bool result = manager.Delete(id);
            Assert.IsFalse(result);
        }
        [Test]
        public void GetAllEmployees_EmployeesPresent_GiveAllEntries_ReturnsTrue()
        {
            var service = new Mock<IConfiguration>();
            var manager = new EmployeeRepository(service.Object);
            var result = manager.GetAllEmployees();
            Assert.NotNull(result);
        }
    }

}