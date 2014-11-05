using System;

namespace Minesweeper.Api
{
	public class Game
	{
		public bool IsActive { get; private set; }
		public bool IsVictory { get; private set; }
		public Cell[,] Minefield { get; private set; }
		private readonly int _width;
		private readonly int _height;
		private readonly int _numberOfMines;
		private int _safeCellsRemaining;

		public Game(int size, decimal mineDensity = 0.2m)
		{
			IsActive = true;
			IsVictory = false;
			_width = size;
			_height = size;
			_numberOfMines = (int)(_width * _height * mineDensity);
			Minefield = new Cell[_width, _height];
			BuildCellGrid();
			BuryMines();
			PopulateAdjacentMineValues();
		}

		private void BuildCellGrid()
		{
			for (var x = 0; x < _width; x++)
			{
				for (var y = 0; y < _height; y++)
				{
					Minefield[x, y] = new Cell();
				}
			}
		}

		private void BuryMines()
		{
			var spaces = _width * _height;
			_safeCellsRemaining = spaces;
			var random = new Random();
			var minesPlaced = 0;
			while (minesPlaced < _numberOfMines)
			{
				var position = random.Next(spaces);
				var x = position % _width;
				var y = position / _width;
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
			for (int x = 0; x < _width; x++)
			{
				for (int y = 0; y < _height; y++)
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
			if (x >= _width) return false;
			if (y >= _height) return false;
			return true;
		}

		public void SelectCell(int x, int y)
		{
			Minefield[x, y].IsRevealed = true;
			GetSelectionOutcome(x, y);
		}

		private void GetSelectionOutcome(int x, int y)
		{
			if (Minefield[x, y].IsMine) IsActive = false;
			else
			{
				_safeCellsRemaining--;
				if (_safeCellsRemaining == 0)
				{
					IsActive = false;
					IsVictory = true;
				}
			}
		}

		public void NextState(int x, int y)
		{
			Minefield[x, y].State++;
		}
	}
}