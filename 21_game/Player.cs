﻿using System;
using System.Collections.Generic;

namespace _21_game
{
	public class Player : Member
	{
		const double StartCash = 500;
        
        //private List<Card>  _playersHand = new List<Card>();
        //private Double _cash = StartCash;
		
        //public List<Card> Hand
        //{
        //    get
        //    {
        //        return _playersHand;
        //    }
        //}

        //public Double Cash
        //{
        //    get
        //    {
        //        return _cash;
        //    }
        //}

        // Нет необходимости заново объявлять свойство Hand, оно уже объявлено в Member 
        public Player()
        {
            Cash = StartCash;
        }

	    public double Cash { get; private set; }
	}
}