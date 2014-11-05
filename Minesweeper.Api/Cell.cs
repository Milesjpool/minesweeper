namespace Minesweeper.Api
{
	public class Cell
	{
		public bool IsMine { get; set; }
		public int AdjacentMines { get; set; }
		public CellState State { get; set; }


		public Cell()
		{
			IsMine = false;
			AdjacentMines = 0;
			State = CellState.Hidden;
		}
	}
}