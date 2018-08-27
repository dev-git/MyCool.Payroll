using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCool.Payroll.Web.Models
{
    public class EmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public int SuperRate { get; set; }
        public DateTime PaymentStart { get; set; }
    }
}
