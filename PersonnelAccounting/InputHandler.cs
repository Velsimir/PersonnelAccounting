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
    
    public string GetUserAnswerForMenuChose()
    {
        _userResponse = Console.ReadLine();
        StandardizeUserInput(ref _userResponse);

        return _userResponse;
    }

    public int GetUserAnswerForDate(Date date)
    {
        _isWorking = true;
        int dateNumber = 1;

        while (_isWorking)
        {
            ShowDateInfo(date);
            
            _userResponse = Console.ReadLine();
            
            if (Int32.TryParse(_userResponse, out dateNumber))
            {
                switch (date)
                {
                    case Date.Year:
                        if (dateNumber > _minYear && dateNumber < DateTime.Now.Year - _ageToStartWork)
                            _isWorking = false;
                        else
                            IncorrectInput();
                        
                        break;
                    
                    case Date.Mounth:
                        if (dateNumber >= _minMouth && dateNumber <= _maxMounth)
                            _isWorking = false;
                        else
                            IncorrectInput();
                        
                        break;
                    
                    case Date.Day:
                        if (dateNumber >= _minDay && dateNumber <= _maxDay)
                            _isWorking = false;
                        else
                            IncorrectInput();
                        
                        break;
                }
            }
            else
                IncorrectInput();
        }

        return dateNumber;
    }

    public string GetUserAnswerForName()
    {
        _isWorking = true;
        
        while (_isWorking)
        {
            _userResponse = Console.ReadLine();

            if (_userResponse.Length > _minCharForName)
                _isWorking = false;
            else
                IncorrectInput();
        }

        return _userResponse;
    }
        
    public void IncorrectInput()
    {
        Console.WriteLine("Введена не корректная комманда" +
                          "Нажмите любую клавишу для продолжения...");
        Console.ReadLine();
        Console.Clear();
    }

    private void StandardizeUserInput(ref string userInput)
    {
        userInput.ToLower();
        userInput.Trim();
    }

    private void ShowDateInfo(Date date)
    {
        switch (date)
        {
            case Date.Year:
                Console.WriteLine("Введите год: ");
                break;
                    
            case Date.Mounth:
                Console.WriteLine("Введите месяц: ");
                break;
                    
            case Date.Day:
                Console.WriteLine("Введите день: ");
                break;
        }
    }
}