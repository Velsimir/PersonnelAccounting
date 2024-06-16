using System.Diagnostics;

namespace PersonnelAccounting;

class Program
{
    static void Main(string[] args)
    {
        Database database = new Database();
        MainMenu mainMenu = new MainMenu();
        InputHandler inputHandler = new InputHandler();
        
        bool _isWorking = true;
        
        while (_isWorking == true)
        {
            mainMenu.ShowMainMenu();

            if (mainMenu.TryChoseNextSelection(inputHandler, inputHandler.GetUserAnswerForMenuChose()) == true)
            {
                mainMenu.ShowNextSelection(database, inputHandler, ref _isWorking);
            }
        }
    }
}