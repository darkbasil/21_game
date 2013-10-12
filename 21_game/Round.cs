using System;
using System.Collections.Generic;

namespace _21_game
{
	public class Round
	{
		public readonly List<Card> CardsOnDesk = new List<Card>();			//выданные карты
		public double Bet { get; private set; }

		private static List<Card> GetDeck()
		{
			return new List<Card>
			{
				new Card							//Clubs
				{
					Rank = Rank.Ace,
					Color = CardColor.Clubs
				},
				new Card
				{
					Rank = Rank.Two,
					Color = CardColor.Clubs
				},
				new Card
				{
					Rank = Rank.Three,
					Color = CardColor.Clubs
				},
				new Card
				{
					Rank = Rank.Four,
					Color = CardColor.Clubs
				},
				new Card
				{
					Rank = Rank.Five,
					Color = CardColor.Clubs
				},
				new Card
				{
					Rank = Rank.Six,
					Color = CardColor.Clubs
				},
				new Card
				{
					Rank = Rank.Seven,
					Color = CardColor.Clubs
				},
				new Card
				{
					Rank = Rank.Eight,
					Color = CardColor.Clubs
				},
				new Card
				{
					Rank = Rank.Nine,
					Color = CardColor.Clubs
				},
				new Card
				{
					Rank = Rank.Ten,
					Color = CardColor.Clubs
				},
				new Card
				{
					Rank = Rank.Jack,
					Color = CardColor.Clubs
				},
				new Card
				{
					Rank = Rank.Queen,
					Color = CardColor.Clubs
				}
				,
				new Card
				{
					Rank = Rank.King,
					Color = CardColor.Clubs
				},

				new Card							   //Diamonds
				{
					Rank = Rank.Ace,
					Color = CardColor.Diamonds
				},
				new Card
				{
					Rank = Rank.Two,
					Color = CardColor.Diamonds
				},
				new Card
				{
					Rank = Rank.Three,
					Color = CardColor.Diamonds
				},
				new Card
				{
					Rank = Rank.Four,
					Color = CardColor.Diamonds
				},
				new Card
				{
					Rank = Rank.Five,
					Color = CardColor.Diamonds
				},
				new Card
				{
					Rank = Rank.Six,
					Color = CardColor.Diamonds
				},
				new Card
				{
					Rank = Rank.Seven,
					Color = CardColor.Diamonds
				},
				new Card
				{
					Rank = Rank.Eight,
					Color = CardColor.Diamonds
				},
				new Card
				{
					Rank = Rank.Nine,
					Color = CardColor.Diamonds
				},
				new Card
				{
					Rank = Rank.Ten,
					Color = CardColor.Diamonds
				},
				new Card
				{
					Rank = Rank.Jack,
					Color = CardColor.Diamonds
				},
				new Card
				{
					Rank = Rank.Queen,
					Color = CardColor.Diamonds
				}
				,
				new Card
				{
					Rank = Rank.King,
					Color = CardColor.Diamonds
				},

				new Card							   //Hearts
				{
					Rank = Rank.Ace,
					Color = CardColor.Hearts
				},
				new Card
				{
					Rank = Rank.Two,
					Color = CardColor.Hearts
				},
				new Card
				{
					Rank = Rank.Three,
					Color = CardColor.Hearts
				},
				new Card
				{
					Rank = Rank.Four,
					Color = CardColor.Hearts
				},
				new Card
				{
					Rank = Rank.Five,
					Color = CardColor.Hearts
				},
				new Card
				{
					Rank = Rank.Six,
					Color = CardColor.Hearts
				},
				new Card
				{
					Rank = Rank.Seven,
					Color = CardColor.Hearts
				},
				new Card
				{
					Rank = Rank.Eight,
					Color = CardColor.Hearts
				},
				new Card
				{
					Rank = Rank.Nine,
					Color = CardColor.Hearts
				},
				new Card
				{
					Rank = Rank.Ten,
					Color = CardColor.Hearts
				},
				new Card
				{
					Rank = Rank.Jack,
					Color = CardColor.Hearts
				},
				new Card
				{
					Rank = Rank.Queen,
					Color = CardColor.Hearts
				}
				,
				new Card
				{
					Rank = Rank.King,
					Color = CardColor.Hearts
				},	 

				new Card							   //Spades
				{
					Rank = Rank.Ace,
					Color = CardColor.Spades
				},
				new Card
				{
					Rank = Rank.Two,
					Color = CardColor.Spades
				},
				new Card
				{
					Rank = Rank.Three,
					Color = CardColor.Spades
				},
				new Card
				{
					Rank = Rank.Four,
					Color = CardColor.Spades
				},
				new Card
				{
					Rank = Rank.Five,
					Color = CardColor.Spades
				},
				new Card
				{
					Rank = Rank.Six,
					Color = CardColor.Spades
				},
				new Card
				{
					Rank = Rank.Seven,
					Color = CardColor.Spades
				},
				new Card
				{
					Rank = Rank.Eight,
					Color = CardColor.Spades
				},
				new Card
				{
					Rank = Rank.Nine,
					Color = CardColor.Spades
				},
				new Card
				{
					Rank = Rank.Ten,
					Color = CardColor.Spades
				},
				new Card
				{
					Rank = Rank.Jack,
					Color = CardColor.Spades
				},
				new Card
				{
					Rank = Rank.Queen,
					Color = CardColor.Spades
				}
				,
				new Card
				{
					Rank = Rank.King,
					Color = CardColor.Spades
				},
			};
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
						player.Cash += Bet*2;
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
					player.Cash += Bet*2;
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
