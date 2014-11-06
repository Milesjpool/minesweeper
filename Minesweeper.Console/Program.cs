using System;
using Minesweeper.Api;

namespace Minesweeper.Console
{
	class Program
	{
		private static void Main(string[] args)
		{
			System.Console.WriteLine("|===============================================|");
			System.Console.WriteLine("||  ____    ____   ______   ___  ___   _____   ||");
			System.Console.WriteLine("|| |    \\  /    | |_    _| |   \\|   | |   __|  ||");
			System.Console.WriteLine("|| |     \\/     |   |  |   |        | |  |_    ||");
			System.Console.WriteLine("|| |            |   |  |   |        | |   _|   ||");
			System.Console.WriteLine("|| |    |\\/|    |  _|  |_  |        | |  |__   ||");
			System.Console.WriteLine("|| |____|  |____| |______| |___|\\___| |_____|  ||");
			System.Console.WriteLine("||                                             ||");
			System.Console.WriteLine("||          -- S  W  E  E  P  E  R --          ||");
			System.Console.WriteLine("|===============================================|");
			System.Console.WriteLine(Environment.NewLine);
			System.Console.WriteLine("             Press <Enter> to begin.");

			System.Console.ReadKey();

			var game = Engine.NewGame(new GameProperties(5, 5, 0.1m));

			while (game.State == GameState.InProgress)
			{
				System.Console.WriteLine("Please enter 'x y' coordinates");
				var input = System.Console.ReadLine();
				var xCoord = int.Parse(input.Split(' ')[0]);
				var yCoord = int.Parse(input.Split(' ')[1]);

				game.SelectCell(xCoord, yCoord);

				for (int y = -1; y < 5; y++)
				{
					for (int x = -1; x < 5; x++)
					{
						if (y == -1) System.Console.Write("_");
						else if (x == -1) System.Console.Write("|");
						else
						{
							Cell cell = game.Minefield[x, y];
							if ((cell.State == CellState.Revealed) && (cell.IsMine))
							{
								System.Console.Write("X");
							}
							else if ((cell.State == CellState.Revealed) && (!cell.IsMine))
							{
								System.Console.Write(game.Minefield[x, y].AdjacentMines);
							}
							else
							{
								System.Console.Write(" ");
							}
						}
					}
					System.Console.Write("\n");
				}
			}

			if (game.State == GameState.Won) System.Console.Write("You won");
			if (game.State == GameState.Lost) System.Console.Write("You lost");

			System.Console.ReadKey();

		}
	}
}
