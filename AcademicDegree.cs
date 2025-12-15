namespace Lab6_S3
{
    /// <summary>
    /// Декоратор для добавления учёной степени
    /// </summary>
    public class AcademicDegree : EmployeeDecorator
    {
        public string DissertationTitle { get; set; }
        public int Year { get; set; }
        public string ScienceArea { get; set; }

        public AcademicDegree(Employee employee, string dissertationTitle, int year, string scienceArea)
            : base(employee)
        {
            DissertationTitle = dissertationTitle;
            Year = year;
            ScienceArea = scienceArea;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Academic Degree (Dissertation: '{DissertationTitle}', Year: {Year}, Area: {ScienceArea})";
        }
    }
}
