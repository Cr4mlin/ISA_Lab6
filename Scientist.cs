namespace Lab6_S3
{
    /// <summary>
    /// Класс учёного
    /// </summary>
    public class Scientist : Employee
    {
        public Scientist(string name, double baseSalary, IBankService bankService)
            : base(name, baseSalary, bankService)
        {
        }

        public override string GetInfo()
        {
            return "Scientist";
        }
    }
}
