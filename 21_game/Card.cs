namespace _21_game
{
    // �������� ����� ������� �� ������� ������, ����� ������� Enum
	public class Card
	{
        public CardColor Color { get; set; }

	    public int Rank { get; set; }
	}

    // ������������ ������
    public enum CardColor
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }
}
