namespace PersonnelAccounting;

public enum Gender
{
    Male = 0,
    Female = 1
}

public enum JobTitle
{
    Artist = 0,
    Developer = 1,
    GameDesigner = 2
}

public enum Date
{
    Year,
    Mounth,
    Day
}

public class Employee
{
    public DateTime DateOfBirth { get; private set; }
    public DateTime DateStartWorking { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Patronymic { get; private set; }
    public Gender Gender { get; private set; }
    public JobTitle JobTitle { get; private set; }
    public string Phone { get; private set; }
    public string Email { get; private set; }

    public Employee(DateTime dateOfBirth, DateTime dateStartWorking, Gender gender, JobTitle jobTitle, 
        string phone, string email, string name, string surname, string patronymic)
    {
        DateOfBirth = dateOfBirth;
        DateStartWorking = dateStartWorking;
        Name = name;
        Surname = surname;
        Gender = gender;
        JobTitle = jobTitle;
        Phone = phone;
        Email = email;
        Patronymic = patronymic;
    }
}