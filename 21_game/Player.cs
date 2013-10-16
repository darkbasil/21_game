namespace _21_game
{
	public class Player : Member
	{
		const double StartCash = 500;			

        public Player()
        {
            Cash = StartCash;
        }

        // TODO : WTF?
		public string Say(string exit)
		{
			return exit;
		}

	    public double Cash { get; set; }

	}
}