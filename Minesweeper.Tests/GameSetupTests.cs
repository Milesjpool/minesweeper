using Minesweeper.Api;
using NUnit.Framework;

namespace Minesweeper.Tests
{
	[TestFixture]
	public class GameSetupTests
	{
		private Game _game;

		[SetUp]
		public void SetUp()
		{
			_game = Engine.NewGame(30);
		}

		[Test]
		public void New_game_should_return_instance_of_game()
		{
			Assert.IsInstanceOf(typeof(Game), _game);
		}

		[Test]
		public void New_game_should_contain_grid()
		{
			Assert.IsNotNull(_game.Minefield);
		}

		[Test]
		public void New_game_should_contain_grid_of_cells()
		{
			Assert.IsInstanceOf(typeof(Cell), _game.Minefield[0, 0]);
		}
	}
}
