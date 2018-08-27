using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCool.Payroll.Web.Models
{
    public class PayslipModel
    {
        public int PayslipID { get; set; }
        public string FullName { get; set; }
        public string PayPeriod { get; set; }
        public decimal GrossIncome { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal NetIncome { get; set; }
        public decimal SuperRate { get; set; }

    }
}
