namespace PayrollService
{
    internal class PayrollEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
        public DateTime Start_date { get; set; }
        public char Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public long Basic_pay { get; set; }
        public long Deductions { get; set; }
        public long Taxable_pay { get; set; }
        public long Income_tax { get; set; }
        public long Net_pay { get; set; }
    }
}