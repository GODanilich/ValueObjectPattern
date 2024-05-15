namespace Value_Object
{
    public class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();

            var one = new Address("1 Microsoft Way", "Redmond", "US");
            var two = new Address("1 Microsoft Way", "Redmond", "US");
            Console.WriteLine(EqualityComparer<Address>.Default.Equals(one, two)); // True
            Console.WriteLine(object.Equals(one, two)); // True
            Console.WriteLine(one.Equals(two)); // True
            Console.WriteLine(one == two); // True


            #region withPattern
            while (true)
            {
                Console.WriteLine("Вход в систему");
                Console.WriteLine("Для регистрации - нажмите R");
                Console.WriteLine("Для авторизации - нажмите L");

                ConsoleKeyInfo key = Console.ReadKey();
                switch(key.Key)
                {
                    case ConsoleKey.R:
                        Name? newUser = null;
                        Password? newPass = null;

                        Console.WriteLine("\nРегистрация");
                        
                        while (newUser is null)
                        {
                            Console.WriteLine("Введите Ваше имя:");
                            try
                            {
                                newUser = new(Console.ReadLine());
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        while (newPass is null)
                        {
                            Console.WriteLine("Введите Ваш пароль:");
                            try
                            {
                                newPass = new(Console.ReadLine());
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        
                        Authorization.SignUp(newUser, newPass);
                        break;


                    case ConsoleKey.L:
                        Name? User = null;
                        Password? Pass = null;

                        Console.WriteLine("\nАвторизация");

                        while (User is null)
                        {
                            Console.WriteLine("Введите Ваше имя:");
                            try
                            {
                                User = new(Console.ReadLine());
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        while (Pass is null)
                        {
                            Console.WriteLine("Введите Ваш пароль:");
                            try
                            {
                                Pass = new(Console.ReadLine());
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        Authorization.SignIn(User, Pass);
                        break;
                }
            }
            #endregion

            #region withoutPattern
            while (false)
            {
                Console.WriteLine("Вход в систему");
                Console.WriteLine("Для регистрации - нажмите R");
                Console.WriteLine("Для авторизации - нажмите L");

                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.R:
                        Console.WriteLine("\nРегистрация");
                        Console.WriteLine("Введите Ваше имя:");
                        string newUser = new(Console.ReadLine());
                        Console.WriteLine("Введите Ваш пароль:");
                        string newPass = new(Console.ReadLine());

                        Authorization.SignUpW(newUser, newPass);
                        break;
                    case ConsoleKey.L:
                        Console.WriteLine("\nАвторизация");
                        Console.WriteLine("Введите Ваше имя:");
                        string User = new(Console.ReadLine());
                        Console.WriteLine("Введите Ваш пароль:");
                        string Pass = new(Console.ReadLine());
                        Authorization.SignInW(User, Pass);
                        break;
                }
            }
            #endregion

        }
    }
}
