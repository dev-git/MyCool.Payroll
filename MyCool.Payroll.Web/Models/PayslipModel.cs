using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace MyCool.Payroll.Web.Models
{
    public class PayslipModel
    {
        public int PayslipID { get; set; }
        public string FullName { get; set; }
        public string PayPeriod { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal GrossIncome { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal IncomeTax { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal NetIncome { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal SuperAmount { get; set; }

    }
}
