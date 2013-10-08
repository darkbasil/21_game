<<<<<<< HEAD
﻿
using System;

namespace _21_game
{
	public class Card
	{
        //private string _color { get; set; }
        //private int _rank { get; set; }

        //public string Color
        //{
        //    get
        //    {
        //        return _color;
        //    }
        //}

        //public int Rank
        //{
        //    get
        //    {
        //        return _rank;
        //    }
        //}

        // Более краткий эквивалент
	    public string Color { get; private set; }

	    public int Rank { get; private set; }
	}
}
=======
﻿
using System;

namespace _21_game
{
	public class Card
	{
		private string _color { get; set; }
		private int _rank { get; set; }

		public Card(string color, int rank)
		{
			_color = color;
			_rank = rank;
		}

		public int GetRank()
		{
			return _rank;
		}
	}
}
>>>>>>> add Moq framework
