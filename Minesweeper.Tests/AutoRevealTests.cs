using Minesweeper.Api;
using NUnit.Framework;

namespace Minesweeper.Tests
{
	[TestFixture]
	public class AutoRevealTests
	{
		[Test]
		public void Should_reveal_all_cells_around_cell_with_0_adjacent_mines()
		{
			int size = 5;
			var game = new Game(new GameProperties(size, size, 0));
			for (int i = 0; i < size*size; i++)
			{
				game.Minefield[i/size, i%size].AdjacentMines = 1;
			}
			game.Minefield[2, 2].AdjacentMines = 0;
			game.SelectCell(2, 2);
			Assert.That(game.Minefield[2, 2].State, Is.EqualTo(CellState.Revealed));

			Assert.That(game.Minefield[1, 1].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[1, 2].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[1, 3].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[2, 1].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[2, 3].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[3, 1].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[3, 2].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[3, 3].State, Is.EqualTo(CellState.Revealed));
		
			Assert.That(game.Minefield[0, 0].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[0, 1].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[0, 2].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[0, 3].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[0, 4].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[1, 0].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[1, 4].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[2, 0].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[2, 4].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[3, 0].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[3, 4].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[4, 0].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[4, 1].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[4, 2].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[4, 3].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[4, 4].State, Is.EqualTo(CellState.Hidden));
		}

		[Test]
		public void Should_reveal_all_cells_around_corner_cell_with_0_adjacent_mines()
		{
			int size = 3;
			var game = new Game(new GameProperties(size, size, 0));
			for (int i = 0; i < size * size; i++)
			{
				game.Minefield[i / size, i % size].AdjacentMines = 1;
			}
			game.Minefield[0, 0].AdjacentMines = 0;
			game.SelectCell(0, 0);
			Assert.That(game.Minefield[0, 0].State, Is.EqualTo(CellState.Revealed));

			Assert.That(game.Minefield[0, 1].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[1, 0].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[1, 1].State, Is.EqualTo(CellState.Revealed));

			Assert.That(game.Minefield[0, 2].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[1, 2].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[2, 0].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[2, 1].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[2, 2].State, Is.EqualTo(CellState.Hidden));
		}

		[Test]
		public void Should_reveal_all_cells_around_area_of_cells_with_0_adjacent_mines()
		{
			var game = new Game(new GameProperties(10, 3, 0));
			for (int x = 0; x < 10; x++)
			{
				for (int y = 0; y < 3; y++)
				{
					game.Minefield[x, y].AdjacentMines = 1-(y%2);
				}
			}
			game.Minefield[8, 1].AdjacentMines = 1;
			game.SelectCell(0, 1);
			Assert.That(game.Minefield[0, 0].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[1, 0].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[2, 0].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[3, 0].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[4, 0].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[5, 0].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[6, 0].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[7, 0].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[8, 0].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[0, 1].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[1, 1].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[2, 1].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[3, 1].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[4, 1].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[5, 1].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[6, 1].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[7, 1].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[8, 1].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[0, 2].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[1, 2].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[2, 2].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[3, 2].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[4, 2].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[5, 2].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[6, 2].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[7, 2].State, Is.EqualTo(CellState.Revealed));
			Assert.That(game.Minefield[8, 2].State, Is.EqualTo(CellState.Revealed));

			Assert.That(game.Minefield[9, 0].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[9, 1].State, Is.EqualTo(CellState.Hidden));
			Assert.That(game.Minefield[9, 2].State, Is.EqualTo(CellState.Hidden));
		}
	}
}