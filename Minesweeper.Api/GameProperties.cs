namespace Minesweeper.Api
{
	public class GameProperties
	{
		public int Width { get; private set; }
		public int Height { get; private set; }
		public int Spaces { get; private set; }
		public int NumberOfMines { get; private set; }

		public GameProperties(int width, int height, decimal mineDensity = 0.2m)
		{
			Width = width;
			Height = height;
			Spaces = width*height;
			NumberOfMines = (int) (Spaces*mineDensity);
		}
	}
}