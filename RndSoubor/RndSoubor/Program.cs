using System;

namespace RndSoubor
{
    class Program
    {
        static string[] LoadLines()
        {
            string path = @"C:\\Users\admin\Desktop\rndLines.txt";
            Console.WriteLine("Enter path or leave blank to keep default path");
            string input = Console.ReadLine();
            if (input != "")
            {
                path = input;
            }

            string[] lines = new string[0];

            try
            {
                lines = System.IO.File.ReadAllLines(path);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Reverting to default path.");
                path = @"C:\\Users\admin\Desktop\rndLines.txt";
                lines = System.IO.File.ReadAllLines(path);
            }

            return lines;
        }
        static void PrintLines(string[] lines2)
            //Mohlo by se to jmenovat lines, ale jsou to lines2 abych si pamatoval, že to je jiná proměnná (má jiný scope)
        {
            bool valid = false;

            while (!valid)
            {
                Console.WriteLine("Enter number of lines you want to print");
                string input = Console.ReadLine();
                //Tady už používám normálně input

                int value;


                if (int.TryParse(input, out value))
                {

                    if (value < 0)
                    {
                        value = Math.Abs(value);
                    }

                    int a = 0;
                    while (a < value)
                    {
                        int rnd = new Random().Next(1, lines2.Length);
                        Console.WriteLine(lines2[rnd]);
                        a++;
                    }
                    
                    valid = true;
                }


            }


        }

        static void PrintSingle(string[] lines2)
        {
            int rnd = new Random().Next(1, lines2.Length);
            Console.WriteLine(lines2[rnd]);

            bool runningSmol = true;
            while(runningSmol)

            switch (Console.ReadKey(true).KeyChar)
            {
                case ('s'):

                    rnd = new Random().Next(1, lines2.Length);
                    Console.WriteLine(lines2[rnd]);
                    break;

                default:

                    runningSmol = false;
                    break;
            }

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            string[] lines = LoadLines();

            bool running = true;
            while (running)
            {
                Console.WriteLine("P to print a number of lines, S to print single line, anything else to end program");
                switch (Console.ReadKey().KeyChar)
                {
                    case 'p':
                    case 'P':
                        Console.Clear();
                        PrintLines(lines);
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 's':
                    case 'S':

                        Console.Clear();
                        PrintSingle(lines);
                        break;

                    default:
                        
                        Console.Clear();
                        running = false;
                        break;

                }
            }
        }
    }
}
