using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCool.Payroll.Itf
{
    public interface IPayroll
    {
        bool LoadData();

        void PrintPayslip();

        void GetEmployee();

    }
}
