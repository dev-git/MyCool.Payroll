using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyCool.Payroll.Itf;
using MyCool.Payroll.Bdl;

namespace MyCool.Payroll.Test
{
    [TestClass]
    public class PayrollUnitTest : IPayroll
    {
        [TestMethod]
        public void GetEmployee()
        {
            Employee employee = new Employee();
            employee.FirstName = "David";
            employee.LastName = "Rudd";
            Assert.IsTrue(employee.FullName == "David Rudd");
        }
        [TestMethod]
        public void GetSuperAmount()
        {
            Payslip payslip = new Payslip();
            payslip.GrossIncome = 60050;
            payslip.SuperRate = 9;
            decimal superAmount = payslip.GetSuperAmount();

            Assert.IsTrue(superAmount == 450);
        }

        [TestMethod]
        public void GetIncomeTaxAmount()
        {
            Payslip payslip = new Payslip();
            payslip.GrossIncome = 60050;
            //payslip.GrossIncome = 120000;
            decimal incomeTaxAmount = payslip.GetIncomeTaxAmount();

            Assert.IsTrue(incomeTaxAmount == 922);
            //Assert.IsTrue(incomeTaxAmount == 2669);
        }

        public bool LoadData()
        {
            throw new NotImplementedException();
        }

        public void PrintPayslip()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
