using System;

namespace PayrollService
{
    class Program
    {
        public static void Main(string[] args)
        {
            Operation operation = new Operation();
            operation.CreateTable();
            operation.AddValues();
            operation.GetAllEmployeeDetails();
            PayrollEmployee payrollEmployee = new PayrollEmployee()
            {
                Id = 1,
                Name = "Terisa",
                Salary = 200000 + "",
                Start_date = new DateTime(2023, 12, 12),
                Gender = 'F',
                Phone = "9791320622",
                Address = "Address of T",
                Department = "Developer",
                Basic_pay = 3000000,
                Deductions = 20000,
                Taxable_pay = 20000,
                Income_tax = 20000,
                Net_pay = 20000,
            };
            operation.UpdateEmployee(payrollEmployee);
            operation.GetAllEmployeeDetails();
            operation.GetRecordWithInDateRange();

        }
    }
}