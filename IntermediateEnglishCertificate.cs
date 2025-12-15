namespace Lab6_S3
{
    /// <summary>
    /// Декоратор для добавления сертификата английского языка уровня Intermediate
    /// </summary>
    public class IntermediateEnglishCertificate : EmployeeDecorator
    {
        public string ExaminationTitle { get; set; }
        public int YearOfCertificate { get; set; }

        public IntermediateEnglishCertificate(Employee employee, string examinationTitle, int yearOfCertificate)
            : base(employee)
        {
            ExaminationTitle = examinationTitle;
            YearOfCertificate = yearOfCertificate;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Intermediate English Certificate (Exam: '{ExaminationTitle}', Year: {YearOfCertificate})";
        }
    }
}
