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
					Rank = Rank.Ten
				},
				new Card
				{
					Rank = Rank.King
				}
			};

			var dealerHand = new List<Card>
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

			var player = Mock.Of<Player>(p => p.Hand == playerHand);
			var dealer = Mock.Of<Dealer>(d => d.Hand == dealerHand);

			//act
			var round = new Round();
			round.MakeBet(player, 30.0);
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
					Rank = Rank.King
				},
				new Card
				{
					Rank = Rank.Five
				},
				new Card
				{
					Rank = Rank.Four
				}
			};

			var dealerHand = new List<Card>
			{
				new Card
				{
					Rank = Rank.Seven
				},
				new Card
				{
					Rank = Rank.Ten
				}
			};

			var player = Mock.Of<Player>(p => p.Hand == playerHand);
			var dealer = Mock.Of<Dealer>(d => d.Hand == dealerHand);

			//act
			var round = new Round();
			round.MakeBet(player, 30.0);
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

		[Test]
		public void MakeBetTest()
		{
			//arrange
			var player = Mock.Of<Player>(p => p.Hand == new List<Card>());
		
			var round = Mock.Of<Round>();			

			//act
			round.MakeBet(player, 30.0);

			//assert
			Assert.AreEqual(round.Bet, 30.0);
		}

		[Test]
		public void CashChangeAfterBetTest()
		{
			//arrange
			var player = Mock.Of<Player>(p => p.Hand == new List<Card>());
		
			var round = Mock.Of<Round>();			

			//act
			round.MakeBet(player, 30.0);

			//assert
			Assert.AreEqual(player.Cash, 470.0);
		}

		[Test]
		public void GetCardTest()
		{
			//arrange
			var player = Mock.Of<Player>(p => p.Hand == new List<Card>());			
			var round = Mock.Of<Round>();

			//act
			round.GetCardFromDeck(player);

			//assert
			Assert.Contains(player.Hand[0],round.CardsOnDesk);
		}
	}
}
