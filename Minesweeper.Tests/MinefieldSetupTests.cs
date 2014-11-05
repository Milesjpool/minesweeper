using Minesweeper.Api;
using NUnit.Framework;

namespace Minesweeper.Tests
{
	[TestFixture]
	public class DifferentGameLevels
	{
		[TestCase(10)]
		[TestCase(30)]
		[TestCase(50)]
		public void Number_of_cells_should_equal_size_squared(int size)
		{
			var gameProperties = new GameProperties(size, size);
			var game = new Game(gameProperties);

			Assert.That(game.Minefield.Length, Is.EqualTo(size * size));
		}

		[TestCase(10, 0)]
		[TestCase(30, 0.1)]
		[TestCase(1, 0.3)]
		[TestCase(50, 0.3)]
		[TestCase(50, 1)]
		public void Minefield_should_contain_expected_number_of_mines(int size, decimal mineDensity)
		{
			var gameProperties = new GameProperties(size, size, mineDensity);
			var game = new Game(gameProperties);

			var numberOfMines = 0;
			var expectedNumber = (int)(size * size * mineDensity);

			foreach (var cell in game.Minefield)
			{
				if (cell.IsMine) numberOfMines++;
			}
			Assert.That(numberOfMines, Is.EqualTo(expectedNumber));
		}
	}
}