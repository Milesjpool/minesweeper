namespace Minesweeper.Api
{
	public class Cell
	{
		private int _state;

		public bool IsMine { get; set; }
		public bool IsRevealed { get; set; }
		public int AdjacentMines { get; set; }
		public int State { get { return _state; } set { _state = value%3; } }


		public Cell()
		{
			IsMine = false;
			IsRevealed = false;
			AdjacentMines = 0;
		}
	}
}