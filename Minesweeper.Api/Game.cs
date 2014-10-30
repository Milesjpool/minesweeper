namespace Minesweeper.Api
{
    public class Game
    {
        public Cell[,] Grid { get; private set; }

        public Game(int gridSize)
        {
            Grid = new Cell[gridSize, gridSize];
            PopulateGrid(gridSize);
        }

        private void PopulateGrid(int gridSize)
        {
            for (var x = 0; x < gridSize; x++)
            {
                for (var y = 0; y < gridSize; y++)
                {
                    Grid[x, y] = new Cell();
                }
            }
        }
    }
}