/*
* Задача 2
  v 0.0 Есть программа с бесконечным циклом. Когда пользователь вводит exit программа заканчивается

  todo: v 0.1 Продолжаем прокачивать приложение с командами. Добавить к программе, которая заканчивается, 
    когда пишем exit еще 4 команды (их можно придумать самому). 
    Например: 
        SetName – Установить имя 
        Help – вывести список команд 
        SetPassword – Установить пароль 
        Exit – выход 
        WriteName – вывести имя после ввода пароля
*/



// возможные команды
const string exitWord = "exit";

// индексы в пользовательской информации 
const int userName = 0;
const int userPass = 1;

// пользовательская информация
string[] userInfo = { string.Empty, string.Empty };

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

// сообщениеи для проьзователя
// параметрыЖ
//      message - выводимое сообщение
void ShowMsg(string message)
{
    Console.WriteLine(message);
    Console.WriteLine("Press any key to continue ...");
    Console.ReadKey();
}

// вывод справки
// параметр:
//      нет
//возврат:
//      нет
void PrintHelp()
{
    Console.WriteLine("System help ");
    Console.WriteLine("\thelp                  - print program help");
    Console.WriteLine("\tset name [<username>] - set default user name");
    Console.WriteLine("\t\t   <username> - user name. If name is empty, program will ask it");
    Console.WriteLine("\tset password          - set system password");
    Console.WriteLine("\tget name              - print default user name after authorisation");
    Console.WriteLine("\texit                  - close program");
}

// обработчик команды пользователя, парсит пользовательский ввод. в зависимости от введенной команды 
// вызывает соответсвтвующий обработчик, возвращает признак завершения приложения
// параметры:
//      userWord - введенная пользователем команда
// возврат:
//      true - завершение программы
//      false - продолжение работы
bool CommandProcessor(string userWord)
{
    bool canExit = false;
    string[] command = userWord.Split(' '); 

    if (command.Length == 0)
    {
        ShowMsg("Wrong command!\nUse help command for information.");
        return canExit;
    }

    // команду в нижний регистр, избавляемся от лишних ToLover в проверках
    command[0] = command[0].ToLower();
    if(command.Length > 1)
        command[1] = command[1].ToLower();

    
    if(command[0] == "help"){
        PrintHelp();
    }
    else if(command[0] == "exit")
    {
        canExit = true;
    }
    else if(command.Length <2 ){
        ShowMsg("Wrong command format!\nUse help command for information.");
    }
    else if(command[0] == "get" && command[1] == "name"){
        // todo вызов отображения именни пользователя
    }
    else if(command[0] == "set" && command[1] == "name"){
        if(command.Length > 2)
        {
            // todo вызов ввода имевни с заданным параметром
        }
        else
        {
            // todo вызов задания имени с запросом параметра
        }
    }
    else if(command[0] == "set" && command[1] == "password"){
        // todo запрос пароля
    }
    else{
        ShowMsg("Wrong command format!\nUse help command for information.");
    }

    return canExit;
}



// main body
string command;         // пользовательский ввод

Console.Clear();

while (true)            // работаем бесконечно
{
    //PrintHelp();

    command = InputCommand("> ");
    if (CommandProcessor(command))
    {
        break;
    }
}

