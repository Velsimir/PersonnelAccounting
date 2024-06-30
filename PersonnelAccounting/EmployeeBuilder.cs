namespace PersonnelAccounting;

public class EmployeeBuilder
{
    private InputHandler _inputHandler;

    public EmployeeBuilder(InputHandler inputHandler)
    {
        _inputHandler = inputHandler;
    }

    public Employee Create()
    {
        DateTime dateOfBirth;
        DateTime dateStartWorking;
        Gender gender;
        JobTitle jobTitle;
        string name;
        string surname;
        string patronymic;
        string phone;
        string email;
        
        SetFullName(out name, out surname, out patronymic);
        SetDateOfBirth(out dateOfBirth);
        SetDateOfStartWorking(out dateStartWorking);
        GetGender(out gender);
        GetJobTitle(out jobTitle);
        GetPhone(out phone);
        GetEmail(out email);
        
        Employee employee = new Employee(dateOfBirth, dateStartWorking, gender, jobTitle, phone, 
            email, name, surname, patronymic);

        return employee;
    }

    private void GetEmail(out  string email)
    {
        Console.WriteLine("Введите email сотрудника: ");

        email = Console.ReadLine();
    }
    
    private void GetPhone(out  string phone)
    {
        Console.WriteLine("Введите номер телефона сотрудника: ");

        phone = Console.ReadLine();
    }
    
    private void GetJobTitle(out JobTitle jobTitle)
    {
        string answer;
        int jobTitleValue = 0;
        bool isWorking = true;

        while (isWorking)
        {
            Console.WriteLine("Выбирете вакансию сотрудника: ");
            
            foreach (var jobType in Enum.GetValues(typeof(JobTitle)))
            {
                Console.WriteLine($"{jobType} - {jobType.GetHashCode()}");
            }
            
            answer = Console.ReadLine();

            if (_inputHandler.TryGetJobTitle(answer) == true)
            {
                jobTitleValue = Convert.ToInt32(answer);
                isWorking = false;
            }
        }

        jobTitle = (JobTitle)jobTitleValue;
    }

    private void GetGender(out Gender gender)
    {
        string answer;
        int genderValue = 0;
        bool isWorking = true;

        while (isWorking)
        {
            Console.WriteLine("Выбирете пол сотрудника: ");
            
            foreach (var genderType in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine($"{genderType} - {genderType.GetHashCode()}");
            }
            
            answer = Console.ReadLine();

            if (_inputHandler.TryGetGender(answer) == true)
            {
                genderValue = Convert.ToInt32(answer);
                isWorking = false;
            }
        }

        gender = (Gender)genderValue;
    }

    private void SetFullName(out string name, out string surname, out string patronymic)
    {
        name = GetName("Введите имя сотрудника: ");
        surname = GetName("Введите фамилию: ");
        patronymic = GetName("Введите отчество: ");
    }

    private string GetName(string question)
    {
        bool isWorking = true;
        string answer = null;
        
        while (isWorking)
        {
            Console.Write(question);
            answer = Console.ReadLine();
            
            if (_inputHandler.TryGetName(answer) == true)
                isWorking = false;
        }

        return answer;
    }

    private void SetDateOfBirth(out DateTime dateOfBirth)
    {
        bool isWorking = true;
        string dateSting;
        dateOfBirth = new DateTime(1,1,1);

        while (isWorking)
        {
            Console.WriteLine("Введите дату рождения сотрудника в формате день/месяц/год");
            dateSting = Console.ReadLine();
            
            if (_inputHandler.TryGetBirthDate(dateSting) == true)
            {
                dateOfBirth = SetBirthDate(dateSting);
                isWorking = false;
            }
        }
    }

    private DateTime SetBirthDate(string dateSting)
    {
        string[] dateStringsArray = dateSting.Split('/');
        int day = Convert.ToInt32(dateStringsArray[0]);
        int mounth = Convert.ToInt32(dateStringsArray[1]);
        int year = Convert.ToInt32(dateStringsArray[2]);
        
        DateTime date = new DateTime(year, mounth, day);

        return date;
    }
    
    private void SetDateOfStartWorking(out DateTime dateStartWorking)
    {
        dateStartWorking = DateTime.Today;
    }
}