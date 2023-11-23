using System;

class Company
{
    public string Name { get; set; }
    public string MainOfficeCity { get; set; }
    public string Position { get; set; }
    public double Salary { get; set; }
    public bool IsFullTimeEmployee { get; set; }

    public Company()
    {
    }

    public Company(string name, string mainOfficeCity, string position, double salary, bool isFullTimeEmployee)
    {
        Name = name;
        MainOfficeCity = mainOfficeCity;
        Position = position;
        Salary = salary;
        IsFullTimeEmployee = isFullTimeEmployee;
    }

    // Конструктор копіювання
    public Company(Company other)
    {
        Name = other.Name;
        MainOfficeCity = other.MainOfficeCity;
        Position = other.Position;
        Salary = other.Salary;
        IsFullTimeEmployee = other.IsFullTimeEmployee;
    }

    public override string ToString()
    {
        return $"{Name}, {Position}, {Salary:C}, Full Time: {IsFullTimeEmployee}";
    }
}

class Worker
{
    public string FullName { get; set; }
    public string HomeCity { get; set; }
    public DateTime StartDate { get; set; }
    public Company WorkPlace { get; set; }

    public Worker()
    {
    }

    public Worker(string fullName, string homeCity, DateTime startDate, Company workPlace)
    {
        FullName = fullName;
        HomeCity = homeCity;
        StartDate = startDate;
        WorkPlace = workPlace;
    }

    // Конструктор копіювання
    public Worker(Worker other)
    {
        FullName = other.FullName;
        HomeCity = other.HomeCity;
        StartDate = other.StartDate;
        WorkPlace = new Company(other.WorkPlace);
    }

    public int GetWorkExperience()
    {
        TimeSpan workExperience = DateTime.Now - StartDate;
        return (int)(workExperience.TotalDays / 30);
    }

    public bool LivesNotFarFromTheMainOffice()
    {
        return HomeCity.Equals(WorkPlace.MainOfficeCity, StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString()
    {
        return $"{FullName}, {HomeCity}, Start Date: {StartDate.ToShortDateString()}, Workplace: {WorkPlace}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of workers: ");
        int n = int.Parse(Console.ReadLine());

        Worker[] workers = new Worker[n];
        for (int i = 0; i < n; i++)
        {
            workers[i] = CreateWorkerFromConsole();
        }

        int choice;
        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Display information for a specific worker");
            Console.WriteLine("2. Display information for all workers");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the index of the worker: ");
                    int index = int.Parse(Console.ReadLine());
                    DisplayWorkerInformation(workers[index]);
                    break;
                case 2:
                    DisplayAllWorkersInformation(workers);
                    break;
                case 3:
                    Console.WriteLine("Exiting the program.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        } while (choice != 3);
    }

    static Worker CreateWorkerFromConsole()
    {
        Console.WriteLine("Enter worker information:");

        Console.Write("Full Name: ");
        string fullName = Console.ReadLine();

        Console.Write("Home City: ");
        string homeCity = Console.ReadLine();

        Console.Write("Start Date (YYYY-MM-DD): ");
        DateTime startDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter company information:");
        Company company = CreateCompanyFromConsole();

        return new Worker(fullName, homeCity, startDate, company);
    }

    static Company CreateCompanyFromConsole()
    {
        Console.Write("Company Name: ");
        string companyName = Console.ReadLine();

        Console.Write("Main Office City: ");
        string mainOfficeCity = Console.ReadLine();

        Console.Write("Position: ");
        string position = Console.ReadLine();

        Console.Write("Salary: ");
        double salary = double.Parse(Console.ReadLine());

        Console.Write("Is Full-Time Employee? (true/false): ");
        bool isFullTime = bool.Parse(Console.ReadLine());

        return new Company(companyName, mainOfficeCity, position, salary, isFullTime);
    }

    static void DisplayWorkerInformation(Worker worker)
    {
        Console.WriteLine("Worker Information:");
        Console.WriteLine(worker);
        Console.WriteLine($"Work Experience: {worker.GetWorkExperience()} months");
        Console.WriteLine($"Lives Not Far From Main Office: {worker.LivesNotFarFromTheMainOffice()}");
        Console.WriteLine();
    }

    static void DisplayAllWorkersInformation(Worker[] workers)
    {
        Console.WriteLine("All Workers Information:");
        foreach (var worker in workers)
        {
            DisplayWorkerInformation(worker);
        }
    }
}
