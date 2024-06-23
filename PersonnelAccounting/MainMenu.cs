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

    private string[] _selections;
    private string _lastUserInput = null;

    public MainMenu()
    {
        _selections = new[]
        {
            AddEmployee, EditEmployee, DeleteEmployee, 
            ShowAllEmployees, SearchEmployee, FilterEmployees, Exit
        };
    }

    public void ShowMainMenu()
    {
        Console.Write($"Введите команду для продолжения" +
                      $"\n{AddEmployee} - Добавить нового сотрудника" +
                      $"\n{EditEmployee} - Редактировать информацию сотрудника" +
                      $"\n{DeleteEmployee} - Удалить сотрудника из базы" +
                      $"\n{ShowAllEmployees} - Показать всех текущих сотрудников" +
                      $"\n{SearchEmployee} - Поиск сотрудника по критериям" +
                      $"\n{FilterEmployees} - Отфильтровать сотрудников по критериям" +
                      $"\n{Exit} - Завершить работу" +
                      $"\nВвод пользователя: ");
    }

    public void ShowNextSelection(Database database, InputHandler inputHandler, ref bool isWorking)
    {
        switch (_lastUserInput)
        {
            case AddEmployee:
                break;
            
            case EditEmployee: 
                break;
            
            case DeleteEmployee:
                break;
            
            case ShowAllEmployees:
                break;
            
            case SearchEmployee:
                break;
            
            case FilterEmployees:
                break;
            
            case Exit:
                isWorking = false;
                break;
            
            default:
                inputHandler.IncorrectInput();
                break;
        }
    }

    public bool TryChoseNextSelection(InputHandler inputHandler, string userInput)
    {
        _lastUserInput = userInput;
        
        foreach (var selection in _selections)
        {
            if (selection == userInput)
                return true;
        }
        
        inputHandler.IncorrectInput();
        
        return false;
    }
}