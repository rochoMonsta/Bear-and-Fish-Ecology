using System;
using System.Text;

namespace Bears
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            Console.Write("Enter coutn of age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter rivver count: ");
            int count = Convert.ToInt32(Console.ReadLine());

            string[] rivver = new string[count];
            string[] animals = new string[] { "Bear", "None", "Fish" };
            char[] symbols = new char[] { '\u265B', '\u265E', '_' };

            /*Генерування тварин або річки.*/

            for (int i = 0; i < rivver.Length; i++)
            {
                rivver[i] = animals[rand.Next(0, animals.Length)];
            }

            Console.WriteLine($"\nBear: {Convert.ToString(symbols[0])} ");
            Console.WriteLine($"Fish: {Convert.ToString(symbols[1])} ");
            Console.WriteLine($"Empty rivver space: {Convert.ToString(symbols[2])} \n");


            /*Цкил симуляції руху тварин в екології. Часткова вибірка
            для декількох виключень та руху тварин відповідно до 
            правил екології.*/

            for (int i = 0; i < age; i++)
            {
                AnimalSwitch(rivver, symbols);

                for (int j = 1; j < count - 1; j++)
                {

                    int randC = rand.Next(-1, 2);

                    randC = GetNumb(randC, j);

                    if (randC == j)
                    {
                        continue;
                    }
                    if (rivver[j] == "None")
                    {
                        continue;
                    }

                    if (rivver[j] == rivver[randC])
                    {
                        int index = GetIndex(rivver);
                        rivver[index] = rivver[j];
                        AnimalSwitch(rivver, symbols);
                        //continue;
                    }
                    if (rivver[j] == "Bear" && rivver[randC] == "Fish")
                    {
                        rivver[j] = "None";
                        rivver[randC] = "Bear";
                        AnimalSwitch(rivver, symbols);
                        //continue;
                    }
                    if (rivver[j] == "Bear" && rivver[randC] == "Fish")
                    {
                        rivver[j] = "None";
                        rivver[randC] = "Bear";
                        AnimalSwitch(rivver, symbols);
                        //continue;
                    }
                }

                Console.ReadKey();
            }

        }

        /*Пошук першої вільної ділянки річки для переміщення 
        розмноженого підвиду.*/

        public static int GetIndex(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == "None")
                {
                    return i;
                }
                else
                {
                    continue;
                }
            }
            return 0;
        }

        /*Виведення екологічної позиції річки в певний період часу.
        Вхідні дані: string[] rivver - стрінговий масив який представляє річку.
                     char[] symbols - чарівський масив що представляє символ елемента річки.*/

        public static void AnimalSwitch(string[] rivver, char[] symbols)
        {
            for (int i = 0; i < rivver.Length; i++)
            {
                switch (rivver[i])
                {
                    case "Bear": Console.Write($" {Convert.ToString(symbols[0])} "); break;
                    case "Fish": Console.Write($" {Convert.ToString(symbols[1])} "); break;
                    case "None": Console.Write($" {Convert.ToString(symbols[2])} "); break;
                    default: rivver[i] = null; break;
                }
            }
            Console.WriteLine("\n");
        }

        /*Виведення елементів річки.
        Вхідні дані: string[] rivver - стрінговий масив який представляє річку.*/


        public static void AnimalPrint(string[] rivver)
        {
            for (int i = 0; i < rivver.Length; i++)
            {
                Console.Write($" {rivver[i]} ");
            }
            Console.WriteLine("\n");
        }

        /*Віднаходження позиції в яку повина йти тварина після виконання рандому.
        Вхідні дані: int number - число згенероване рандомайзером.
                     int j - крок проходження циклу перерахування тварин в річці.
        Вихідні дані: int number - індекс елемента річки з якою повинен здійснюватись
                                   алгоритм екологічного ходу.*/

        public static int GetNumb(int number, int j)
        {
            switch(number)
            {
                case -1: number = j - 1; return number;
                case 0: number = j; return number; ;
                case 1: number = j + 1; return number;
            }
            return 0;
        }
    }
}
