namespace PersonnelAccounting;

public class Menu
{
    const string AddEmployee = "add";
    const string EditEmployee = "edit";
    const string DeleteEmployee = "delete";
    const string ShowAllEmployees = "show all";
    const string SearchEmployee = "search";
    const string FilterEmployees = "filter";
    const string Exit = "exit";

    private List<string> _selections = new List<string>();
    private Database _database;
    private InputHandler _inputHandler;
    private EmployeeBuilder _employeeBuilder;

    public Menu(Database database, InputHandler inputHandler, EmployeeBuilder employeeBuilder)
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
        
        if (_inputHandler.TryChoseNextMenu(_selections, userInput) == true)
        {
            switch (userInput)
            {
                case AddEmployee:
                    _database.AddNewEmployee(_employeeBuilder.Create());
                    break;
            
                case EditEmployee: 
                    break;
            
                case DeleteEmployee:
                    DeleteEmployeeByID();
                    break;
            
                case ShowAllEmployees:
                    ShowEmployers();
                    break;
            
                case SearchEmployee:
                    ShowEmployeeInfo();
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
    }

    private void DeleteEmployeeByID()
    {
        Employee employee;
        
        int index = SearchEmployeeByID();

        employee = _database.GetEmployee(index);
        
        _database.DeleteEmployee(employee);
    }
    
    private void ShowEmployeeInfo()
    {
        Employee employee;
        int correctIDforUser;
        int employeeID = SearchEmployeeByID();

        employee = _database.GetEmployee(employeeID);
        correctIDforUser = employeeID++;        
        
        Console.WriteLine($"ID: {correctIDforUser,-5} | Пол: {employee.Gender,-15} | Имя: {employee.Name,-15} | Фамилия: {employee.Surname,-15} | Отчество: {employee.Patronymic,-15} " +
                          $"| Дата рождения: {employee.DateOfBirth,-20} | Вакансия: {employee.JobTitle,-20} | Дата трудоустройства: {employee.DateStartWorking,-20} | Почта: {employee.Email,-20} " +
                          $"| Телефон: {employee.Phone,-20}");
    }

    private int SearchEmployeeByID()
    {
        string userInput;
        int index = 0;
        bool isWorking = true;
        
        while (isWorking)
        {
            ShowEmployers();

            Console.WriteLine("Введите ID пользователя:");
            userInput = Console.ReadLine();

            if (_inputHandler.TryGetIDEmployee(userInput, _database.GetEmployeers().Count, ref index))
                isWorking = false;
            else
                _inputHandler.IncorrectInput();
        }

        return index;
    }

    private void ShowEmployers()
    {
        int employeeID = 1;
        List<Employee> listEmployers = _database.GetEmployeers();

        Console.WriteLine($"{"ID",-5} | {"Имя",-15} | {"Фамилия",-15} | {"Отчество",-15} | {"Вакансия",-20} | {"Дата трудоустройства",-20}");
        Console.WriteLine(new string('-', 90));

        foreach (var employee in listEmployers)
        {
            Console.WriteLine($"{employeeID,-5} | {employee.Name,-15} | {employee.Surname,-15} | {employee.Patronymic,-15} | {employee.JobTitle,-20} | {employee.DateStartWorking,-20}");
            employeeID++;
        }
    }
}