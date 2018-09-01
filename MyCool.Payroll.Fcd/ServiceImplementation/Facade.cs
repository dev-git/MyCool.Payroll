using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyCool.Payroll.Bdl;

namespace MyCool.Payroll.Fcd
{
    /// <summary>
    /// My favourite pattern, the Facade pattern.
    /// Ideally we'd need Data Transfer Objects and Data Mappers here.
    /// </summary>
    /// <seealso cref="MyCool.Payroll.Fcd.IFacade" />
    public class Facade : IFacade
    {
        /// <summary>
        /// Gets the income tax amount.
        /// </summary>
        /// <param name="annualSalary">The annual salary.</param>
        /// <returns></returns>
        public decimal GetIncomeTaxAmount(decimal annualSalary)
        {
            Payslip payslip = new Payslip
            {
                GrossIncome = annualSalary
            };
            return payslip.GetIncomeTaxAmount();
        }

        /// <summary>
        /// Gets the super amount.
        /// </summary>
        /// <param name="annualSalary">The annual salary.</param>
        /// <param name="superRate">The super rate.</param>
        /// <returns></returns>
        public decimal GetSuperAmount(decimal annualSalary, decimal superRate)
        {
            Payslip payslip = new Payslip
            {
                GrossIncome = annualSalary,
                SuperRate = superRate
            };
            return payslip.GetSuperAmount();
        }
    }
}
