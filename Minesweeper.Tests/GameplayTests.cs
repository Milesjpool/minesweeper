using Minesweeper.Api;
using NUnit.Framework;

namespace Minesweeper.Tests
{
	[TestFixture]
	public class GameplayTests
	{
		[Test]
		public void Should_mark_cell_as_revealed_when_selected()
		{
			var game = new Game(new GameProperties(1,1));
			Assert.That(game.Minefield[0, 0].State, Is.Not.EqualTo(CellState.Revealed));
			game.SelectCell(0, 0);
			Assert.That(game.Minefield[0, 0].State, Is.EqualTo(CellState.Revealed));
		}

		[Test]
		public void Should_cycle_through_cell_states_when_alt_selected()
		{
			var game = new Game(new GameProperties(1,1,0));
			Assert.That(game.Minefield[0, 0].State, Is.EqualTo(CellState.Hidden));
			game.NextState(0, 0);
			Assert.That(game.Minefield[0, 0].State, Is.EqualTo(CellState.Flagged));
			game.NextState(0, 0);
			Assert.That(game.Minefield[0, 0].State, Is.EqualTo(CellState.QuestionMark));
			game.NextState(0, 0);
			Assert.That(game.Minefield[0, 0].State, Is.EqualTo(CellState.Hidden));
		}

		[Test]
		public void Should_lose_game_if_mine_is_selected()
		{
			var game = new Game(new GameProperties(1,1,1));
			Assert.IsTrue(game.Minefield[0, 0].IsMine);
			Assert.That(game.State, Is.EqualTo(GameState.InProgress));
			game.SelectCell(0, 0);
			Assert.That(game.State, Is.EqualTo(GameState.Lost));
		}

		[Test]
		public void Should_win_game_if_all_non_mines_are_selected()
		{
			var game = new Game(new GameProperties(1,1,0));
			Assert.IsFalse(game.Minefield[0, 0].IsMine);
			Assert.That(game.State, Is.EqualTo(GameState.InProgress));
			game.SelectCell(0, 0);
			Assert.That(game.State, Is.EqualTo(GameState.Won));
		}
	}
}