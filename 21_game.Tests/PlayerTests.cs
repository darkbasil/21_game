using System.Collections.Generic;
using NUnit.Framework;
using Moq;

namespace _21_game.Tests
{
	[TestFixture]
    public class PlayerTests
	{
		[Test]
		public void AceIsElevenTest()
		{
			//arrange
			var hand = new List<Card>
			{
				new Card
				{
					Rank = Rank.Ace
				},
				new Card
				{
					Rank = Rank.King
				}
			};

			var player = Mock.Of<Player>(p => p.Hand == hand);

			//act
			var points = player.GetPoints(); 

			//assert
            Assert.AreEqual(points, 21);
		}

		[Test]
        public void AceIsOneTest()
		{
			//arrange
			var hand = new List<Card>
			{
				new Card
				{
					Rank = Rank.Ten
				},
				new Card
				{
					Rank = Rank.Five
				},
				new Card
				{
					Rank = Rank.Ace
				}
			};

			var player = Mock.Of<Player>(p => p.Hand == hand);			

			//act
			var points = player.GetPoints();

			//assert
            Assert.AreEqual(points, 16);
		}

		[Test]
		public void StartCashTest()
		{
			//act
			var player = new Player();

			//assert
			Assert.AreEqual(player.Cash, 500);
		}

		[Test]
		public void StartPointsTest()
		{
			//act
			var player = new Player();

			//assert
			Assert.AreEqual(player.GetPoints(), 0);
		}

		[Test]
		public void SayHitMeTest()
		{
			//arrange
			var hand = new List<Card>
			{
				new Card
				{
					Rank = Rank.Ten
				},
				new Card
				{
					Rank = Rank.Five
				},
				new Card
				{
					Rank = Rank.Ace
				}
			};

			var player = Mock.Of<Player>(p => p.Hand == hand);

			//act
			var say = player.Say();

			//assert
			Assert.AreEqual(say, "Hit me");			
		}

		[Test]
		public void SayStopTest()
		{
			//arrange
			var hand = new List<Card>
			{
				new Card
				{
					Rank = Rank.Ten
				},
				new Card
				{
					Rank = Rank.Five
				},
				new Card
				{
					Rank = Rank.Five
				}
			};

			var player = Mock.Of<Player>(p => p.Hand == hand);

			//act
			var say = player.Say();

			//assert
			Assert.AreEqual(say, "Stop");

		}

	}
}
