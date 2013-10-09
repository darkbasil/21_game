namespace _21_game
{
	public class Player : Member
	{
		const double StartCash = 500;

        public Player()
        {
            Cash = StartCash;
        }

	    public double Cash { get; private set; }
	}
}