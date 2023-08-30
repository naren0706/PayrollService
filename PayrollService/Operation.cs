using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollService
{
    internal class Operation
    {
        public static Random random = new Random();

        private SqlConnection con = new SqlConnection("data source = (localdb)\\MSSQLLocalDB; initial catalog = Payroll_service; integrated security = true");
        private void Connection()
        {
            string connectionstr = "data source = (localdb)\\MSSQLLocalDB; initial catalog = payroll_service; integrated security = true";
            con = new SqlConnection(connectionstr);
        }
        public void CreateTable()
        {
            try
            {
                Connection();
                string query = "create Table payroll_employee(Id int primary key identity(1,1),Name varchar(max) not null,Salary varchar(max) not null,Start_date DATETIME not null,Gender varchar(max) not null,Phone varchar(max) not null,Address varchar(max) not null,Department varchar(max) not null,Basic_pay varchar(max) not null,Deductions varchar(max) not null,Taxable_pay varchar(max) not null,Income_tax varchar(max) not null,Net_pay varchar(max) not null,)";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("DataBase Created Sucessfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("no database created ");
            }
            finally
            {
                con.Close();
            }
        }
        public PayrollEmployee AddEmployeeDetails(PayrollEmployee employee)
        {
            try
            {
                SqlCommand com = new SqlCommand("AddEmployeeDetail", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Name", employee.Name);
                com.Parameters.AddWithValue("@Salary", employee.Salary);
                com.Parameters.AddWithValue("@Start_date", employee.Start_date);
                com.Parameters.AddWithValue("@Gender", employee.Gender);
                com.Parameters.AddWithValue("@Phone", employee.Phone);
                com.Parameters.AddWithValue("@Address", employee.Address);
                com.Parameters.AddWithValue("@Department", employee.Department);
                com.Parameters.AddWithValue("@Basic_pay", employee.Basic_pay);
                com.Parameters.AddWithValue("@Deductions", employee.Deductions);
                com.Parameters.AddWithValue("@Taxable_pay", employee.Taxable_pay);
                com.Parameters.AddWithValue("@Income_tax", employee.Income_tax);
                com.Parameters.AddWithValue("@Net_pay", employee.Net_pay);
                con.Open();
                var i = com.ExecuteScalar();
                Console.WriteLine("Database Added");
                employee.Id = Convert.ToInt32(i);
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void deletemployeeeDetails(int id)
        {
            try
            {
                SqlCommand com = new SqlCommand("DeleteEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                con.Open();
                int i = com.ExecuteNonQuery();
                Console.WriteLine("Database Deleted");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateEmployee(PayrollEmployee employee)
        {
            try
            {
                SqlCommand com = new SqlCommand("UpdateEmployeeDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", employee.Id);
                com.Parameters.AddWithValue("@Name", employee.Name);
                com.Parameters.AddWithValue("@Salary", employee.Salary);
                com.Parameters.AddWithValue("@Start_date", employee.Start_date);
                com.Parameters.AddWithValue("@Gender", employee.Gender);
                com.Parameters.AddWithValue("@Phone", employee.Phone);
                com.Parameters.AddWithValue("@Address", employee.Address);
                com.Parameters.AddWithValue("@Department", employee.Department);
                com.Parameters.AddWithValue("@Basic_pay", employee.Basic_pay);
                com.Parameters.AddWithValue("@Deductions", employee.Deductions);
                com.Parameters.AddWithValue("@Taxable_pay", employee.Taxable_pay);
                com.Parameters.AddWithValue("@Income_tax", employee.Income_tax);
                com.Parameters.AddWithValue("@Net_pay", employee.Net_pay);
                con.Open();
                int i = com.ExecuteNonQuery();
                Console.WriteLine("DataBase Updated");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void GetAllEmployeeDetails()
        {
            List<PayrollEmployee> emplist = new List<PayrollEmployee>();
            SqlCommand com = new SqlCommand("GetEmployeeDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                emplist.Add(
                    new PayrollEmployee
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Name = Convert.ToString(dr["name"]),
                        Salary = Convert.ToString(dr["salary"]),
                        Start_date = DateTime.Parse(Convert.ToString(dr["start_date"])),
                        Gender = Convert.ToChar(dr["Gender"]),
                        Phone = Convert.ToString(dr["phone"]),
                        Address = Convert.ToString(dr["Address"]),
                        Department = Convert.ToString(dr["department"]),
                        Basic_pay = Convert.ToInt64(dr["basic_pay"]),
                        Deductions = Convert.ToInt64(dr["deductions"]),
                        Taxable_pay = Convert.ToInt64(dr["taxable_pay"]),
                        Income_tax = Convert.ToInt64(dr["income_tax"]),
                        Net_pay = Convert.ToInt64(dr["net_pay"])
                    }
                    );
            }
            foreach (var data in emplist)
            {
                Console.WriteLine(data.Id + " " + data.Name + " " + data.Salary + " " + data.Start_date + " " + data.Gender + " " + data.Phone + " " + data.Address + " " + data.Department + " " + data.Basic_pay + " " + data.Deductions + " " + data.Taxable_pay + " " + data.Income_tax + " " + data.Net_pay + " ");
            }
        }

        internal void AddValues()
        {
            string[] dep = { "Developer", "tester", "UI/Ux designer" };
            char[] gender = { 'M', 'F' };
            for (int i = 0; i < 50; i++)
            {
                DateTime randomDate = GetDateTime();
                PayrollEmployee payrollEmployee = new PayrollEmployee()
                {
                    Name = "Name" + i,
                    Salary = random.Next(1,20) * 10000 + "",
                    Start_date = randomDate,
                    Gender = gender[random.Next(2)],
                    Phone = "9" + random.Next(100000000, 999999999),
                    Address = "Address" + i,
                    Department = dep[random.Next(3)],
                    Basic_pay = random.Next(1, 11) * 1000,
                    Deductions = random.Next(1, 5) * 1000,
                    Taxable_pay = random.Next(1, 6) * 1000,
                    Income_tax = random.Next(1, 5) * 1000,
                    Net_pay = random.Next(1, 15) * 1000,
                };
                AddEmployeeDetails(payrollEmployee);
            }
        }

        private DateTime GetDateTime()
        {
            DateTime startDate = new DateTime(2000, 1, 1);
            DateTime endDate = new DateTime(2023, 12, 31);
            Random random = new Random();
            TimeSpan timeSpan = endDate - startDate;
            TimeSpan randomSpan = new TimeSpan((long)(random.NextDouble() * timeSpan.Ticks));
            DateTime randomDate = startDate + randomSpan;
            return randomDate;
        }

        internal void GetRecordWithInDateRange()
        {
            List<PayrollEmployee> emplist = new List<PayrollEmployee>();
            SqlCommand com = new SqlCommand("GetUsingDateRange", con);
            com.CommandType = CommandType.StoredProcedure;
            DateTime startDate = new DateTime(2012, 12, 31);
            DateTime endDate = new DateTime(2023, 12, 31);
            com.Parameters.AddWithValue("@start_date", startDate);
            com.Parameters.AddWithValue("@end_date", endDate);

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                emplist.Add(
                    new PayrollEmployee
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Name = Convert.ToString(dr["name"]),
                        Salary = Convert.ToString(dr["salary"]),
                        Start_date = DateTime.Parse(Convert.ToString(dr["start_date"])),
                        Gender = Convert.ToChar(dr["Gender"]),
                        Phone = Convert.ToString(dr["phone"]),
                        Address = Convert.ToString(dr["Address"]),
                        Department = Convert.ToString(dr["department"]),
                        Basic_pay = Convert.ToInt64(dr["basic_pay"]),
                        Deductions = Convert.ToInt64(dr["deductions"]),
                        Taxable_pay = Convert.ToInt64(dr["taxable_pay"]),
                        Income_tax = Convert.ToInt64(dr["income_tax"]),
                        Net_pay = Convert.ToInt64(dr["net_pay"])
                    }
                    );
            }
            foreach (var data in emplist)
            {
                Console.WriteLine(data.Id + " " + data.Name + " " + data.Salary + " " + data.Start_date + " " + data.Gender + " " + data.Phone + " " + data.Address + " " + data.Department + " " + data.Basic_pay + " " + data.Deductions + " " + data.Taxable_pay + " " + data.Income_tax + " " + data.Net_pay + " ");
            }
        }
    }
}
