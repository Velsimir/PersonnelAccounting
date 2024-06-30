using System.Diagnostics;

namespace PersonnelAccounting;

class Program
{
    static void Main(string[] args)
    {
        Database database = new Database();
        InputHandler inputHandler = new InputHandler();
        EmployeeBuilder employeeBuilder = new EmployeeBuilder(inputHandler);
        Menu menu = new Menu(database, inputHandler, employeeBuilder);

        bool isWorking = true;

        while (isWorking)
        {
            menu.ShowMain();
            menu.ShowNextSelection(ref isWorking);
        }
    }
}