namespace Minesweeper.Api
{
    public static class Engine
    {
        public static Game NewGame(int gridSize)
        {
            return new Game(gridSize);
        }
    }
}