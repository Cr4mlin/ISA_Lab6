namespace Lab6_S3
{
    /// <summary>
    /// Сервис Сбербанка с комиссией 1%
    /// </summary>
    public class Sberbank : IBankService
    {
        public string Name => "Sberbank";

        private const double Commission = 0.01; // 1%

        public double CalculateSalary(double baseSalary)
        {
            return baseSalary * (1 - Commission);
        }
    }
}
