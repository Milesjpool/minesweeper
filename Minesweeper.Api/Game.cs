using System;

namespace Minesweeper.Api
{
    public class Game
    {
        public Minefield Minefield { get; set; }

        public Game(int size, decimal mineDensity)
        {
            Minefield = new Minefield(size, mineDensity);
        }
    }
}