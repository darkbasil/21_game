using System.Collections.Generic;

namespace _21_game
{
    public abstract class Member
    {
        protected Member()
        {
            Hand = new List<Card>();
        }

		public string Say()
		{
			switch (GetPoints())
			{
				case 12 :
					return "Hit me";
				case 13 :
					return "Hit me";
				case 14:
					return "Hit me";
				case 15:
					return "Hit me";
				case 16:
					return "Hit me";
				case 17:
					return "Hit me";
				default :
					return "Stop";
			}
		}

		public int GetPoints()
		{
			var points = 0;
			foreach (var card in Hand)
			{
				if ((int)card.Rank != 1)
				{
					if ((int)card.Rank < 10)
					{
						points += (int)card.Rank;
					}
					else
					{
						points += 10;
					}
				}
				else if (points + 11 <= 21)
				{
					points += 11;
				}
				else
				{
					points += 1;
				}
			}

			return points;

		}

        public IList<Card> Hand { get; set; }

        
    }
}
