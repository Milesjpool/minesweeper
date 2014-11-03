using System;

namespace Minesweeper.Api
{
    public class Minefield
    {
        public Cell[,] Cells { get; private set; }
        private readonly int _width;
        private readonly int _height;
        private readonly int _numberOfMines;

        public Minefield(int size, decimal mineDensity = 0.2m)
        {
            _width = size;
            _height = size;
            _numberOfMines = (int) (_width*_height*mineDensity);
            BuildCellGrid();
            BuryMines();
			PopulateAdjacentMineValues();
        }

        private void BuildCellGrid()
        {
            Cells = new Cell[_width, _height];
            for (var x = 0; x < _width; x++)
            {
                for (var y = 0; y < _height; y++)
                {
                    Cells[x, y] = new Cell();
                }
            }
        }

        private void BuryMines()
        {
            var spaces = _width*_height;
            var random = new Random();
            var minesPlaced = 0;
            while (minesPlaced < _numberOfMines)
            {
                var position = random.Next(spaces);
                var x = position%_width;
                var y = position/_width;
                var cell = Cells[x, y];
                if (!cell.IsMine)
                {
                    cell.IsMine = true;
                    minesPlaced++;
                }
            }
        }

	    public void PopulateAdjacentMineValues()
	    {
		    for (int x = 0; x < _width; x++)
		    {
			    for (int y = 0; y < _height; y++)
			    {
				    if (!Cells[x, y].IsMine)
					{
						Cells[x, y].AdjacentMines = MinesAdjacentTo(x, y);
					}
			    }
		    }
	    }

	    private int MinesAdjacentTo(int x, int y)
	    {
		    var adjacentMines = 0;
		    var thisCell = Cells[x, y];
		    for (int dx = -1; dx <= 1; dx++)
		    {
				for (int dy = -1; dy <= 1; dy++)
				{
					if (IsValidCell(x + dx, y + dy) && (Cells[x + dx, y + dy] != thisCell))
					{
						var adjacentCell = Cells[x + dx, y + dy];
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
    }
}