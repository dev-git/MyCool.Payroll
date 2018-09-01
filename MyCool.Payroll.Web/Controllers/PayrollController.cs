using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.IO;
using MyCool.Payroll.Fcd;


namespace MyCool.Payroll.Web.Controllers
{
    public class PayrollController : Controller
    {
        //List<Models.EmployeeModel> EmployeeList = new List<Models.EmployeeModel>();


 
        //private List<Models.EmployeeModel> EmployeeList
        //{
        //    get {
        //        return TempData["employee"] as List<Models.EmployeeModel>;
        //    }
        //    set {
        //        TempData["employee"] = value;
        //    }
        //}

        Facade serviceImplementation = new Facade();
        // GET: Payroll
        public IActionResult Index()
        {
            var model = new List<Models.EmployeeModel>();
            return View(model);
        }

        // GET: Payroll/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Payroll/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();
            List<Models.EmployeeModel> empList = new List<Models.EmployeeModel>();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);

                        using (var reader = new StreamReader(formFile.OpenReadStream()))
                        {
                            int counter = 1;
                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                var data = line.Split(new[] { ',' });
                                
                                var employee = new Models.EmployeeModel {
                                    EmployeeID = counter,
                                    FirstName = data[0],
                                    LastName = data[1],
                                    AnnualSalary = Decimal.Parse(data[2]),
                                    SuperRate = Int32.Parse(data[3].Replace("%", "")),
                                    PaymentStart = GetStartDate(data[4]),
                                    PayPeriod = data[4]
                                };

                                empList.Add(employee);
                                counter++;
                            }
                        }
                    }
                }
            }
 
            return View("_EmployeeList", empList);
        }

        [HttpGet("Load")]
        public ActionResult Load(string fullName, decimal annualSalary, decimal superRate, string payPeriod, int employeeID)
        {
            var employee = new Models.EmployeeModel
            {
                EmployeeID = employeeID,
                AnnualSalary = annualSalary,
                PayPeriod = payPeriod,
                SuperRate = superRate
            };

            decimal incomeTax = serviceImplementation.GetIncomeTaxAmount(employee.AnnualSalary);
            decimal superAmount = serviceImplementation.GetSuperAmount(employee.AnnualSalary, employee.SuperRate);

            Models.PayslipModel payslipModel = new Models.PayslipModel
            {
                FullName = fullName,
                PayPeriod = employee.PayPeriod,
                GrossIncome = (employee.AnnualSalary / 12),
                IncomeTax = incomeTax,
                NetIncome = (employee.AnnualSalary / 12) - incomeTax,
                SuperAmount = superAmount
            };

            return View("Payslip", payslipModel);
        }

        [HttpGet("Display")]
        public ActionResult Display(int employeeID)
        { 
            List<Models.EmployeeModel> EmployeeList = TempData["employee"] as List<Models.EmployeeModel>;

            var employee = EmployeeList.FirstOrDefault(p => p.EmployeeID == employeeID);

            decimal incomeTax = serviceImplementation.GetIncomeTaxAmount(employee.AnnualSalary);
            decimal superAmount = serviceImplementation.GetSuperAmount(employee.AnnualSalary, employee.SuperRate);

            Models.PayslipModel payslipModel = new Models.PayslipModel
            {
                FullName = String.Format("{0} {1}", employee.FirstName, employee.LastName),
                PayPeriod = employee.PayPeriod,
                GrossIncome = (employee.AnnualSalary / 12),
                IncomeTax = incomeTax,
                NetIncome = (employee.AnnualSalary / 12) - incomeTax,
                SuperAmount = superAmount
            };

            return View("Payslip", payslipModel);
        }

        /// <summary>
        /// Prints the specified full payslip.
        /// </summary>
        /// <param name="fullName">The full name.</param>
        /// <param name="annualSalary">The annual salary.</param>
        /// <param name="superRate">The super rate.</param>
        /// <param name="startDate">The start date.</param>
        /// <returns></returns>
        [HttpGet("Print")]
        public ActionResult Print(string fullName, decimal annualSalary, decimal superRate, string payDate)
        {
            decimal incomeTax = serviceImplementation.GetIncomeTaxAmount(annualSalary);
            decimal superAmount = serviceImplementation.GetSuperAmount(annualSalary, superRate);
            Models.PayslipModel payslipModel = new Models.PayslipModel
            {
                FullName = fullName,
                PayPeriod = payDate,
                GrossIncome = (annualSalary / 12),
                IncomeTax = incomeTax,
                NetIncome = (annualSalary / 12) - incomeTax,
                SuperAmount = superAmount
            };

            return View("Payslip", payslipModel);
        }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <param name="dateStr">The date string.</param>
        /// <returns></returns>
        private DateTime GetStartDate(string dateStr)
        {
            // Expecting date in format "01 March - 31 March"
            DateTime startDate = DateTime.MaxValue;
            if (!String.IsNullOrEmpty(dateStr))
            {
                try
                {
                    string[] dateParts = dateStr.Split(new[] { ' ' });
                    startDate = new DateTime(2018, DateTime.ParseExact(dateParts[1], "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month, Int32.Parse(dateParts[0]));
                }
                catch (Exception ex)
                {
                    // just swallow the error but should return something meaningful....
                }
            }

            return startDate;
        }



        // POST: Payroll/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Payroll/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Payroll/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Payroll/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Payroll/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}