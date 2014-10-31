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
                Console.WriteLine("X:" + x + ", Y: " + y + ", IsMine: " + cell.IsMine);
                if (!cell.IsMine)
                {
                    cell.IsMine = true;
                    minesPlaced++;
                }
            }
        }
    }
}