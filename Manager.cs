namespace Lab6_S3
{
    /// <summary>
    /// Класс менеджера
    /// </summary>
    public class Manager : Employee
    {
        public Manager(string name, double baseSalary, IBankService bankService)
            : base(name, baseSalary, bankService)
        {
        }

        public override string GetInfo()
        {
            return "Manager";
        }
    }
}
