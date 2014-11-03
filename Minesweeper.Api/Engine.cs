namespace Minesweeper.Api
{
    public static class Engine
    {
	    public static Game NewGame(int gridSize, decimal mineDensity = 0.2m)
	    {
			return new Game(gridSize, mineDensity);
	    }
    }
}