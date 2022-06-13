using System;

namespace Reigns
{
    class Program
    {
        static Save Load()
        {
            Console.Clear();
            
            int[] scoresEmpty = new int[0];

            Save Save1 = new Save(Save.Path1, scoresEmpty);
            Save Save2 = new Save(Save.Path2, scoresEmpty);
            Save Save3 = new Save(Save.Path3, scoresEmpty);

            Save ActiveSave = Save.ChooseSave(Save1, Save2, Save3);
            if (ActiveSave.isEmpty)
            {
                ActiveSave = Save.ChosenEmpty(ActiveSave);
            }
            else
            {
                ActiveSave = Save.ChosenFull(ActiveSave);
            }

            if (ActiveSave == null)
            {
                ActiveSave = Save.ChosenEmpty(Save1);
            }

            Console.Clear();
            Console.WriteLine("Name successfully saved.");

            return ActiveSave;
        }

        static void Main(string[] args)
        {

            Save ActiveSave = Load();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Press key to select:");
                Console.WriteLine("N: New game");
                Console.WriteLine("T: Tutorial");
                Console.WriteLine("H: View highscores");
                Console.WriteLine("E: Exit");

                switch (Console.ReadKey(true).KeyChar)
                {
                    case 'n':
                    case 'N':
                        {
                            ActiveSave = Games.Game(ActiveSave);
                            continue;
                        }
                    case 't':
                    case 'T':
                        {
                            Tutorial.ShowTutorial();
                            continue;
                        }
                    case 'h':
                    case 'H':
                        {
                            Save.ViewHighscores(ActiveSave);
                            if (ActiveSave.isEmpty)
                            {
                                ActiveSave = Load();
                            }
                            continue;
                        }
                    case 'e':
                    case 'E':
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Vyberte platnou možnost.");
                            continue;
                        }
                }
                break;
            }
        }
    }
}
