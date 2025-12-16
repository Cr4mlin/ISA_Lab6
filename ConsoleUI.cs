using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab6_S3
{
    /// <summary>
    /// Класс для управления консольным интерфейсом
    /// </summary>
    public class ConsoleUI
    {
        private List<Employee> employees = new List<Employee>();
        private IBankService sberbank = new Sberbank();
        private IBankService gazprombank = new Gazprombank();

        public void Run()
        {
            Console.WriteLine("Система управления сотрудниками компании Employee\n");

            bool exit = false;
            while (!exit)
            {
                ShowMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        ViewAllEmployees();
                        break;
                    case "3":
                        AddQualificationToEmployee();
                        break;
                    case "4":
                        ChangeBankService();
                        break;
                    case "5":
                        ViewEmployeeDetails();
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("\nДо свидания!");
                        break;
                    default:
                        Console.WriteLine("\nНеверный выбор. Попробуйте снова.\n");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private void ShowMainMenu()
        {
            Console.WriteLine("           ГЛАВНОЕ МЕНЮ                   ");
            Console.WriteLine("────────────────────────────────────────");
            Console.WriteLine("1. Добавить сотрудника");
            Console.WriteLine("2. Просмотр всех сотрудников");
            Console.WriteLine("3. Добавить квалификацию сотруднику");
            Console.WriteLine("4. Изменить банк для сотрудника");
            Console.WriteLine("5. Подробная информация о сотруднике");
            Console.WriteLine("0. Выход");
            Console.Write("\nВыберите пункт меню: ");
        }

        private void AddEmployee()
        {
            Console.Clear();
            Console.WriteLine("=== ДОБАВЛЕНИЕ НОВОГО СОТРУДНИКА ===\n");

            Console.Write("Введите имя сотрудника: ");
            string name = Console.ReadLine();

            Console.WriteLine("\nВыберите должность:");
            Console.WriteLine("1. Инженер (Engineer)");
            Console.WriteLine("2. Менеджер (Manager)");
            Console.WriteLine("3. Учёный (Scientist)");
            Console.Write("Ваш выбор: ");
            string positionChoice = Console.ReadLine();

            Console.Write("\nВведите базовую зарплату: ");
            if (!double.TryParse(Console.ReadLine(), out double salary))
            {
                Console.WriteLine("Неверный формат зарплаты!");
                return;
            }

            Console.WriteLine("\nВыберите банк:");
            Console.WriteLine("1. Sberbank (комиссия 1%)");
            Console.WriteLine("2. Gazprombank (комиссия 1.5%)");
            Console.Write("Ваш выбор: ");
            string bankChoice = Console.ReadLine();

            IBankService bank = bankChoice == "1" ? sberbank : gazprombank;

            Employee employee = null;
            switch (positionChoice)
            {
                case "1":
                    employee = new Engineer(name, salary, bank);
                    break;
                case "2":
                    employee = new Manager(name, salary, bank);
                    break;
                case "3":
                    employee = new Scientist(name, salary, bank);
                    break;
                default:
                    Console.WriteLine("Неверный выбор должности!");
                    return;
            }

            employees.Add(employee);
            Console.WriteLine($"\nСотрудник {name} успешно добавлен!");
        }

        private void ViewAllEmployees()
        {
            Console.Clear();
            Console.WriteLine("=== СПИСОК ВСЕХ СОТРУДНИКОВ ===\n");

            if (employees.Count == 0)
            {
                Console.WriteLine("Список сотрудников пуст.");
                return;
            }

            for (int i = 0; i < employees.Count; i++)
            {
                var emp = employees[i];
                Console.WriteLine($"№ {i + 1}, Имя: {emp.Name}, Должность: {GetPositionName(emp)}, Базовая з/п: {emp.BaseSalary}, З/п после комиссии: {emp.CalculateSalary():F2}");
            }
        }

        private void AddQualificationToEmployee()
        {
            Console.Clear();
            Console.WriteLine("=== ДОБАВЛЕНИЕ КВАЛИФИКАЦИИ ===\n");

            if (employees.Count == 0)
            {
                Console.WriteLine("Список сотрудников пуст.");
                return;
            }

            ViewAllEmployees();
            Console.Write("\nВведите номер сотрудника: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > employees.Count)
            {
                Console.WriteLine("Неверный номер сотрудника!");
                return;
            }

            Console.WriteLine("\nВыберите тип квалификации:");
            Console.WriteLine("1. Учёная степень (Academic Degree)");
            Console.WriteLine("2. Сертификат английского Intermediate");
            Console.Write("Ваш выбор: ");
            string qualChoice = Console.ReadLine();

            Employee emp = employees[index - 1];

            switch (qualChoice)
            {
                case "1":
                    Console.Write("\nНазвание диссертации: ");
                    string dissertationTitle = Console.ReadLine();
                    Console.Write("Год защиты: ");
                    if (!int.TryParse(Console.ReadLine(), out int year))
                    {
                        Console.WriteLine("Неверный формат года!");
                        return;
                    }
                    Console.Write("Область науки: ");
                    string scienceArea = Console.ReadLine();

                    employees[index - 1] = new AcademicDegree(emp, dissertationTitle, year, scienceArea);
                    Console.WriteLine("\nУчёная степень успешно добавлена!");
                    break;

                case "2":
                    Console.Write("\nНазвание экзамена (например, IELTS, TOEFL): ");
                    string examTitle = Console.ReadLine();
                    Console.Write("Год получения сертификата: ");
                    if (!int.TryParse(Console.ReadLine(), out int certYear))
                    {
                        Console.WriteLine("Неверный формат года!");
                        return;
                    }

                    employees[index - 1] = new IntermediateEnglishCertificate(emp, examTitle, certYear);
                    Console.WriteLine("\nСертификат английского успешно добавлен!");
                    break;

                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
        }

        private void ChangeBankService()
        {
            Console.Clear();
            Console.WriteLine("=== ИЗМЕНЕНИЕ БАНКОВСКОГО СЕРВИСА ===\n");

            if (employees.Count == 0)
            {
                Console.WriteLine("Список сотрудников пуст.");
                return;
            }

            ViewAllEmployees();
            Console.Write("\nВведите номер сотрудника: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > employees.Count)
            {
                Console.WriteLine("Неверный номер сотрудника!");
                return;
            }

            Employee emp = employees[index - 1];
            Console.WriteLine($"\nТекущий банк: {emp.BankService.Name}");
            Console.WriteLine($"Текущая зарплата после комиссии: {emp.CalculateSalary():F2} руб.");

            Console.WriteLine("\nВыберите новый банк:");
            Console.WriteLine("1. Sberbank (комиссия 1%)");
            Console.WriteLine("2. Gazprombank (комиссия 1.5%)");
            Console.Write("Ваш выбор: ");
            string bankChoice = Console.ReadLine();

            IBankService newBank = bankChoice == "1" ? sberbank : gazprombank;
            emp.BankService = newBank;

            Console.WriteLine($"\nБанк изменён на {newBank.Name}!");
            Console.WriteLine($"Новая зарплата после комиссии: {emp.CalculateSalary():F2} руб.");
        }

        private void ViewEmployeeDetails()
        {
            Console.Clear();
            Console.WriteLine("=== ПОДРОБНАЯ ИНФОРМАЦИЯ О СОТРУДНИКЕ ===\n");

            if (employees.Count == 0)
            {
                Console.WriteLine("Список сотрудников пуст.");
                return;
            }

            ViewAllEmployees();
            Console.Write("\nВведите номер сотрудника: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > employees.Count)
            {
                Console.WriteLine("Неверный номер сотрудника!");
                return;
            }

            Employee emp = employees[index - 1];
            Console.WriteLine($"  Имя: {emp.Name}");
            Console.WriteLine($"  Информация: {emp.GetInfo()}");
            Console.WriteLine($"  Базовая зарплата: {emp.BaseSalary:F2} руб.");
            Console.WriteLine($"  Банковский сервис: {emp.BankService.Name}");
            Console.WriteLine($"  Зарплата после комиссии: {emp.CalculateSalary():F2} руб.");
        }

        private string GetPositionName(Employee emp)
        {
            string info = emp.GetInfo();
            if (info.Contains("Engineer")) return "Engineer";
            if (info.Contains("Manager")) return "Manager";
            if (info.Contains("Scientist")) return "Scientist";
            return "Unknown";
        }
    }
}
