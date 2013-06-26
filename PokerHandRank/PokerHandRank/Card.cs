using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandRank
{
    /// <summary>
    /// Enumeration containing Card values
    /// </summary>
    public enum CardValue {Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };

    /// <summary>
    /// Enumeration containing Suit values
    /// </summary>
    public enum Suit {Heart, Spade, Diamond, Club };

    /// <summary>
    /// Card Struct
    /// </summary>
    public struct Card
    {
       
        public CardValue Value;
        public Suit Suit;

      // Construct Card object
        public Card(CardValue v, Suit s)
        {
            Value = v;
            Suit = s;
         }

    }
}
