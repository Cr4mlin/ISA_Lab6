namespace Lab6_S3
{
    /// <summary>
    /// Интерфейс банковского сервиса (паттерн Стратегия)
    /// </summary>
    public interface IBankService
    {
        string Name { get; }

        /// <summary>
        /// Вычисляет зарплату с учётом комиссии банка
        /// </summary>
        /// <param name="baseSalary">Базовая зарплата</param>
        /// <returns>Зарплата после вычета комиссии</returns>
        double CalculateSalary(double baseSalary);
    }
}
