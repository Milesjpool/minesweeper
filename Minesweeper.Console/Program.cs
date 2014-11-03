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
			System.Console.WriteLine("           This is a work-in-progress");
			System.Console.WriteLine("             Press <Enter> to leave.");

			System.Console.ReadKey();
		}
	}
}
