using System;

namespace Minesweeper.Api
{
	public class Game
	{
		public GameState State { get; private set; }
		public Cell[,] Minefield { get; private set; }
		private readonly GameProperties _properties;
		private int _safeCellsRemaining;

		public Game(GameProperties properties)
		{
			State = GameState.InProgress;
			_properties = properties;
			BuildCellGrid();
			BuryMines();
			PopulateAdjacentMineValues();
		}

		private void BuildCellGrid()
		{
			var width = _properties.Width;
			var height = _properties.Height;
			Minefield = new Cell[width, height];
			for (var x = 0; x < width; x++)
			{
				for (var y = 0; y < height; y++)
				{
					Minefield[x, y] = new Cell();
				}
			}
		}

		private void BuryMines()
		{
			_safeCellsRemaining = _properties.Spaces;
			var random = new Random();
			var minesPlaced = 0;
			while (minesPlaced < _properties.NumberOfMines)
			{
				var position = random.Next(_properties.Spaces);
				var x = position % _properties.Width;
				var y = position / _properties.Width;
				var cell = Minefield[x, y];
				if (!cell.IsMine)
				{
					cell.IsMine = true;
					minesPlaced++;
					_safeCellsRemaining--;
				}
			}
		}

		public void PopulateAdjacentMineValues()
		{
			for (int x = 0; x < _properties.Width; x++)
			{
				for (int y = 0; y < _properties.Height; y++)
				{
					var cell = Minefield[x, y];
					if (!cell.IsMine)
					{
						cell.AdjacentMines = MinesAdjacentTo(x, y);
					}
				}
			}
		}

		private int MinesAdjacentTo(int x, int y)
		{
			var adjacentMines = 0;
			var thisCell = Minefield[x, y];
			for (int dx = -1; dx <= 1; dx++)
			{
				for (int dy = -1; dy <= 1; dy++)
				{
					if (IsValidCell(x + dx, y + dy) && (Minefield[x + dx, y + dy] != thisCell))
					{
						var adjacentCell = Minefield[x + dx, y + dy];
						if (adjacentCell.IsMine) adjacentMines++;
					}
				}
			}
			return adjacentMines;
		}

		private bool IsValidCell(int x, int y)
		{
			if ((x < 0) || (y < 0)) return false;
			if (x >= _properties.Width) return false;
			if (y >= _properties.Height) return false;
			return true;
		}

		public void SelectCell(int x, int y)
		{
			Minefield[x, y].State = CellState.Revealed;
			if (Minefield[x, y].IsMine) State = GameState.Lost;
			else
			{
				_safeCellsRemaining--;
				if (_safeCellsRemaining == 0)
				{
					State = GameState.Won;
				}
			}
		}

		public void NextState(int x, int y)
		{
			var state = Minefield[x, y].State;
			var stateVal = (int) state;
			if (state != CellState.Revealed)
			{
				Minefield[x, y].State = (CellState)((stateVal + 1) % 3);
			}
		}
	}
}