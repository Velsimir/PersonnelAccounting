using System.Diagnostics;

namespace PersonnelAccounting;

class Program
{
    static void Main(string[] args)
    {
        EmployeeBuilder employeeBuilder = new EmployeeBuilder();
        InputHandler inputHandler = new InputHandler();
        Database database = new Database();
        Employee employee = employeeBuilder.Create(inputHandler);
        
        Console.WriteLine($"{employee.Name} {employee.Surname} {employee.Gender} {employee.JobTitle}");
        
        database.AddNewEmployee(employee);
    }
}