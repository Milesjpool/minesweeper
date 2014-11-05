using System.Diagnostics;
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
			var game = new Game(1);
			Assert.IsFalse(game.Minefield[0, 0].IsRevealed);
			game.SelectCell(0, 0);
			Assert.IsTrue(game.Minefield[0, 0].IsRevealed);
		}

		[Test]
		public void Should_cycle_through_cell_states_when_alt_selected()
		{
			var game = new Game(1, 0);
			Assert.That(game.Minefield[0, 0].State, Is.EqualTo(0));
			game.NextState(0, 0);
			Assert.That(game.Minefield[0, 0].State, Is.EqualTo(1));
			game.NextState(0, 0);
			Assert.That(game.Minefield[0, 0].State, Is.EqualTo(2));
			game.NextState(0, 0);
			Assert.That(game.Minefield[0, 0].State, Is.EqualTo(0));
		}

		[Test]
		public void Should_lose_game_if_mine_is_selected()
		{
			var game = new Game(1, 1);
			Assert.IsTrue(game.Minefield[0, 0].IsMine);
			Assert.IsTrue(game.IsActive);
			game.SelectCell(0, 0);
			Assert.IsFalse(game.IsActive);
			Assert.IsFalse(game.IsVictory);
		}

		[Test]
		public void Should_win_game_if_all_non_mines_are_selected()
		{
			var game = new Game(1, 0);
			Assert.IsFalse(game.Minefield[0, 0].IsMine);
			Assert.IsTrue(game.IsActive);
			game.SelectCell(0, 0);
			Assert.IsFalse(game.IsActive);
			Assert.IsTrue(game.IsVictory);
		}
	}
}