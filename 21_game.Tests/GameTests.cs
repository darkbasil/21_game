using Moq;
using NUnit.Framework;

namespace _21_game.Tests
{
	[TestFixture]
	public class GameTests
	{
		[Test]
<<<<<<< HEAD
		public void PlayerSayStopTest()
=======
		public void StartGameTest()
>>>>>>> 60c0355f2305ff33747f98ef7e3e9de938c04525
		{
			//arrange
			var player = Mock.Of<Player>(); 
			var dealer = Mock.Of<Dealer>();

			var round = Mock.Of<Round>();

			//act
			round.MakeBet(player, 50);
			round.GiveTwoCards(player, dealer);
			while (player.Say() != "Stop")
			{
				round.GetCardFromDeck(player);
			}

			//assert
			Assert.GreaterOrEqual(player.GetPoints(),17);

		}
	}
}
