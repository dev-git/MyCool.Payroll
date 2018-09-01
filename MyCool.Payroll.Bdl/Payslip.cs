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
            TaxBand tb = new TaxBand(2018);

            decimal incomeTaxAmount = 0;
            if (GrossIncome > tb.TaxBandThreshold1)
            {
                incomeTaxAmount +=  ((GrossIncome > tb.TaxBandThreshold2 ? tb.TaxBandThreshold2 : GrossIncome) - tb.TaxBandThreshold1) * tb.TaxBandRate1;
            }
            if (GrossIncome > tb.TaxBandThreshold2)
            {
                incomeTaxAmount += ((GrossIncome > tb.TaxBandThreshold3 ? tb.TaxBandThreshold3 : GrossIncome) - tb.TaxBandThreshold2) * tb.TaxBandRate2;
            }
            if (GrossIncome > tb.TaxBandThreshold3)
            {
                incomeTaxAmount += ((GrossIncome > tb.TaxBandThreshold4 ? tb.TaxBandThreshold4 : GrossIncome) - tb.TaxBandThreshold3) * tb.TaxBandRate3;
            }
            if (GrossIncome > tb.TaxBandThreshold4)
            {
                incomeTaxAmount += (GrossIncome - tb.TaxBandThreshold4) * tb.TaxBandRate4;
            }
            
            return Math.Round(incomeTaxAmount / 12);
        }
    }
}
