using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class DiscardHand : Hand
    {
        //Adding cards to the Discard Pile
        public DiscardHand AddToDiscardPile(DiscardHand dh, PlayHand ph)
        {
            for (int i = 0; i < ph.NumCards; i++)
            {
                dh.AddCard(ph.GetCard(i));
            }
            return dh;
        }

    }
}
