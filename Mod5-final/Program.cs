namespace Mod5_final
{
    internal class Program
    {
        // Метод добавления пользователя
        static (string Name, string LastName, int Age, string[] NamePet, string[] Color) EnterUser()
        {
            //Объявление кортежа
            (string Name, string LastName, int Age, string[] NamePet, string[] Color) User;
            // Ввод имени пользователя
            do
            {
                Console.WriteLine("Введите имя");
                User.Name = Console.ReadLine();
            } while (CheckName(User.Name));
            // Ввод фамилии пользователя
            do
            {
                Console.WriteLine("Введите фамилию");
                User.LastName = Console.ReadLine();
            } while (CheckName(User.LastName));
            // ввод возраста пользователя
            string age;
            int intage;
            do
            {
                Console.WriteLine("Введите возраст");
                age = Console.ReadLine();
            } while (CheckAge(age, out intage));
            User.Age = intage;
            //Проверка на наличие питомца(-ев)
            Console.WriteLine("Есть ли у Вас питомец? Да или нет?");
            string hasPet = "Нет";
            hasPet = Console.ReadLine();

            int pet; // количество питомцев
            // Если питомцы есть, запрашиваем количество и клички питомцев
            if (hasPet == "Да")
            {
                // Ввод количество питомцев
                string countPet; // количество питомцев для проверки на правильность ввода данных
                int intpet;
                do
                {
                    Console.WriteLine("Введите количество питомцев");
                    countPet = Console.ReadLine();
                } while (CheckCount(countPet, out intpet));
                pet = intpet;
                //Ввод кличек питомцев
                User.NamePet = EnterNamePet(pet);
            }
            else
            {
                var array = new string[1];
                array[0] = "Питомцев нет";
                User.NamePet = array;
            }
            // Ввод количества любимых цветов
            int col; // количество цветов
            string countColor; // количество любимых цветов для проверки на правильность ввода данных
            int intcolor;
            do
            {
                Console.WriteLine("Введите количество любимых цветов");
                countColor = Console.ReadLine();
            } while (CheckCount(countColor, out intcolor));
            col = intcolor;
            // Ввод любимых цветов
            if (col > 0)
            {
                User.Color = EnterColor(col);
            }
            else
            {
                var array = new string[1];
                array[0] = "Любимых цветов нет";
                User.Color = array;
            }
            return User;
            
        }
        // Метод проверки введенных польхователем текстовых данных
        static bool CheckName(string Name) 
        {
            if (Name.All(Char.IsLetter))
            {
                return false;
            }
            else
            {
                Console.WriteLine("Данные введены не верно!");
                return true;
            }

        }
        // Метод проверки введенный пользователм числовых данных (Возраст)
        static bool CheckAge(string number, out int corrnamber)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnamber = intnum;
                    return false;
                }
            }
            Console.WriteLine("Данные введены не верно!");
            corrnamber = 0;
            return true;
        }
        // Метод проверки введенный пользователм числовых данных (Количество)
        static bool CheckCount(string number, out int corrnamber)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum >= 0)
                {
                    corrnamber = intnum;
                    return false;
                }
            }
            Console.WriteLine("Данные введены не верно!");
            corrnamber = 0;
            return true;
        }
        // Метод ввод кличек питомцев
        static string[] EnterNamePet(int count)
        {
            var result = new string[count];
            for (int i = 0; i < count; i++)
            {
                do
                {
                    Console.WriteLine("Введите кличку питомца");
                    result[i] = Console.ReadLine();
                } while (CheckName(result[i]));
            }
            return result;
        }
        //Метод ввода любимых цветов
        static string[] EnterColor(int count)
        {
            var result = new string[count];
            for (int i = 0; i < count; i++)
            {
                do
                {
                    Console.WriteLine("Введите любимый цвет");
                    result[i] = Console.ReadLine();
                } while (CheckName(result[i]));
            }
            return result;
        }

        //Метод вывода данных пользователя на экран
        static void PrintUser((string Name, string LastName, int Age, string[] NamePet, string[] Color) User)
        {
            //Вывод на экран: имя, фамилия и возраст пользователя
            Console.Write("Имя пользователя: {0}\nФамилия пользователя: {1}\nВозраст пользователя: {2}\n", User.Name, User.LastName, User.Age);
            //Вывод на экран клички питомцев
            foreach (var item in User.NamePet)
            {
                Console.Write("Кличка Вашего петомца: {0}\n", item);
            }
            foreach (var item in User.Color)
            {
                Console.Write("Ваш любимый цвет: {0}\n", item);
            }

        }
        static void Main(string[] args)
        {
            var User = EnterUser();
            PrintUser(User);

        }
    }
}