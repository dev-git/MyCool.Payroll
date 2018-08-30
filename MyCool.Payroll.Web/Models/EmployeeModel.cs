using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace MyCool.Payroll.Web.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal AnnualSalary { get; set; }

        public int SuperRate { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime PaymentStart { get; set; }
    }
}
