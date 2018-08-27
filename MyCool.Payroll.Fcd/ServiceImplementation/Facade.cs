using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyCool.Payroll.Bdl;

namespace MyCool.Payroll.Fcd
{
    public class Facade : IFacade
    {
        public decimal GetIncomeTaxAmount(decimal annualSalary)
        {
            Payslip payslip = new Payslip
            {
                GrossIncome = annualSalary
            };
            return payslip.GetIncomeTaxAmount();
        }

        public decimal GetSuperAmount()
        {
            throw new NotImplementedException();
        }
    }
}
