using System.Collections.Generic;
using NUnit.Framework;
using _21_game;
using Moq;

namespace PointsCalculateTest
{
	[TestFixture]
	public class CalculateTest
	{
		[Test]
		public void AceIsEleven()
		{
			//arrange
			List<Card> hand = new List<Card>
			{
				new Card()
				{
					Rank = 1,
					Color = "hearts"
				},
				new Card()
				{
					Rank = 13,
					Color = "spades"
				}
			};

			Player player = Mock.Of<Player>(p => p.Hand == hand);
			Points points = new Points();
			//act
			int sumPoints = points.Calculate(player);	  


			//assert
			Assert.AreEqual(sumPoints, 21);
		}

		[Test]
		public void AceIsOne()
		{
			//arrange
			List<Card> hand = new List<Card>
			{
				new Card()
				{
					Rank = 10,
					Color = "hearts"
				},
				new Card()
				{
					Rank = 5,
					Color = "spades"
				},
				new Card()
				{
					Rank = 1,
					Color = "diamonds"
				}
			};

			Player player = Mock.Of<Player>(p => p.Hand == hand);
			Points points = new Points();
			//act
			int sumPoints = points.Calculate(player);


			//assert
			Assert.AreEqual(sumPoints, 16);
		}	

	}
}
