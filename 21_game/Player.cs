using System;

namespace _21_game
{
	public class Player : Member
	{
		const double StartCash = 500;			

        public Player()
        {
            Cash = StartCash;
        }

		public Boolean MakeBet(double Value)
		{			
			if (Cash >= Value)
			{
				Bet = Value;
				Cash -= Bet;
				return true;
			}
			else
			{
				Bet = 0;
				return false;
			}
			
		}

	    public double Cash { get; set; }
		public double Bet { get; set; }
	}
}