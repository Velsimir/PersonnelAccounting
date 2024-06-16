﻿namespace PersonnelAccounting;

public class Employee
{
    public int Id { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public DateTime DateStartWorking { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Patronymic { get; private set; }
    public Gender Gender { get; private set; }
    public JobTitle JobTitle { get; private set; }
    public int Phone { get; private set; }
    public string Email { get; private set; }

    public Employee(int id, DateTime dateOfBirth, DateTime dateStartWorking, Gender gender, JobTitle jobTitle, 
        int phone, string email, string name, string surname, ref string patronymic)
    {
        Id = id;
        DateOfBirth = dateOfBirth;
        DateStartWorking = dateStartWorking;
        Name = name;
        Surname = surname;
        Gender = gender;
        JobTitle = jobTitle;
        Phone = phone;
        Email = email;

        if (patronymic != null)
            Patronymic = patronymic;
    }
}

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