/*
* Задача 2
  todo: Есть программа с бесконечным циклом. Когда пользователь вводит exit программа заканчивается
*/

// "кодовое" слово для завершения программы
const string exitWord = "exit";

// пользовательский ввод 
// параметры:
//      message - сообщение, отображаемое пользователю
// возврат:
//      строка команды введенная пользователем
string InputCommand(string message)
{
    Console.Write(message);
    return Console.ReadLine();
}

// регистронезависимое сравнение пользовательской команды с кодовым словом завершения
// параметры:
//      userWord - введенная пользователем команда
// возврат:
//      true - если userWord совпадает с командой выхода
//      false - если userWord не совпадает с командой выхода
bool CommandExit(string userWord)
{
    bool result = false;

    if (userWord.ToLower() == exitWord.ToLower())
    {
        result = true;
    }

    return result;
}

// main body
string command;         // пользовательский ввод

Console.Clear();

while (true)            // работаем бесконечно
{
    command = InputCommand("Input command: ");
    if (CommandExit(command))
    {
        break;
    }
}

