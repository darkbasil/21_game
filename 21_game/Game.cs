namespace _21_game
{
	public class Game
	{
		const double MinCash = 0.0;
		private const double ValueBet = 50.0;

		public Game()
		{
			var player = new Player();
			var dealer = new Dealer();			

			while (player.Cash >= MinCash)
			{
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
