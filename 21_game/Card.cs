namespace _21_game
{
    // Задавать масть строкой не слишком удобно, лучше сделать Enum
	public class Card
	{
        public CardColor Color { get; set; }

	    public int Rank { get; set; }
	}

    // Перечисление мастей
    public enum CardColor
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }
}
