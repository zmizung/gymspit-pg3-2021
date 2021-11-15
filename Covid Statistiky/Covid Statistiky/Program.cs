using System;

namespace Covid_Statistiky
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dailyCases = { 5650, 9168, 14230, 10411, 13516, 14557, 9265, 3005, 5738, 9238, 8438, 9465, 9909, 7593 };
            Console.WriteLine("14 days worth of default daily case numbers have been loaded.");
            Console.ReadLine();
            
            bool running = true;
            while (running)
            {
                Console.Clear();

                Console.WriteLine("Select an action.");
                Console.WriteLine("");
                Console.WriteLine("1: Enter data");
                Console.WriteLine("2: Print all data");
                Console.WriteLine("3: Edit single piece of data");
                Console.WriteLine("4: Delete data");

                bool validInput;
                bool hasData = false;
                do
                {
                    validInput = false;
                    switch (Console.ReadKey().KeyChar)
                    {
                        case '1':

                            Console.Clear();

                            string input = "blank";
                            int output;
                            do
                            {
                                if (!hasData)
                                {
                                    Console.WriteLine("Start entering data starting from yesterday:");
                                }
                                else
                                {
                                    Console.WriteLine("Start entering data:");
                                }

                               
                                for (int i = 0; i < dailyCases.Length + 1; i++)
                                {
                                    if (i > dailyCases.Length - 1)
                                    {
                                        Array.Resize(ref dailyCases, dailyCases.Length + 1);
                                    }
                                    
                                    input = Console.ReadLine();
                                    validInput = int.TryParse(input, out output);
                                    if (!validInput)
                                    {
                                        break;
                                    } else
                                    {
                                        hasData = true;
                                    }
                                    dailyCases[i] = output;
                                    
                                }

                            } while (!hasData);

                            
                            break;

                        case '2':


                            Console.Clear();

                            Console.WriteLine("Daily cases, going backwards from yesterday:");

                            Console.WriteLine("");
                            Console.WriteLine("Yesterday: " + (dailyCases[0]));

                            for (int j = 1; j < dailyCases.Length; j++)
                            {
                                Console.WriteLine("Y-"+ (j)+ ": "+ (dailyCases[0 + j]));
                            }

                            Console.ReadLine();

                            break;
                        case '3':

                            Console.Clear();

                            Console.WriteLine("Select an index to edit.");
                            string indexInput = Console.ReadLine();
                            int indexSelection;
                            if (!int.TryParse(indexInput, out indexSelection))
                            {
                                break;
                            } else
                            {
                                Console.WriteLine("Enter the new value for selected index.");
                                string valueInput = Console.ReadLine();
                                int newValue;
                                if (!int.TryParse(valueInput, out newValue))
                                {
                                    break;
                                }
                                else
                                {
                                    if (indexSelection > dailyCases.Length)
                                    {
                                        indexSelection = dailyCases.Length - 1;
                                    }
                                    if (indexSelection < 0)
                                    {
                                        indexSelection = 0;
                                    }
                                    dailyCases[indexSelection] = newValue;
                                }
                            }

                            break;
                        case '4':

                            Console.Clear();

                            Console.WriteLine("Select deletion method.");
                            Console.WriteLine("");
                            Console.WriteLine("1: Delete all data");
                            Console.WriteLine("2: Delete part of data");
                            Console.WriteLine("3: Back to main menu");

                            switch (Console.ReadKey().KeyChar)
                            {
                                case '1':

                                    Console.Clear();
                                    
                                    Console.WriteLine("Are you sure you want to delete all data? (Y to proceed)");
                                    string ans1;
                                    ans1 = Console.ReadLine();
                                    if (ans1 == "yes" || ans1 == "y" || ans1 == "Yes" || ans1 == "Y" || ans1 == "YES")
                                    {

                                        int i = 0;
                                        foreach (int e in dailyCases)
                                        {
                                            dailyCases[i] = 0; i++;
                                        }

                                        Console.WriteLine("Data deleted successfully.");
                                        Console.ReadLine();
                                    }
                                    
                                    break;

                                case '2':

                                    Console.Clear();

                                    Console.WriteLine("Enter number of days to erase.");
                                    Console.WriteLine("Inputting a positive number will result in deleting data starting from yesterday.");
                                    Console.WriteLine("Inputting a negative number will result in deleting data starting at the end of the array.");

                                    string ans2 = Console.ReadLine();
                                    int ans2n;
                                    int.TryParse(ans2, out ans2n);
                                    if (ans2n == 0 || ans2 == "")
                                    {

                                        break;

                                    } else if (ans2n > 0)
                                    {
                                        if (ans2n > dailyCases.Length)
                                        {
                                            ans2n = dailyCases.Length;
                                        }
                                        for (int k = 0; k < ans2n; k++)
                                        {
                                            dailyCases[k] = 0;
                                        }
                                        
                                        Console.WriteLine("Data deleted successfully.");
                                        Console.ReadLine();

                                    } else if (ans2n < 0)
                                    {

                                        Array.Reverse(dailyCases);


                                        if (Math.Abs(ans2n) > dailyCases.Length)
                                        {
                                            ans2n = dailyCases.Length;
                                        }

                                        for (int l = 0; l < Math.Abs(ans2n); l++)
                                        {
                                            dailyCases[l] = 0;
                                        }

                                        Array.Reverse(dailyCases);

                                        Console.WriteLine("Data deleted successfully.");
                                        Console.ReadLine();
                                    }

                                    break;

                                case '3':

                                    break;
                            }

                            
                            break;

                        default:
                            validInput = true;
                            break;



                    }

                } while (validInput);

            }
        }
    }
}
