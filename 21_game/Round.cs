using System;
using System.Collections.Generic;

namespace _21_game
{
	public class Round
	{
		public List<Card> CardsOnDesk = new List<Card>();			//выданные карты

		public void GetCardFromDeck(Member member)					//получение карты из колоды
		{
			var card = new Card();			

			card.Color = CardColor.Hearts;							//нужно сделать случайный выбор масти

			while (true)
			{
				var r = new Random();
				card.Rank = (Rank)r.Next(1,13);
				if (!CardsOnDesk.Contains(card))
				{
					CardsOnDesk.Add(card);
					member.Hand.Add(card);
					return;
				}
			}
		}

		public void GiveTwoCards(Player player, Dealer dealer)		//по две карты в начале раунда
		{
			GetCardFromDeck(player);
			GetCardFromDeck(player);

			GetCardFromDeck(dealer);
			GetCardFromDeck(dealer);
		}

		public void CheckHands(Player player, Member dealer)
		{
            if (dealer.GetPoints() <= 21)
			{
                if (player.GetPoints() <= 21)
				{
                    if (player.GetPoints() > dealer.GetPoints())			 //у игрока больше, чем у дилера, но нет перебора - игрок
					{											 //получает удвоенную ставку
						player.Cash += player.Bet*2;
					}
                    else if (player.GetPoints() == dealer.GetPoints())	 //одинаковое количество очков - игрок получает свою ставку 
					{
						player.Cash += player.Bet;
					}
				}
			}
            else if (dealer.GetPoints() > 21)						 //перебор у дилера
			{
                if (player.GetPoints() <= 21)						 
				{
					player.Cash += player.Bet*2;
				}
				else
				{
					player.Cash += player.Bet;
				}
			}
			player.Bet = 0;
		}
	}
}
