using System.Diagnostics;

namespace PersonnelAccounting;

public class InputHandler
{
    private string _userResponse;
    private bool _isWorking = true;
    private int _minYear = 1920;
    private int _ageToStartWork = 18;
    private int _minDay = 1;
    private int _maxDay = 31;
    private int _minMouth = 1;
    private int _maxMounth = 12;
    private int _minCharForName = 2;
    
    public bool TryGetJobTitle(string jobToitleChose)
    {
        int temp;
        int maxEnumValue = Enum.GetValues(typeof(JobTitle)).Cast<int>().Max();
        int minEnumValue = Enum.GetValues(typeof(JobTitle)).Cast<int>().Min();

        if (Int32.TryParse(jobToitleChose, out temp) == true)
        {
            if (temp <= maxEnumValue && temp >= minEnumValue)
                return true;
            else
            {
                IncorrectInput();    
                return false;
            }
        }
        else
        {
            IncorrectInput();
            return false;
        }
    }

    public bool TryGetGender(string genderChose)
    {
        int temp;
        int maxEnumValue = Enum.GetValues(typeof(Gender)).Cast<int>().Max();
        int minEnumValue = Enum.GetValues(typeof(Gender)).Cast<int>().Min();

        if (Int32.TryParse(genderChose, out temp) == true)
        {
            if (temp <= maxEnumValue && temp >= minEnumValue)
                return true;
            else
            {
                IncorrectInput();
                return false;
            }
        }
        else
        {
            IncorrectInput();
            return false;
        }
    }

    public bool TryGetIDEmployee(string userInput, int maxIndex, ref int index)
    {
        if (Int32.TryParse(userInput, out index) && index <= maxIndex)
        {
            index = Convert.ToInt32(userInput) - 1;
            return true;
        }
        else
            return false;
    }

    public bool TryGetBirthDate(string dateString)
    {
        string[] dateSplit = dateString.Split('/');
        int temp;
        
        foreach (var date in dateSplit)
        {
            if (Int32.TryParse(date, out temp) == false)
            {
                IncorrectInput();
                return false;
            }
        }

        return true;
    }

    public bool TryGetName(string userAnser)
    {
        if (userAnser.Length > _minCharForName)
            return true;
        else
        {
            IncorrectInput();
            return false;
        }
    }
    
    public bool TryChoseNextMenu(List<string> selections, string userResponse)
    {
        StandardizeUserInput(ref userResponse);
        
        foreach (var selection in selections)
        {
            if (selection == userResponse)
                return true;
        }
        
        IncorrectInput();
        return false;
    }
        
    public void IncorrectInput()
    {
        Console.WriteLine("Введена не корректная комманда" +
                          "Нажмите любую клавишу для продолжения...");
    }

    private void StandardizeUserInput(ref string userInput)
    {
        userInput.ToLower();
        userInput.Trim();
    }
}