namespace Minesweeper.Api
{
    public static class Engine
    {
        public static Game NewGame(int gridSize, decimal mineDensity)
        {
            return new Game(gridSize, mineDensity);
        }
    }
}