using System;
using System.Collections.Generic;

namespace _21_game
{
    public class Round
    {
        /// <summary>
        /// Карты на столе
        /// </summary>
        public readonly List<Card> CardsOnDesk = new List<Card>();

        /// <summary>
        /// Карты в колоде
        /// </summary>
        public readonly List<Card> Deck;     

        /// <summary>
        /// Ставка
        /// </summary>
        public double Bet { get; private set; }

        // TODO : Мы говорили, что Round должен владеть экземлярами dealer и player
        // Сейчас раунд обслуживает каких-то участников, вовсе необязательно, что одних и тех же
        public Round()
        {
            Deck = GetDeck();
        }


        // TODO : почему метод был статический? Он вызывается только в экземпляре
        private List<Card> GetDeck()
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

        /// <summary>
        /// Участник получает карту
        /// </summary>
        /// <param name="member">Участника игры</param>
        public void GetCardFromDeck(Member member)					
        {
            // Карта случайным образом берётся из колоды и ПЕРЕКЛАДЫВЕТСЯ на стол и руку игрока
            // Не надо каждый раз создавать колоду заново
            // Не надо бегать по ней бесконечным циклом
            var r = new Random();
            var card = Deck[r.Next(0, Deck.Count - 1)];
            Deck.Remove(card);
            CardsOnDesk.Add(card);
            member.Hand.Add(card);
        }

        /// <summary>
        /// Игрок и дилер получают по две карты
        /// </summary>
        /// <param name="player">Игрок</param>
        /// <param name="dealer">Дилер</param>
        public void GiveTwoCards(Player player, Dealer dealer)		
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
