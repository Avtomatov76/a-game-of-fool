using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class PlayHand : Hand
    {       
        public PlayHand() {}

        //adding a card to PlayHand 
        public void AddCardToPlayHand(PlayHand ph, FoolHand defPlayer, Card c) 
        {           
            if (ph.NumCards < defPlayer.NumCards * 2)
                ph.AddCard(c);
        }

    }
}
