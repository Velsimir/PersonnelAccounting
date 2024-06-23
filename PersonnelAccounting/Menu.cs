using System.Diagnostics;

namespace PersonnelAccounting;

public class MainMenu
{
    const string AddEmployee = "add";
    const string EditEmployee = "edit";
    const string DeleteEmployee = "delete";
    const string ShowAllEmployees = "show all";
    const string SearchEmployee = "search";
    const string FilterEmployees = "filter";
    const string Exit = "exit";

    private List<string> _selections;
    private Database _database;
    private InputHandler _inputHandler;
    private EmployeeBuilder _employeeBuilder;

    public MainMenu(Database database, InputHandler inputHandler, EmployeeBuilder employeeBuilder)
    {
        _selections.Add(AddEmployee);
        _selections.Add(EditEmployee);
        _selections.Add(DeleteEmployee);
        _selections.Add(ShowAllEmployees);
        _selections.Add(SearchEmployee);
        _selections.Add(FilterEmployees);
        _selections.Add(Exit);

        _database = database;
        _inputHandler = inputHandler;
        _employeeBuilder = employeeBuilder;
    }

    public void ShowMain()
    {
        Console.Write($"Введите команду для продолжения" +
                      $"\n{AddEmployee} - Добавить нового сотрудника" +
                      $"\n{EditEmployee} - Редактировать информацию сотрудника" +
                      $"\n{DeleteEmployee} - Удалить сотрудника из базы" +
                      $"\n{ShowAllEmployees} - Показать всех текущих сотрудников" +
                      $"\n{SearchEmployee} - Поиск сотрудника по критериям" +
                      $"\n{FilterEmployees} - Отфильтровать сотрудников по критериям" +
                      $"\n{Exit} - Завершить работу");
    }
    
    public void ShowNextSelection(ref bool isWorking)
    {
        Console.WriteLine("Введите команду:");
        string userInput = Console.ReadLine();

        if (TryChoseNextSelection(userInput))
        {
            
        }
        
        switch (userInput)
        {
            case AddEmployee:
                _database.AddNewEmployee(_employeeBuilder.Create());
                break;
            
            case EditEmployee: 
                break;
            
            case DeleteEmployee:
                break;
            
            case ShowAllEmployees:
                ShowEmployers();
                break;
            
            case SearchEmployee:
                break;
            
            case FilterEmployees:
                break;
            
            case Exit:
                isWorking = false;
                break;
            
            default:
                _inputHandler.IncorrectInput();
                break;
        }
    }

    public bool TryChoseNextSelection(string userInput)
    {
        foreach (var selection in _selections)
        {
            if (selection == userInput)
                return true;
        }
        
        _inputHandler.IncorrectInput();
        return false;
    }

    private void ShowEmployers()
    {
        List<Employee> listEmployers = _database.GetEmployeers();

        Console.WriteLine($"Имя \t Фамилия \t Отчество \t Вакансия \t Дата трудоустройства");
        foreach (var employee in listEmployers)
        {
            Console.WriteLine($"{employee.Name} |\t {employee.Surname} |\t {employee.Patronymic} |\t {employee.JobTitle} |\t {employee.DateStartWorking}");
        }
    }
}