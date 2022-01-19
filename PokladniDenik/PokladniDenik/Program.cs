using System;
using System.Linq;

namespace RndSoubor
{
    class Program
    {
        static string[] LoadLines()
        {
            string path = @"C:\Users\admin\Documents\programování uwu\txt\PokladniDenik.txt";
            Console.WriteLine("Enter custom path or enter to keep default file");
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Invalid path, resetting to default");
                path = @"C:\Users\admin\Documents\programování uwu\txt\PokladniDenik.txt";
                lines = System.IO.File.ReadAllLines(path);
            }

            return lines;
        }
        static void PrintLines(string[] slova, int[] cisla)
        {

            int mezisoucet = cisla[0];
            int posCounter = 0;
            int negCounter = 0;

            for (int i = 0; i < slova.Length; i++)
            {
                if(i == 0)
                {
                    Console.WriteLine(slova[i] + " " + cisla[i]);
                    Console.WriteLine("");

                } else
                {
                    Console.WriteLine(mezisoucet + " " + slova[i] + " " + cisla[i]);
                    mezisoucet = mezisoucet + cisla[i];
                    
                    if(cisla[i] > 0)
                    {
                        posCounter = 0 + cisla[i];
                    } else
                    {
                        negCounter = 0 + cisla[i];
                    }
                }

            }

            Console.WriteLine("");
            Console.WriteLine("Konečná hodnota: " + mezisoucet);
            Console.WriteLine("Celkem kladné: " + posCounter);
            Console.WriteLine("Celkem záporné: " + negCounter);
            Console.WriteLine("Celkem změna: " + (posCounter + negCounter));

        }
        static void DeleteLines(ref string[] slova, ref int[] cisla)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Enter new starting value");
                string input = Console.ReadLine();
                int newSV;
                if (!int.TryParse(input, out newSV))
                {
                    Console.WriteLine("Make sure you're entering an integer");
                    running = false;
                }
                Array.Clear(slova, 0, slova.Length);
                Array.Resize(ref slova, 1);
                Array.Clear(cisla, 0, cisla.Length);
                Array.Resize(ref cisla, 1);
                slova[0] = "startingValue";
                cisla[0] = newSV;
                running = false;
            }
            
        }
        static void AddLines(ref string[] slova, ref int[] cisla)
        {
            bool running = true;
            string newName;
            string newValue;
            int newInt;

            while (running)
            {
                Console.WriteLine("Add name of new item");
                newName = Console.ReadLine();
                string[] spaceCheck = newName.Split(' ');
                if (spaceCheck.Length > 1)
                {
                    Console.WriteLine("Make sure your formatting is correct.");
                    break;
                }
                Console.WriteLine("Add value of new item");
                newValue = Console.ReadLine();
                if (!int.TryParse(newValue, out newInt))
                {
                    Console.WriteLine("Make sure you're entering an integer.");
                    break;
                }
                    
                Array.Resize(ref slova, slova.Length + 1);
                slova[slova.Length - 1] = newName;

                Array.Resize(ref cisla, cisla.Length + 1);
                cisla[cisla.Length - 1] = newInt;

                running = false;

            }
        }
        static void Main(string[] args)
        {
            string[] lines = LoadLines();

            string[] slova = new string[lines.Length];
            int[] cisla = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string e = lines[i];
                string[] temp = e.Split(' ');
                
                int tempInt = 0;

                try
                {
                    if (int.TryParse(temp[1], out tempInt))
                    {
                        cisla[i] = tempInt;
                        slova[i] = temp[0];
                    }
                }
                catch (Exception)
                {

                }

            }


            bool running = true;
            while (running)
            {
                Console.WriteLine("A to add new items, S to display all, D to delete all, Enter to end");
                switch (Console.ReadKey().KeyChar)
                {
                    case 'a':
                    case 'A':
                        Console.Clear();
                        AddLines(ref slova, ref cisla);
                        Console.ReadLine();
                        break;

                    case 's':
                    case 'S':

                        Console.Clear();
                        PrintLines(slova, cisla);
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 'd':
                    case 'D':

                        Console.Clear();
                        DeleteLines(ref slova, ref cisla);
                        Console.Clear();
                        break;

                    default:

                        Console.Clear();
                        running = false;
                        break;

                }
            }

            string[] output = new string[slova.Length];

            for (int i = 0; i < slova.Length; i++)
            {
                output[i] = slova[i] + " " + cisla[i];
            }

            string path = @"C:\Users\admin\Documents\programování uwu\txt\PokladniDenik.txt";
            System.IO.File.WriteAllLines(path, output);

        }
    }
}