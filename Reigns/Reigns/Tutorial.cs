using System;

namespace Reigns
{
    class Tutorial
    {
        public static void Header()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Tutorial");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public static void Ender()
        {
            Console.WriteLine("(press enter to continue)");
            Console.ReadLine();
        }
        
        public static void ShowTutorial()
        {
            Header();
            Console.WriteLine("*Advisor Lex rushes into the room.*");
            Ender();

            Header();
            Console.WriteLine("Advisor: I bring bad news! Your mother, Queen Rosa, passed away last night. First of all, my deepest condolences.");
            Ender();

            Header();
            Console.WriteLine("Advisor: I know you'll need time to deal with the loss, but another important thing needs to be taken care of.");
            Console.WriteLine("You are now the ruler of this kingdom... Your Majesty.");
            Ender();

            Header();
            Console.WriteLine("You will have to take care of four major stats: the available money and gold reserves, the army, the happiness of the people and the church.");
            Console.WriteLine("It is essential to keep these four things balanced. Having too much of one or not enough could lead to something horrible!");
            Ender();

            Header();
            Print.StatPrint(50, 50, 50, 50);

            Console.WriteLine("You will make decisions using the Y and N keys. Your choices will have consequences, so choose wisely. Are you ready?");
            Console.WriteLine($"Y: I'm ready");
            Console.WriteLine($"N: Not really");

            while (true)
            {
                switch (Console.ReadKey(true).KeyChar)
                {
                    case 'y':
                    case 'Y':
                    case 'z':
                    case 'Z':
                        {
                            Header();
                            Print.StatPrint(50, 50, 50, 50, 25, 25, 25, 25);
                            Console.WriteLine("Brilliant! I must go now, but I will be back soon. Best of luck, Your Majesty!");
                            Ender();
                            break;
                        }
                    case 'n':
                    case 'N':
                        {
                            Header();
                            Print.StatPrint(50, 50, 50, 50, 25, 25, 25, 25);
                            Console.WriteLine("I'm sure you'll do alright! I must go now, but I will be back soon. Best of luck, Your Majesty!");
                            Ender();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please use the Y/N keys to select option.");
                            continue;
                        }
                }
                break;
            }

            Header();
            Print.StatPrint(75, 75, 75, 75);
            Console.WriteLine("Oh and dont forget – when any of the four stats reaches either 0 or 100, you are in danger!");
            Console.WriteLine("*Advisor Lex rushes out of the room*");
            Console.WriteLine();
            Console.WriteLine("Press enter to return to menu.");
            Console.ReadLine();
        }
    }
}
