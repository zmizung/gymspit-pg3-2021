using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Running = true;
            bool Asking = true;
            string userInput;
            string picovinka;
            string a;
            string b;
            float numA;
            float numB;
            float result = 0;
            bool x;
            
            while (Running)
            {
                Console.WriteLine("ahoj pojd se mnou pocitat");
                Console.WriteLine("naval operator: +, -, *, /");
                picovinka = Console.ReadLine();

                Console.WriteLine("naval cislo ");
                a = Console.ReadLine();
                Console.WriteLine("nice, jeste jedno");
                b = Console.ReadLine();

                if (!float.TryParse(a, out numA) || !float.TryParse(b, out numB))
                { Console.WriteLine("Jsi nevalidni");

                } else
                {
                    
                    if (picovinka == "+")
                    {
                        result = numA + numB;
                        Console.WriteLine(a + " " + picovinka + " " + b + " " + "= " + result);
                    }
                    else if (picovinka == "-") 
                    {
                        result = numA - numB;
                        Console.WriteLine(a + " " + picovinka + " " + b + " " + "= " + result);
                    }
                    else if (picovinka == "*") 
                    {
                        result = numA * numB;
                        Console.WriteLine(a + " " + picovinka + " " + b + " " + "= " + result);
                    }
                    else if (picovinka == "/") 
                    {
                        result = numA / numB;
                        Console.WriteLine(a + " " + picovinka + " " + b + " " + "= " + result);
                    }
                    else
                    {
                        Console.WriteLine("jsi nevalidni");
                    };
                    
                    
                }
                    
          




                Console.WriteLine("Chces to zkusit znovu? (Ano/ne)");
                userInput = Console.ReadLine();

                Asking = true;
                while (Asking == true)
               
                {
                 
                    if (userInput.ToLower() == "ano")
                    {
                        Running = true;
                        Asking = false;
                        
                    }
                    else if (userInput.ToLower() == "ne")
                    {
                        Running = false;
                        Asking = false;
                        
                    }
                    else
                    {
                        Console.WriteLine("Co prosim?");
                        userInput = Console.ReadLine();

                    }
                }

             }
           
            
        }
    }
}
