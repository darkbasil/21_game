<<<<<<< HEAD
﻿namespace _21_game
{
	public class Points
	{
		public int Calculate(Member member)
		{
            // имя переменной было форматировано неверно
			int sumPoints = 0;
			foreach (var card in member.Hand)
			{
				if (card.Rank != 1)
				{
					if (card.Rank < 10)
					{
						sumPoints += card.Rank;
					}
					else
					{
						sumPoints += 10;
					}
				}
				else if (sumPoints + 11 <= 21)
				{
					sumPoints += 11;
				}
				else
				{
					sumPoints += 1;
				}
				
			}
			return sumPoints;
		}
	}
}
=======
﻿namespace _21_game
{
	public class Points
	{
		public int Calculate(Member member)
		{
			int _sumPoints = 0;
			foreach (var card in member.Hand)
			{
				if (card.GetRank() != 1)
				{
					if (card.GetRank() < 10)
					{
						_sumPoints += card.GetRank();
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
>>>>>>> add Moq framework
