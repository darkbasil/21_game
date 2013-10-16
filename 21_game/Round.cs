using System;
using System.Collections.Generic;

namespace _21_game
{
    public class Round
    {
        public readonly List<Card> CardsOnDesk = new List<Card>();			//выданные карты
        public double Bet { get; private set; }


        // Почему метод статический?
        private static List<Card> GetDeck()
        {
            var deck = new List<Card>();

            // Ээ.. кагбе, вот так вот
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    deck.Add(new Card {Color = (CardColor)i, Rank = (Rank)j});
                }
            }

            return deck;
        }

        public void MakeBet(Player player, double value)
        {
            if (player.Cash < value) return;
            Bet = value;
            player.Cash -= Bet;
        }

        public void GetCardFromDeck(Member member)					//получение карты из колоды
        {
            var r = new Random();
            var card = GetDeck()[r.Next(1, 52)];
            while (!CardsOnDesk.Contains(card))
            {
                card = GetDeck()[r.Next(1, 52)];
                if (CardsOnDesk.Contains(card)) continue;
                CardsOnDesk.Add(card);
                member.Hand.Add(card);
                return;
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
                        player.Cash += Bet * 2;
                    }
                    else if (player.GetPoints() == dealer.GetPoints())	 //одинаковое количество очков - игрок получает свою ставку 
                    {
                        player.Cash += Bet;
                    }
                }
            }
            else if (dealer.GetPoints() > 21)						 //перебор у дилера
            {
                if (player.GetPoints() <= 21)
                {
                    player.Cash += Bet * 2;
                }
                else
                {
                    player.Cash += Bet;
                }
            }
            Bet = 0;
        }

    }
}
