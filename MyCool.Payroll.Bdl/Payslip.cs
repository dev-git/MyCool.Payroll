using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCool.Payroll.Bdl
{
    public class Payslip
    {
        public int PayslipID { get; set; }
        public string FullName { get; set; }
        public string PayPeriod { get; set; }
        public decimal GrossIncome { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal NetIncome { get; set; }
        public decimal SuperRate { get; set; }


        /// <summary>
        /// Gets the super amount.
        /// </summary>
        /// <returns></returns>
        public decimal GetSuperAmount()
        {
            if (GrossIncome > 0 && SuperRate > 0)
            {
                return Math.Floor(((GrossIncome / 12) * SuperRate) / 100);
            }
            return 0;
        }

        public decimal GetIncomeTaxAmount()
        {
            decimal incomeTaxAmount = 0;
            if (GrossIncome > 0)
            {
                if (GrossIncome > 18200)
                {
                    // if Gross Amount > 37000 ? 37000 : GrossAmount
                    incomeTaxAmount +=  ((GrossIncome > 37000 ? 37000 : GrossIncome) - 18200) * 0.19M;
                }
                if (GrossIncome > 37000)
                {
                    incomeTaxAmount += ((GrossIncome > 87000 ? 87000 : GrossIncome) - 37000) * 0.325M;
                }
                if (GrossIncome > 87000)
                {
                    incomeTaxAmount += ((GrossIncome > 180000 ? 180000 : GrossIncome) - 87000) * 0.37M;
                }
                if (GrossIncome > 180000)
                {
                    incomeTaxAmount += ((GrossIncome - 180000) * 41) / 100;
                }
            }
            return Math.Round(incomeTaxAmount / 12);
        }
    }
}
