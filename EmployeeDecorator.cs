namespace Lab6_S3
{
    /// <summary>
    /// Абстрактный декоратор для сотрудников
    /// </summary>
    public abstract class EmployeeDecorator : Employee
    {
        protected Employee employee;

        protected EmployeeDecorator(Employee employee)
            : base(employee.Name, employee.BaseSalary, employee.BankService)
        {
            this.employee = employee;
        }

        public override string GetInfo()
        {
            return employee.GetInfo();
        }

        public override double CalculateSalary()
        {
            return employee.CalculateSalary();
        }
    }
}
