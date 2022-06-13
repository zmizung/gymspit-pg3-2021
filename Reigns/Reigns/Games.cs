using System;

namespace Reigns
{
    class Games
    {
        static string Turn(Card[] cardDeck, int money, int army, int people, int church, int score, string prevChar)
        {
            Random rnd = new Random();
            int index = rnd.Next(cardDeck.Length);

            while (cardDeck[index].Character.Name == prevChar)
            {
                index = rnd.Next(cardDeck.Length);
            }

            prevChar = cardDeck[index].Character.Name;

            Console.Clear();

            Print.StatPrint(score, money, army, people, church);

            Console.WriteLine($"{cardDeck[index].Character.Name}: {cardDeck[index].Text}");

            Console.WriteLine("");

            Console.WriteLine($"Y: {cardDeck[index].Yes}");
            Console.WriteLine($"N: {cardDeck[index].No}");

            while (true)
            {
                switch (Console.ReadKey(true).KeyChar)
                {
                    case 'y':
                    case 'Y':
                    case 'z':
                    case 'Z':
                        {
                            Console.Clear();

                            Print.StatPrint(score, money, army, people, church, cardDeck[index].YeE1, cardDeck[index].YeE2, cardDeck[index].YeE3, cardDeck[index].YeE4);

                            money = money + cardDeck[index].YeE1;
                            army = army + cardDeck[index].YeE2;
                            people = people + cardDeck[index].YeE3;
                            church = church + cardDeck[index].YeE4;

                            Console.ReadLine();

                            break;
                        }
                    case 'n':
                    case 'N':
                        {
                            Console.Clear();

                            Print.StatPrint(score, money, army, people, church, cardDeck[index].NoE1, cardDeck[index].NoE2, cardDeck[index].NoE3, cardDeck[index].NoE4);

                            money = money + cardDeck[index].NoE1;
                            army = army + cardDeck[index].NoE2;
                            people = people + cardDeck[index].NoE3;
                            church = church + cardDeck[index].NoE4;

                            Console.ReadLine();

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

            string output = $"{money}, {army}, {people}, {church}, {prevChar}";

            return output;

        }

        static bool DeathCheck(int money, int army, int people, int church)
        {
            bool dead = false;

            if (money <= 0 || army <= 0 || people <= 0 || church <= 0)
            {
                dead = true;
            }

            if (money >= 100 || army >= 100 || people >= 100 || church >= 100)
            {
                dead = true;
            }

            return dead;
        }

        static void Death(int money, int army, int people, int church, int score)
        {
            Console.Clear();

            Console.WriteLine($"Peníze = {money}");
            Console.WriteLine($"Army = {army}");
            Console.WriteLine($"People = {people}");
            Console.WriteLine($"Church = {church}");

            Console.WriteLine("");

            if (money <= 0)
            {
                Console.WriteLine("Stát je finančně na dně.");
                Console.WriteLine("Panovník bez peněz nemá žádnou moc. Nemůžete platit své osobní stráži, ta vás jednu noc zabíje ve spánku.");
            }

            if (money >= 100)
            {
                Console.WriteLine("Máte nespočitatelné bohatství. Každý den pořádáte plesy a hostiny.");
                Console.WriteLine("Osudnou nocí je ta, kdy se opijete medovinou a překročíte hranici čtyř promile alkoholu v krvi.");
            }

            if (army <= 0)
            {
                Console.WriteLine("Armáda je žalostně slabá.");
                Console.WriteLine("Okolní země si všímají slabiny a vaše říše zaniká ve velkém nájezdu.");
            }

            if (army >= 100)
            {
                Console.WriteLine("Armáda je velmi silná a mocná.");
                Console.WriteLine("Generál armády přichází s elitním oddílem a zatýkají vás ve vojenském převratu.");
            }

            if (people <= 0)
            {
                Console.WriteLine("Lidem zcela došla trpělivost. Nejsou spokojeni se svou životní úrovní.");
                Console.WriteLine("V ulicích probíhají nepokoje, obyvatelé volají po revoluci. Utíkáte do exilu.");
            }

            if (people >= 100)
            {
                Console.WriteLine("Lidé se mají skvěle. Až moc.");
                Console.WriteLine("Když vám v ulicích provolávají čest, nadšený dav vás zvedne nad své hlavy.");
                Console.WriteLine("Bohužel vás nešikovně pustí na zem, čímž vám zlomí vaz.");
            }

            if (church <= 0)
            {
                Console.WriteLine("Církev ztratila veškerou moc.");
                Console.WriteLine("Lidé nemají víru a prudce roste kriminalita. Vytvářejí se improvizované skupiny domobrany.");
                Console.WriteLine("Jedna taková pochoduje směrem ke královskému paláci. Musíte utéct do exilu.");
            }

            if (church >= 100)
            {
                Console.WriteLine("Veškerá moc státu se shromáždila v rukou církve.");
                Console.WriteLine("Arcibiskup spolu s ");
            }

            Console.WriteLine("");
            Console.WriteLine("__________________________________________________");
            Console.WriteLine("");

            Console.WriteLine("Game over");
            Console.WriteLine($"Score: {score}");
            Console.ReadLine();
        }

        public static Save Game(Save save)
        {
            Console.Clear();

            int money = 50;
            int army = 50;
            int people = 50;
            int church = 50;

            string prevChar = "empty";

            Card[] cardDeck = Deck.LoadDeck();

            int score = 0;

            while (true)
            {
                score++;

                string output = Turn(cardDeck, money, army, people, church, score, prevChar);
                string[] values = output.Split(", ");

                int.TryParse(values[0], out money);
                int.TryParse(values[1], out army);
                int.TryParse(values[2], out people);
                int.TryParse(values[3], out church);
                prevChar = values[4];

                if (!DeathCheck(money, army, people, church))
                {
                    continue;
                }

                break;
            }

            Death(money, army, people, church, score);

            save = Save.WriteScore(save, score);

            return save;
        }
    }
}
