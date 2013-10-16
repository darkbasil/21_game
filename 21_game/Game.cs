namespace _21_game
{
	public class Game
	{
		const double MinCash = 0.0;
		private const double ValueBet = 50.0;

        // TODO : библиотека логики игры не должна самостоятельно играть
        // Мы только пытаемся разработать логику для повторного использования
        // Идея была в том, что эта библиотека может быть использована каким-то decktob, web или mobile приложением
        // С этих позиций класс Game должен предоставлять API для ведения игры, а не вести её сам
		public Game()
		{
            // TODO : прямое владение экземплярами, протестировать Game будет невозможно
			var player = new Player();
			var dealer = new Dealer();			

			while ((player.Cash >= MinCash) || (player.Say() == "Exit"))
			{
                // TODO : ещё прямое владение 
				var round = new Round();
				round.MakeBet(player, ValueBet);

				round.GiveTwoCards(player, dealer);

				if ((player.GetPoints() == 21) || (dealer.GetPoints() == 21))
					round.CheckHands(player, dealer);
				while (player.Say() != "Stop")
				{
					round.GetCardFromDeck(player);
				}

				while (dealer.Say() != "Stop")
				{
					round.GetCardFromDeck(dealer);
				}
				round.CheckHands(player, dealer);

			}
		}
	}
}
