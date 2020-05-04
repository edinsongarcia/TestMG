using MGapp;
using MGapp.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MGTest
{
    [TestClass]
    public class EmployeesTest
    {
        [TestMethod]
        public void GetAnnualSalary()
        {
            //Arrange
            EmployeeLogic logic = new EmployeeLogic();
            List<EmployeeDTO> employees = new List<EmployeeDTO>();

            decimal expected = 960000;
            //Act
            employees = logic.GetEmployees();
            decimal actual = employees.Where(x => x.ContractTypeName == "MonthlySalaryEmployee").Select(x=>x.AnnualSalary).FirstOrDefault();
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
