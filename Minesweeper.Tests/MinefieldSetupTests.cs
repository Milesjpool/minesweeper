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
			var minefield = new Minefield(size);

			Assert.That(minefield.Cells.Length, Is.EqualTo(size * size));
		}

		[TestCase(10, 0)]
		[TestCase(30, 0.1)]
		[TestCase(1, 0.3)]
		[TestCase(50, 0.3)]
		[TestCase(50, 1)]
		public void Minefield_should_contain_expected_number_of_mines(int size, decimal mineDensity)
		{
			var minefield = new Minefield(size, mineDensity);

			var numberOfMines = 0;
			var expectedNumber = (int)(size * size * mineDensity);

			foreach (var cell in minefield.Cells)
			{
				if (cell.IsMine) numberOfMines++;
			}
			Assert.That(numberOfMines, Is.EqualTo(expectedNumber));
		}
	}
}