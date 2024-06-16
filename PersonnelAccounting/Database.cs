namespace PersonnelAccounting;

public class Database
{
    private int _employeeID = 1;
    private List<Employee> _employeesList;

    public void AddNewEmployee(InputHandler inputHandler)
    {   int id = _employeeID;
        DateTime dateOfBirth;
        DateTime dateStartWorking;
        Gender gender;
        JobTitle jobTitle;
        string name;
        string surname;
        string patronymic = null;
        int phone;
        string email;
        
        SetFullName(inputHandler, out name, out surname, ref patronymic);
        SetDateOfBirth(inputHandler, out dateOfBirth);
        SetDateOfStartWorking(out dateStartWorking);
        
        _employeesList.Add(new Employee(id, dateOfBirth, dateStartWorking, gender, jobTitle, phone, 
            email, name, surname, ref patronymic));
        _employeeID++;
    }

    private void SetFullName(InputHandler inputHandler, out string name, out string surname, ref string patronymic)
    {
        Console.Clear();

        Console.Write("Введите имя сотрудника: ");
        name = inputHandler.GetUserAnswerForName();

        Console.Write("Введите фамилию: ");
        surname = inputHandler.GetUserAnswerForName();
        
        Console.Write("Введите отчество (если отчества нет, нажмите Enter): ");
        patronymic = inputHandler.GetUserAnswerForName();
    }

    private void SetDateOfBirth(InputHandler inputHandler, out DateTime dateOfBirth)
    {
        int year = inputHandler.GetUserAnswerForDate(Date.Year);
        int mounth = inputHandler.GetUserAnswerForDate(Date.Mounth);
        int day = inputHandler.GetUserAnswerForDate(Date.Day);
        
        dateOfBirth = new DateTime(year, mounth, day);
    }

    private void SetDateOfStartWorking(out DateTime dateStartWorking)
    {
        dateStartWorking = DateTime.Today;
    }
}