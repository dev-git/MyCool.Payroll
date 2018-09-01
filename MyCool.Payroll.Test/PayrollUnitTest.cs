using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyCool.Payroll.Itf;
using MyCool.Payroll.Bdl;

namespace MyCool.Payroll.Test
{
    [TestClass]
    public class PayrollUnitTest : IPayroll
    {
        // Ideally we would have some mocking here using Rhino or Moq...

        /// <summary>
        /// Gets the employee.
        /// </summary>
        [TestMethod]
        public void GetEmployee()
        {
            Employee employee = new Employee
            {
                FirstName = "David",
                LastName = "Rudd"
            };
            Assert.IsTrue(employee.FullName == "David Rudd");
        }

        /// <summary>
        /// Gets the super amount.
        /// </summary>
        [TestMethod]
        public void GetSuperAmount()
        {
            Payslip payslip = new Payslip
            {
                GrossIncome = 60050,
                SuperRate = 9
            };
            decimal superAmount = payslip.GetSuperAmount();

            Assert.IsTrue(superAmount == 450);
        }

        /// <summary>
        /// Gets the income tax amount.
        /// </summary>
        [TestMethod]
        public void GetIncomeTaxAmount()
        {
            Payslip payslip = new Payslip
            {
                GrossIncome = 60050
            };

            decimal incomeTaxAmount = payslip.GetIncomeTaxAmount();

            Assert.IsTrue(incomeTaxAmount == 922);
         }

        /// <summary>
        /// Gets the net income.
        /// </summary>
        [TestMethod]
        public void GetNetIncome()
        {
            Payslip payslip = new Payslip
            {
                GrossIncome = 120000
            };
            decimal incomeTaxAmount = payslip.GetIncomeTaxAmount();
            decimal netIncome = (payslip.GrossIncome / 12) - incomeTaxAmount;

            Assert.IsTrue(netIncome == 7331);
        }

        public bool LoadData()
        {
            throw new NotImplementedException();
        }
        
        
        public void PrintPayslip()
        {
            throw new NotImplementedException();
        }
    }
}
