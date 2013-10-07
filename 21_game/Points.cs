namespace _21_game
{
	public class Points
	{
		public int Calculate(Member member)
		{
			int _sumPoints = 0;
			foreach (var card in member.Hand)
			{
				if (card.Rank != 1)
				{
					if (card.Rank < 10)
					{
						_sumPoints += card.Rank;
					}
					else
					{
						_sumPoints += 10;
					}
				}
				else if (_sumPoints + 11 <= 21)
				{
					_sumPoints += 11;
				}
				else
				{
					_sumPoints += 1;
				}
				
			}
			return _sumPoints;
		}
	}
}
