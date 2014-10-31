using System.Linq;
using Minesweeper.Api;
using NUnit.Framework;

namespace Minesweeper.Tests
{
    [TestFixture]
    public class SetupTests
    {
        private Game _game;
        private Minefield _minefield;

        [SetUp]
        public void SetUp()
        {
            _game = Engine.NewGame(30, (decimal) 0.2);
            _minefield = _game.Minefield;
        }

        [Test]
        public void New_game_should_return_instance_of_game()
        {
            Assert.IsInstanceOf(typeof (Game), _game);
        }

        [Test]
        public void New_game_should_contain_grid()
        {
            Assert.IsNotNull(_minefield);
        }

        [Test]
        public void New_game_should_contain_grid_of_cells()
        {
            Assert.IsInstanceOf(typeof (Cell), _minefield.Cells[0, 0]);
        }
    }

    [TestFixture]
    public class DifferentGameLevels
    {
        [TestCase(10)]
        [TestCase(30)]
        [TestCase(50)]
        public void Number_of_cells_should_equal_size_squared(int size)
        {
            var minefield = new Minefield(size);

            Assert.That(minefield.Cells.Length, Is.EqualTo(size*size));
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
            var expectedNumber = (int) (size*size*mineDensity);

            foreach (var cell in minefield.Cells)
            {
                if (cell.IsMine) numberOfMines++;
            }
            Assert.That(numberOfMines, Is.EqualTo(expectedNumber));
        }
    }
}
