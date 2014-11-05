using System.Collections.Generic;

namespace Minesweeper.Api
{
    public static class Engine
    {

	    public static Game NewGame(GameProperties properties)
	    {
			return new Game(properties);
	    }
    }
}