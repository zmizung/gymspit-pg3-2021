using System;
using System.IO;

namespace Reigns
{
    class Deck
    {
        public static Card[] LoadDeck()
        {
            string fileName = "deck.txt";
            string deckPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"files\", fileName);

            Card[] cardDeck = new Card[0];

            string tempstring;
            int varcount = 1;

            string[] deckLines = File.ReadAllLines(deckPath);

            foreach (string a in deckLines)
            {
                if (a == "")
                {
                    varcount = 1;
                }
                else
                {
                    if (varcount == 1)
                    {
                        Array.Resize(ref cardDeck, cardDeck.Length + 1);
                        cardDeck[cardDeck.Length - 1] = new Card();
                        cardDeck[cardDeck.Length - 1].Character = new Character(a);
                    }

                    if (varcount == 2)
                    {
                        cardDeck[(cardDeck.Length - 1)].Text = a;
                    }

                    if (varcount == 3)
                    {
                        cardDeck[(cardDeck.Length - 1)].Yes = a;
                    }

                    if (varcount == 4)
                    {
                        cardDeck[(cardDeck.Length - 1)].No = a;
                    }

                    if (varcount == 5)
                    {
                        tempstring = a;
                        string[] split = tempstring.Split(" ");
                        int[] splitint = new int[0];
                        for (int i = 0; i < 8; i++)
                        {
                            Array.Resize(ref splitint, i + 1);
                            splitint[i] = new int();
                            int.TryParse(split[i], out splitint[i]);
                        }
                        cardDeck[(cardDeck.Length - 1)].YeE1 = splitint[0];
                        cardDeck[(cardDeck.Length - 1)].YeE2 = splitint[1];
                        cardDeck[(cardDeck.Length - 1)].YeE3 = splitint[2];
                        cardDeck[(cardDeck.Length - 1)].YeE4 = splitint[3];
                        cardDeck[(cardDeck.Length - 1)].NoE1 = splitint[4];
                        cardDeck[(cardDeck.Length - 1)].NoE2 = splitint[5];
                        cardDeck[(cardDeck.Length - 1)].NoE3 = splitint[6];
                        cardDeck[(cardDeck.Length - 1)].NoE4 = splitint[7];
                    }
                    varcount++;
                }
            }

            return cardDeck;

        }

        public static void PrintDeck(Card[] cardDeck)
        {
            foreach (Card c in cardDeck)
            {
                Console.WriteLine(c.Character.Name);
                Console.WriteLine(c.Text);
                Console.WriteLine(c.Yes);
                Console.WriteLine(c.No);
                Console.Write($"{c.YeE1} {c.YeE2} {c.YeE3} {c.YeE4} {c.NoE1} {c.NoE2} {c.NoE3} {c.NoE4}");
                Console.WriteLine("");
            }
        }
    }
}
