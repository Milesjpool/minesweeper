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
			var game = new Game(new GameProperties(50, 50, 0));
			foreach (var cell in game.Minefield)
			{
				Assert.That(cell.AdjacentMines, Is.EqualTo(0));
			}
		}

		[Test]
		public void All_empty_should_be_given_the_expected_adjacent_mine_value()
		{
			var gameProperties = new GameProperties(3, 3, 0);
			var game = new Game(gameProperties);
			var minefield = game.Minefield;
			minefield[0, 0].IsMine = true;
			minefield[0, 1].IsMine = false;
			minefield[0, 2].IsMine = true;
			minefield[1, 0].IsMine = false;
			minefield[1, 1].IsMine = false;
			minefield[1, 2].IsMine = false;
			minefield[2, 0].IsMine = true;
			minefield[2, 1].IsMine = false;
			minefield[2, 2].IsMine = true;

			game.PopulateAdjacentMineValues();
			
			Assert.That(game.Minefield[0,1].AdjacentMines, Is.EqualTo(2));
			Assert.That(game.Minefield[1,0].AdjacentMines, Is.EqualTo(2));
			Assert.That(game.Minefield[1,1].AdjacentMines, Is.EqualTo(4));
			Assert.That(game.Minefield[1,2].AdjacentMines, Is.EqualTo(2));
			Assert.That(game.Minefield[2,1].AdjacentMines, Is.EqualTo(2));
		}
	}
}