using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCool.Payroll.Bdl
{
    /// <summary>
    /// An object to hold tax band thresholds, allowing us 
    /// to store and retrieve from a Db.
    /// </summary>
    class TaxBand
    {
        public int TaxBandID { get; set; }
        public int TaxBandThreshold1 { get; set; }
        public decimal TaxBandRate1 { get; set; }
        public int TaxBandThreshold2 { get; set; }
        public decimal TaxBandRate2 { get; set; }
        public int TaxBandThreshold3 { get; set; }
        public decimal TaxBandRate3 { get; set; }
        public int TaxBandThreshold4 { get; set; }
        public decimal TaxBandRate4 { get; set; }

        public TaxBand(int taxBandID)
        { 
            TaxBandID = taxBandID;
            TaxBandThreshold1 = 18200;
            TaxBandThreshold2 = 37000;
            TaxBandThreshold3 = 87000;
            TaxBandThreshold4 = 180000;

            TaxBandRate1 = 0.19M;
            TaxBandRate2 = 0.325M;
            TaxBandRate3 = 0.37M;
            TaxBandRate4 = 0.41M;
        }
    }
}
