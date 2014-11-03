namespace Minesweeper.Api
{
	public class Cell
	{
		public bool IsMine { get; set; }

		public int AdjacentMines { get; set; }
	}
}