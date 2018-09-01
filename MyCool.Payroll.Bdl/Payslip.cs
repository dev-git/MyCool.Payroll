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
        /// Gets the monthly super amount.
        /// </summary>
        /// <returns></returns>
        public decimal GetSuperAmount()
        {
            // Return early if we have no GrossIncome or SuperRate
            if (GrossIncome <= 0 || SuperRate <= 0) return 0;
           
            return Math.Round(((GrossIncome / 12) * SuperRate) / 100);
        }

        /// <summary>
        /// Gets the monthly income tax amount.
        /// </summary>
        /// <returns></returns>
        public decimal GetIncomeTaxAmount()
        {
            // Return early if we have no GrossIncome
            if (GrossIncome <= 0) return 0;

            // Get the Tax Band
            TaxBand taxBand = new TaxBand(2018);

            decimal incomeTaxAmount = 0;
            if (GrossIncome > 18200)
            {
                incomeTaxAmount +=  ((GrossIncome > taxBand.TaxBandThreshold2 ? taxBand.TaxBandThreshold2 : GrossIncome) - taxBand.TaxBandThreshold1) * 0.19M;
            }
            if (GrossIncome > 37000)
            {
                incomeTaxAmount += ((GrossIncome > taxBand.TaxBandThreshold3 ? taxBand.TaxBandThreshold3 : GrossIncome) - taxBand.TaxBandThreshold2) * 0.325M;
            }
            if (GrossIncome > 87000)
            {
                incomeTaxAmount += ((GrossIncome > taxBand.TaxBandThreshold4 ? taxBand.TaxBandThreshold4 : GrossIncome) - taxBand.TaxBandThreshold3) * 0.37M;
            }
            if (GrossIncome > 180000)
            {
                incomeTaxAmount += (GrossIncome - 180000) * 0.41M;
            }
            
            return Math.Round(incomeTaxAmount / 12);
        }
    }
}
