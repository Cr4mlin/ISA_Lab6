namespace Lab6_S3
{
    /// <summary>
    /// Базовый абстрактный класс сотрудника
    /// </summary>
    public abstract class Employee
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }
        public IBankService BankService { get; set; }

        protected Employee(string name, double baseSalary, IBankService bankService)
        {
            Name = name;
            BaseSalary = baseSalary;
            BankService = bankService;
        }

        /// <summary>
        /// Возвращает информацию о сотруднике (должность)
        /// </summary>
        public abstract string GetInfo();

        /// <summary>
        /// Вычисляет зарплату с учётом комиссии банковского сервиса
        /// </summary>
        public virtual double CalculateSalary()
        {
            return BankService.CalculateSalary(BaseSalary);
        }
    }
}
