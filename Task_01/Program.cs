/*
*   Задача 1
    todo: В переменной string есть секретное сообщение, во второй есть пароль. Пользователю программы даётся 3 попытки ввести пароль и увидеть секретное сообщение.

*/

// "закодированные данные"
const string topSecret = "Greate! Take your SUPER TOP SECRET !!!";
const string userPassword = "QWERTY";

// максимальное количество попыток 
const int maxCountEnter = 3;

// пользовательский ввод пароля
// параметры:
//      message - сообщение, отображаемое пользователю
// возврат:
//      строка пароля введенная пользователем
string InputPassword(string message)
{
    Console.Write(message);
    return Console.ReadLine();
}

// сравнение пароля пользователя с секретным паролем 
// параметры:
//      password - пользовательский пароль
// возврат:
//      true - пароли совпадают
//      false - пароли не совпадают
bool passwordCheck(string password)
{
    return password == userPassword;
}


// main body
int countEnter = 0;         // счетчик входа
string password;            // пароль от пользователя
bool closeSecret = true;    // признак запрета доступа

Console.Clear();
while (countEnter < maxCountEnter && closeSecret)
{
    password = InputPassword($"Input password ({maxCountEnter - countEnter} time(s) left): ");
    if (passwordCheck(password))
    {
        closeSecret = false;
    }
    else
    {
        Console.WriteLine("Wrong password!");
    }
    countEnter++;
}

if (closeSecret)
{
    Console.WriteLine("Access denied!");
}
else
{
    Console.WriteLine(topSecret);
}
