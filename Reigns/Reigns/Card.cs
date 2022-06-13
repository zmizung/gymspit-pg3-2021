namespace Reigns
{
    class Card
    {
        public Character Character;
        public string Text;
        public string Yes;
        public string No;
        public int YeE1;
        public int YeE2;
        public int YeE3;
        public int YeE4;
        public int NoE1;
        public int NoE2;
        public int NoE3;
        public int NoE4;

        public Card()
        {
            Character = new Character("default character");
            Text = "you have a decision to make!";
            Yes = "let's do it";
            No = "not this time";
            YeE1 = 100;
            YeE2 = 100;
            YeE3 = 100;
            YeE4 = 100;
            NoE1 = 100;
            NoE2 = 100;
            NoE3 = 100;
            NoE4 = 100;
        }

    }
}
