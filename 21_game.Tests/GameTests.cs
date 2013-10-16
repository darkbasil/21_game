using Moq;
using NUnit.Framework;

namespace _21_game.Tests
{
	[TestFixture]
    // TODO : в классе GameTests нет ни одного теста для класса Game
	public class GameTests
	{
		[Test]
        // TODO : 1. этот тест срабатывает через раз
        // TODO : 2. тест проверяет работу сразу трёх объектов во взаимодействии, это не модульный тест
        // TODO : 3. все объекты создаются как стабы, а используются для проверки реальной функциональности О_О
		public void PlayerSayStopTest()
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
