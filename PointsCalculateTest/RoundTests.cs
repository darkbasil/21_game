using System.Collections.Generic;
using NUnit.Framework;
using Moq;

namespace _21_game.Tests
{
	[TestFixture]
	public class RoundTests
	{
		[Test]
		public void PlayerLoseTest()
		{
			//arrange
			var playerHand = new List<Card>
			{
				new Card
				{
					Rank = 10
				},
				new Card
				{
					Rank = 13
				}
			};

			var dealerHand = new List<Card>
			{
				new Card
				{
					Rank = 1
				},
				new Card
				{
					Rank = 10
				}
			};

			var player = Mock.Of<Player>(p => p.Hand == playerHand);
			var dealer = Mock.Of<Dealer>(d => d.Hand == dealerHand);

			player.MakeBet(30.0);

			//act
			var round = new Round();
			round.CheckHands(player, dealer);

			//assert
			Assert.AreEqual(player.Cash, 470.0);
		}

		[Test]
		public void PlayerWinTest()
		{
			//arrange
			var playerHand = new List<Card>
			{
				new Card
				{
					Rank = 10
				},
				new Card
				{
					Rank = 5
				},
				new Card
				{
					Rank = 4
				}
			};

			var dealerHand = new List<Card>
			{
				new Card
				{
					Rank = 7
				},
				new Card
				{
					Rank = 10
				}
			};

			var player = Mock.Of<Player>(p => p.Hand == playerHand);
			var dealer = Mock.Of<Dealer>(d => d.Hand == dealerHand);

			player.MakeBet(30.0);

			//act
			var round = new Round();
			round.CheckHands(player, dealer);

			//assert
			Assert.AreEqual(player.Cash, 530.0);
		}

		[Test]
		public void PlayerGetNotEqualCardsTest()
		{
			//arrange
			var player = Mock.Of<Player>(p => p.Hand == new List<Card>());
			var dealer = Mock.Of<Dealer>(p => p.Hand == new List<Card>());

			var round = Mock.Of<Round>();

			//act
			round.GiveTwoCards(player, dealer);

			//assert
			Assert.AreNotEqual(player.Hand[0], player.Hand[1]);	   
		}

		[Test]
		public void CardsOnDeskCountTest()
		{
			//arrange
			var player = Mock.Of<Player>(p => p.Hand == new List<Card>());
			var dealer = Mock.Of<Dealer>(p => p.Hand == new List<Card>());

			var round = Mock.Of<Round>();

			//act
			round.GiveTwoCards(player, dealer);

			//assert
			Assert.AreEqual(round.CardsOnDesk.Count, 4);	   			
		}
	}
}
