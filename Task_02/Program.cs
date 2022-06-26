/**
*  Задача 2
*  v 0.0 Есть программа с бесконечным циклом. Когда пользователь вводит exit программа заканчивается

*  todo: v 0.1 Продолжаем прокачивать приложение с командами. Добавить к программе, которая заканчивается, 
*    когда пишем exit еще 4 команды (их можно придумать самому). 
*    Например: 
*        SetName – Установить имя 
*        Help – вывести список команд 
*        SetPassword – Установить пароль 
*        Exit – выход 
*        WriteName – вывести имя после ввода пароля
*/


// индексы в пользовательской информации 
const int userNamePos = 0;
const int userPassPos = 1;

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
//      userData - пользовательские данные
// возврат:
//      true - завершение программы
//      false - продолжение работы
bool CommandProcessor(string userWord, string[] userData)
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
    if (command.Length > 1)
        command[1] = command[1].ToLower();


    if (command[0] == "help")
    {
        PrintHelp();
    }
    else if (command[0] == "exit")
    {
        canExit = true;
    }
    else if (command.Length < 2)
    {
        ShowMsg("Wrong command format!\nUse help command for information.");
    }
    else if (command[0] == "get" && command[1] == "name")
    {
        PrintUserName(userData);
    }
    else if (command[0] == "set" && command[1] == "name")
    {
        if (command.Length > 2)
        {
            SetUserName(userData, command[2]);
        }
        else
        {
            SetUserName(userData, string.Empty);
        }
    }
    else if (command[0] == "set" && command[1] == "password")
    {
        SetPassword(userData);
    }
    else
    {
        ShowMsg("Wrong command format!\nUse help command for information.");
    }

    return canExit;
}

// запрос пароля для проверки
// параметры:
//      arrayUserInfo - массив пользовательской информации
// возврат:
//      результат проверки запрошенного пароля
//      true - проль введен вверно
//      false - пароль введен неверно
bool AskPassword(string[] arrayUserInfo)
{
    bool result = false;

    string password = InputCommand("Enter password: ");
    if(arrayUserInfo[userPassPos] == password)
        result = true;
    
    return result;
}


// вывод имени пользователя по авторизаци
// параметры:
//      arrayUserInfo - массив пользовательской информации
// возврат:
//      нет
void PrintUserName(string[] arrayUserInfo)
{
    if(AskPassword(arrayUserInfo))
    {
        ShowMsg($"User name: {arrayUserInfo[userNamePos]}");
    }
    else
    {
        ShowMsg("Wrong password!");
    }
}


// установить иммя пользователя 
// параметры:
//      arrayUserInfo - массив пользовательской информации
//      newName - новое имя пользователя, если пусто - имя запрашиваетсяя 
// возврат:
//      результат установки имени
//      true - пароль установлен
//      false - ошибка при установке пароля
bool SetUserName(string[] arrayUserInfo, string newName){
    bool result = false;

    if(AskPassword(arrayUserInfo))
    {
        if(newName == string.Empty)
            newName = InputCommand("New user name:");
        userInfo[userNamePos] = newName;
        ShowMsg("User name changed.");
        result = true;
    }  
    else{
        ShowMsg("Wrong password!");
    }

    return result;
}


// установка нового пароля
// параметры:
//      arrayUserInfo - массив пользовательской информации
// возврат:
//      результат установки пароля
//      true - пароль установлен
//      false - ошибка при установке пароля
bool SetPassword(string[] arrayUserInfo)
{
    bool result = false;
    string oldPassword, newPassword, confirmPassword;

    oldPassword = InputCommand("Enter old password: ");
    newPassword = InputCommand("Enter new password: ");
    confirmPassword = InputCommand("Confirm new password: ");

    if(oldPassword != arrayUserInfo[userPassPos]){
        ShowMsg("Password is wrong!");
    }
    else if(newPassword != confirmPassword){
        ShowMsg("Password and confirmation do not match!");
    }
    else
    {
        arrayUserInfo[userPassPos] = newPassword;
        result = true;
        ShowMsg("Password changed!");
    }

    return result;
}

// main body
string command;         // пользовательский ввод

Console.Clear();

while (true)            // работаем бесконечно
{
    command = InputCommand("> ");
    if (CommandProcessor(command, userInfo))
    {
        break;
    }
}

