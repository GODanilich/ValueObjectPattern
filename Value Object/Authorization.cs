using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Value_Object
{
    public static class Authorization
    {
        public static void SignUp(Name name, Password pass)
        {
            if (Storage.Instance.AuthorizationDict.ContainsKey(name))
            {
                Console.WriteLine("Пользователь уже зарегистрирован!");
            }
                Storage.Instance.AuthorizationDict.Add(name, pass);
        }
        public static void SignIn(Name name, Password pass)
        {
            if (Storage.Instance.AuthorizationDict.ContainsKey(name))
            {
                if (Storage.Instance.AuthorizationDict[name] == pass)
                {
                    Console.WriteLine($"Успешная авторизация, добро пожаловать, {name.Value}!");

                    if (Storage.Instance.AdressDict.ContainsKey(name))
                    {
                        Console.WriteLine($"Ваш адресс: {Storage.Instance.AdressDict[name].Street}," +
                            $" {Storage.Instance.AdressDict[name].City} , {Storage.Instance.AdressDict[name].Country}");
                    }
                    else
                    {
                        Console.WriteLine($"У вас не указан адресс, хотите его указать?");
                        Console.WriteLine($"Нажмите - Y чтобы задать адресс");
                        Console.WriteLine($"Нажмите - N чтобы выйти");
                        ConsoleKeyInfo key = Console.ReadKey();
                        switch (key.Key)
                        {
                            case ConsoleKey.Y:
                                Console.WriteLine($"Введите улицу:");
                                string street = Console.ReadLine();
                                Console.WriteLine($"Введите город:");
                                string city = Console.ReadLine();
                                Console.WriteLine($"Ведите страну:");
                                string country = Console.ReadLine();
                                Address adress = new(street, city, country);
                                Storage.Instance.AdressDict.Add(name, adress);
                                Console.WriteLine($"\nВаш адресс: {Storage.Instance.AdressDict[name].Street}," +
                           $" {Storage.Instance.AdressDict[name].City} , {Storage.Instance.AdressDict[name].Country}");
                                break;
                            case ConsoleKey.N:
                                break;
                        }
                    }
                }
                else { Console.WriteLine($"Неправильный пароль для пользователя {name.Value}"); }
            }
            else { Console.WriteLine($"Пользователь не существует"); }
        }

        #region without pattern
        public static void SignUpW(string name, string pass)
        {
            if (Storage.Instance.StorageDictW.ContainsKey(name))
            {
                Console.WriteLine("Пользователь уже зарегистрирован!");
            }
            Storage.Instance.StorageDictW.Add(name, pass);
        }
        public static void SignInW(string name, string pass)
        {
            if (Storage.Instance.StorageDictW.ContainsKey(name))
            {
                if (Storage.Instance.StorageDictW[name] == pass)
                {
                    Console.WriteLine($"Успешная авторизация, добро пожаловать, {name}!");

                }
                else { Console.WriteLine($"Неправильный пароль для пользователя {name}"); }
            }
            else { Console.WriteLine($"Пользователь не существует"); }
        }
        #endregion
    }
}
