using System;

namespace Reigns
{
    class Print
    {
        public static string Modifier(int number)
        {
            if (number == 0) return null;
            if (number > 0) return $"+{number}";
            return number.ToString();
        }

        public static string ProgressBar(int value)
        {
            char[] chars = new char[12];
            chars[0] = '[';
            chars[11] = ']';

            for (int i = 1; i < 11; i++)
            {
                chars[i] = '-';
            }

            double val10 = value / 10;

            int length = (int)Math.Round(val10);
            
            for (int i = 0; i < length; i++)
            {
                chars[i + 1] = '#';
            }

            string bar = new string(chars);
            return bar;

        }

        public static void StatPrint(int money, int army, int people, int church)
        {
            Console.WriteLine($"Money:  {ProgressBar(money)} {money}");
            Console.WriteLine($"Army:   {ProgressBar(army)} {army}");
            Console.WriteLine($"People: {ProgressBar(people)} {people}");
            Console.WriteLine($"Church: {ProgressBar(church)} {church}");
            Console.WriteLine("");
        }

        public static void StatPrint(int money, int army, int people, int church, int e1, int e2, int e3, int e4)
        {
            Console.WriteLine($"Money:  {ProgressBar(money)} {money} {Modifier(e1)}");
            Console.WriteLine($"Army:   {ProgressBar(army)} {army} {Modifier(e2)}");
            Console.WriteLine($"People: {ProgressBar(people)} {people} {Modifier(e3)}");
            Console.WriteLine($"Church: {ProgressBar(church)} {church} {Modifier(e4)}");
            Console.WriteLine("");
        }

        public static void StatPrint(int score, int money, int army, int people, int church)
        {
            Console.WriteLine($"Day {score}");
            Console.WriteLine("");
            Console.WriteLine($"Money:  {ProgressBar(money)} {money}");
            Console.WriteLine($"Army:   {ProgressBar(army)} {army}");
            Console.WriteLine($"People: {ProgressBar(people)} {people}");
            Console.WriteLine($"Church: {ProgressBar(church)} {church}");
            Console.WriteLine("");
        }
        
        public static void StatPrint(int score, int money, int army, int people, int church, int e1, int e2, int e3, int e4)
        {
            Console.WriteLine($"Day {score}.");
            Console.WriteLine("");
            Console.WriteLine($"Money:  {ProgressBar(money)} {money} {Modifier(e1)}");
            Console.WriteLine($"Army:   {ProgressBar(army)} {army} {Modifier(e2)}");
            Console.WriteLine($"People: {ProgressBar(people)} {people} {Modifier(e3)}");
            Console.WriteLine($"Church: {ProgressBar(church)} {church} {Modifier(e4)}");
            Console.WriteLine("");
        }
    }
}
