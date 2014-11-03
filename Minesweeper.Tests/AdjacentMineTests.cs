using Minesweeper.Api;
using NUnit.Framework;

namespace Minesweeper.Tests
{
	[TestFixture]
	public class AdjacentMineTests
	{
		[Test]
		public void All_cells_should_start_with_adjacent_mine_value_0()
		{
			var minefield = new Minefield(50, 0);
			foreach (var cell in minefield.Cells)
			{
				Assert.That(cell.AdjacentMines, Is.EqualTo(0));
			}
		}

		[Test]
		public void All_empty_should_be_given_the_expected_adjacent_mine_value()
		{
			var minefield = new Minefield(3);
			var cells = minefield.Cells;
			cells[0, 0].IsMine = true;
			cells[0, 1].IsMine = false;
			cells[0, 2].IsMine = true;
			cells[1, 0].IsMine = false;
			cells[1, 1].IsMine = false;
			cells[1, 2].IsMine = false;
			cells[2, 0].IsMine = true;
			cells[2, 1].IsMine = false;
			cells[2, 2].IsMine = true;

			minefield.PopulateAdjacentMineValues();
			
			Assert.That(minefield.Cells[0,1].AdjacentMines, Is.EqualTo(2));
			Assert.That(minefield.Cells[1,0].AdjacentMines, Is.EqualTo(2));
			Assert.That(minefield.Cells[1,1].AdjacentMines, Is.EqualTo(4));
			Assert.That(minefield.Cells[1,2].AdjacentMines, Is.EqualTo(2));
			Assert.That(minefield.Cells[2,1].AdjacentMines, Is.EqualTo(2));
		}
	}
}