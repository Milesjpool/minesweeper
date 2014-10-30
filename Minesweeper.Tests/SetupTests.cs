using Minesweeper.Api;
using NUnit.Framework;

namespace Minesweeper.Tests
{
    [TestFixture]
    public class SetupTests
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
            Assert.IsNotNull(_game.Grid);
        }

        [Test]
        public void New_game_should_contain_grid_of_cells()
        {
            Assert.IsInstanceOf(typeof(Cell), _game.Grid[0, 0]);
        }

        [TestCase(10)]
        [TestCase(30)]
        [TestCase(50)]
        public void Number_of_cells_should_equal_grid_size_squared(int gridSize)
        {
            var game = Engine.NewGame(gridSize);

            Assert.That(game.Grid.Length, Is.EqualTo(gridSize*gridSize));
        }
    }
}
