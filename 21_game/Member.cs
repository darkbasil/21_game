using System.Collections.Generic;

namespace _21_game
{
    public abstract class Member
    {
        public IList<Card> Hand { get; set; }
		public int Points { get; set; }

		public void Calculate()
		{			
			foreach (var card in Hand)
			{
				if (card.Rank != 1)
				{
					if (card.Rank < 10)
					{
						Points += card.Rank;
					}
					else
					{
						Points += 10;
					}
				}
				else if (Points + 11 <= 21)
				{
					Points += 11;
				}
				else
				{
					Points += 1;
				}

			}
			
		}
    }
}
