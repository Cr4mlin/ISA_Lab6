namespace Lab6_S3
{
    /// <summary>
    /// Сервис Газпромбанка с комиссией 1.5%
    /// </summary>
    public class Gazprombank : IBankService
    {
        public string Name => "Gazprombank";

        private const double Commission = 0.015; // 1.5%

        public double CalculateSalary(double baseSalary)
        {
            return baseSalary * (1 - Commission);
        }
    }
}
