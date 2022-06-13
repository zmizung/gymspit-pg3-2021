using System;
using System.Collections.Generic;
using System.IO;

namespace Reigns
{
    class Save
    {
        public bool isEmpty;
        public string SaveName;
        public string SavePath;
        public string[] SaveLines;
        public int[] Scores = new int[0];

        public static string Path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"files\", "save1.txt");
        public static string Path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"files\", "save2.txt");
        public static string Path3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"files\", "save3.txt");

        public Save(string path, int[] scores)
        {
            isEmpty = true;
            SavePath = path;
            SaveName = "empty";
            SaveLines = File.ReadAllLines(path);

            Array.Resize(ref Scores, scores.Length);
            Scores = scores;

            if (SaveLines.Length == 0) return;
            if (SaveLines[0] == "") return;

            SaveName = SaveLines[0];
            isEmpty = false;
        }

        public static void WriteName(Save save, string name)
        {
            save.SaveName = name;
            File.AppendAllText(save.SavePath, name);
            save.isEmpty = false;
        }

        public static Save WriteScore(Save save, int score)
        {
            File.AppendAllText(save.SavePath, $"\n{score.ToString()}");

            Array.Resize(ref save.Scores, 0);

            save.SaveLines = File.ReadAllLines(save.SavePath);
            
            foreach (string s in save.SaveLines)
            {
                Array.Resize(ref save.Scores, save.Scores.Length + 1);

                if (!int.TryParse(s, out save.Scores[save.Scores.Length - 1]))
                {
                    Array.Resize(ref save.Scores, save.Scores.Length - 1);
                }
            }

            return save;
        }

        public static void Clear(Save save)
        {
            File.WriteAllText(save.SavePath, String.Empty);

            save.SaveName = "empty";
            save.SaveLines = new string[0];
            save.isEmpty = true;
        }

        public static Save ChooseSave(Save save1, Save save2, Save save3)

        {
            Console.WriteLine("Choose save by pressing 1, 2 or 3:");

            Console.WriteLine($"Save 1: {save1.SaveName}");
            Console.WriteLine($"Save 2: {save2.SaveName}");
            Console.WriteLine($"Save 3: {save3.SaveName}");

            while (true)
            {

                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                    case '+':
                        {
                            return save1;
                        }

                    case '2':
                    case 'ě':
                        {
                            return save2;
                        }

                    case '3':
                    case 'š':
                        {
                            return save3;
                        }

                    default:
                        {
                            Console.WriteLine("Please press 1, 2 or 3 to select save.");
                            continue;
                        }
                }
            }
        }

        public static Save ChosenEmpty(Save save)
        {
            Console.Clear();

            Console.WriteLine("Please enter your name:");

            string tempName;

            while (true)
            {
                tempName = Console.ReadLine();

                if (tempName == "")
                {
                    Console.WriteLine("Name cannot be empty!");
                    continue;
                }
                break;
            }

            Save.WriteName(save, tempName);

            return save;
        }

        public static Save ChosenFull(Save save)
        {
            Console.Clear();

            string[] lines = File.ReadAllLines(save.SavePath);

            save.SaveName = lines[0];

            if (lines.Length == 1)
            {
                return save;
            }

            foreach (string s in lines)
            {
                Array.Resize(ref save.Scores, save.Scores.Length + 1);

                if (!int.TryParse(s, out save.Scores[save.Scores.Length - 1]))
                {
                    Array.Resize(ref save.Scores, save.Scores.Length - 1);
                }
            }

            return save;
        }

        public static void ViewHighscores(Save save)
        {
            Console.Clear();

            Console.WriteLine($"Save: {save.SaveName}");
            Console.WriteLine("(press D to delete scores from save, press any key to leave)");
            Console.WriteLine("");

            List<int> ScoresSorted = new List<int>();
            ScoresSorted.AddRange(save.Scores);
            ScoresSorted.Sort();

            for (int i1 = ScoresSorted.Count - 1; i1 >= 0; i1--)
            {
                int i = ScoresSorted[i1];
                Console.WriteLine(i);
            }

            switch (Console.ReadKey(true).KeyChar)
            {
                case 'd':
                case 'D':
                    {
                        Console.WriteLine("Are you sure you want to clear scores? Type 'yes' to confirm.");

                        string input = Console.ReadLine();

                        if (input.ToLower() == "yes" || input.ToLower() == "zes")
                        {
                            Console.WriteLine("Save deleted");
                            Console.ReadLine();
                            Save.Clear(save);
                            break;
                        }

                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
