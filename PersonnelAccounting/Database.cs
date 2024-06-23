namespace PersonnelAccounting;

public class Database
{
    private List<Employee> _employeesList = new List<Employee>();

    public List<Employee> GetEmployees()
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
}