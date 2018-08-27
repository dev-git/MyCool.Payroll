using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCool.Payroll.Bdl
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public int SuperRate { get; set; }
        public DateTime PaymentStart { get; set; }
        public string FullName
        {
            get
            {
               return String.Format("{0} {1}", FirstName, LastName);
            }
        }
    }
}
