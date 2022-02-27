using System;


namespace Lecture19Composition
{
	class Program
	{
		static void Main(string[] args)
		{
			Random random = new Random();

			Character goblin = new Character(new AI(random), 15, 6, 4, "random");
			Character hero = new Character();
			hero.CreateCharacter();

			Game game = new Game(goblin, hero, new Die(random, 6));
			game.Run(Console.Out);
			Console.WriteLine();

			Console.WriteLine("Press any key to quit...");
			Console.ReadKey();
		}
	}
}
