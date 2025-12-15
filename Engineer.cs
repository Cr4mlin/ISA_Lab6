namespace Lab6_S3
{
    /// <summary>
    /// Класс инженера
    /// </summary>
    public class Engineer : Employee
    {
        public Engineer(string name, double baseSalary, IBankService bankService)
            : base(name, baseSalary, bankService)
        {
        }

        public override string GetInfo()
        {
            return "Engineer";
        }
    }
}
