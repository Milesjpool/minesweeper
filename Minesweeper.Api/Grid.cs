namespace Minesweeper.Api
{
    public class Grid
    {
        public Grid()
        {
        }

        private void PopulateMines(int numberOfMines)
        {
        }

        private Cell[,] NewGrid(int gridSize)
        {
            var grid = new Cell[gridSize, gridSize];
            for (var x = 0; x < gridSize; x++)
            {
                for (var y = 0; y < gridSize; y++)
                {
                    grid[x, y] = new Cell();
                }
            }
            return grid;
        }
    }
}