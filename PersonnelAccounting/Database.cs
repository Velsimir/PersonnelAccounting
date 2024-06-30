namespace PersonnelAccounting;

public class Database
{
    private List<Employee> _employeesList = new List<Employee>();

    public Database()
    {
        _employeesList.Add(new Employee(new DateTime(1996,4,23), DateTime.Now, 0, 0, "89996268862",
            "Velsimir@gmail.com", "Ivan", "Koniashov", "Dmitrievich"));
        _employeesList.Add(new Employee(new DateTime(1996,4,23), DateTime.Now, 0, 0, "89996268862",
            "Velsimir@gmail.com", "John", "Suvorov", "Abrammov"));
        _employeesList.Add(new Employee(new DateTime(1996,4,23), DateTime.Now, 0, 0, "89996268862",
            "Velsimir@gmail.com", "Brain", "Albertovich", "Sergeevich"));
        _employeesList.Add(new Employee( new DateTime(1996,4,23), DateTime.Now, 0, 0, "89996268862",
            "Velsimir@gmail.com", "Konor", "Koshmarov", "Turbazov"));
        _employeesList.Add(new Employee( new DateTime(1996,4,23), DateTime.Now, 0, 0, "89996268862",
            "Velsimir@gmail.com", "Alex", "Duremar", "Bulbovich"));
        _employeesList.Add(new Employee( new DateTime(1996,4,23), DateTime.Now, 0, 0, "89996268862",
            "Velsimir@gmail.com", "Sam", "Kapeckin", "Dmitrievich"));
    }

    public List<Employee> GetEmployeers()
    {
        List<Employee> employeesList = new List<Employee>();

        foreach (var employee in _employeesList)
        {
            employeesList.Add(employee);
        }

        return employeesList;
    }

    public void AddNewEmployee(Employee employee)
    {
        _employeesList.Add(employee);
    }

    public void DeleteEmployee(Employee employee)
    {
        _employeesList.Remove(employee);
    }

    public Employee GetEmployee(int index)
    {
        return _employeesList[index];
    }
}