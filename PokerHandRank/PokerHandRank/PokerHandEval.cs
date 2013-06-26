using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandRank
{
    /// <summary>
    /// Class containing methods to evaluate a poker hand
    /// </summary>
    public class PokerHandEval
    {

        /// <summary>
        /// Method to evaluate if a hand is a royal flush
        /// </summary>
        /// <param name="hand">List of 5 Cards</param>
        /// <returns>true if hand is a royal flush</returns>
        public bool royalflush(List<Card> hand) 
        {
                   
            // check for flush
            if (!flush(hand))
            {
                return false;
            }
            // check for straight
            if (!straight(hand))
            {
                return false;
            }

            // verify cards are Ten, Jack, Queen, King, Ace

            return (valuefound(hand, CardValue.Ace) && valuefound(hand, CardValue.King) && valuefound(hand, CardValue.Queen) && valuefound(hand, CardValue.Jack) && valuefound(hand, CardValue.Ten));

         
        }

        /// <summary>
        /// Method to evaluate if a hand is a straight flush
        /// </summary>
        /// <param name="hand">List of Cards</param>
        /// <returns>true if straight flush</returns>
        public bool straightflush(List<Card> hand)
        {

            if (!(royalflush(hand)))
            {
                if (straight(hand) && flush(hand))
                {
                    return true;
                }
            }
            return false;

        }
        
        /// <summary>
        /// Method to evaluate if a hand is four of a kind
        /// </summary>
        /// <param name="hand">List of cards</param>
        /// <returns>true if four of a kind</returns>
        public bool fourofakind(List<Card> hand)
        {
           
            foreach( Card x in hand) {
           
              if (hand.Count(card => card.Value == x.Value) == 4)
              {
                  return true;
              }
            }
            return false;

        }

        /// <summary>
        /// Method 
        /// </summary>
        /// <param name="hand">List of cards</param>
        /// <returns>true if full house</returns>
        public bool fullhouse(List<Card> hand)
        {
            List<Card> testlist =  new List<Card>(hand);


             // check for 3 of a kind
            foreach (Card x in testlist)
            {
                if (testlist.Count(card => card.Value == x.Value) == 3)
                {
                    testlist.RemoveAll(card => card.Value == x.Value);
                    break;                 
                }              

            }

            if (testlist.Count == 2)
            {
                foreach (Card x in testlist)
                {
                    if (testlist.Count(card => card.Value == x.Value) == 2)
                    {
                        return true;
                    }  

                }

            }



            return false;

        }

        /// <summary>
        /// Method to evaluate if hand is a flush
        /// </summary>
        /// <param name="hand">List of hands</param>
        /// <returns>true if flush</returns>
        public bool flush(List<Card> hand)
        {
            // Test that all cards are the same suit using lamda
            // passes card parameter to the bool evaluation
           return hand.All(card => card.Suit == hand[0].Suit);
        }

        /// <summary>
        /// Method to evaluate if hand is a straight
        /// </summary>
        /// <param name="hand">List of cards</param>
        /// <returns>returns true if straight</returns>
        public bool straight(List<Card> hand)
        {
            bool straight = true;
            
            // Sort List by value using Lamda expression passing 2 card parms to Compare
            hand.Sort((card1, card2) => card1.Value.CompareTo(card2.Value));                 

            // Evaluate for a straight based on sorted values list
                       
            for (int i = 0; i < hand.Count(); i++)
            {
                // If card is an Ace, check for next card being a 2 or a Ten
                if (i == 0)
               {
                    if ((int)hand[i].Value == 0)
                    {
                        if (((int)hand[i + 1].Value == 1) || ((int)hand[i + 1].Value == 9))
                        {                      
                            continue;
                        }
                        else {
                            return false;
                        }
                    }
                    continue;
                }           
            
             if (i < (hand.Count - 1))
                {
                    int x = i + 1;
                    if ((hand[x].Value - hand[i].Value) == 1)
                        {
                            continue;
                        }
                        else { return false; }
                 }
             }
           

            return straight; 
        }

        /// <summary>
        /// Method to evaluate if hand is a Three of a Kind
        /// </summary>
        /// <param name="hand">List of Cards</param>
        /// <returns>true if three of a kind</returns>
        public bool threeofakind(List<Card> hand)
        {
            // Verify not Four of a Kind or Royal Flush

          if (!fullhouse(hand) && !fourofakind(hand))
          {
               foreach (Card x in hand)
               {
                   if (hand.Count(card => card.Value == x.Value) == 3)
                   {
                       return true;
                   }
               }
            }

           return false;
            
        }

        /// <summary>
        /// Method to evaluate if a hand is a Two Pair
        /// </summary>
        /// <param name="hand">List of Cards</param>
        /// <returns>true if hand is a two pair</returns>
        public bool twopair(List<Card> hand)
        {
            List<Card> testlist = new List<Card>(hand);

            // Verify not Full House, 4 of a Kind or 3 of a kind

            if (!fullhouse(hand) && !fourofakind(hand) && !threeofakind(hand))
            foreach (Card x in testlist)
            {
                if (testlist.Count(card => card.Value == x.Value) == 2)
                {
                    testlist.RemoveAll(card => card.Value == x.Value);
                    break;
                }

            }

            if (testlist.Count == 3)
            {
                foreach (Card x in testlist)
                {
                    if (testlist.Count(card => card.Value == x.Value) == 2)
                    {
                        return true;
                    }

                }

            }

            return false;
        }

        /// <summary>
        /// Method to evaluate hand for a pair
        /// </summary>
        /// <param name="hand">List of Cards</param>
        /// <returns>true if hand contains a pair</returns>
        public string pair(List<Card> hand)
        {
            if (!fullhouse(hand) && !fourofakind(hand) && !threeofakind(hand) && !twopair(hand))
                foreach (Card x in hand)
                {
                    if (hand.Count(card => card.Value == x.Value) == 2)
                    {
                        return x.Value.ToString();
                    }

                }
            return "false";
        }

        /// <summary>
        /// Method to find High Card of a hand
        /// </summary>
        /// <param name="hand">List of Cards</param>
        /// <returns>Card.CardValue</returns>
        public CardValue highcard(List<Card> hand)
        {
            // Sort List
            hand.Sort((card1, card2) => card1.Value.CompareTo(card2.Value));

            foreach (Card x in hand)
            {

                if ((int)x.Value == 0)
                {
                    return x.Value;
                    
                }

            }
            
            // return highest index

            return hand[hand.Count - 1].Value;
       
        }

        /// <summary>
        /// Method to check a hand for a specific card
        /// </summary>
        /// <param name="hand">List of Cards</param>
        /// <param name="value">CardValue</param>
        /// <returns>true if found</returns>
        public bool valuefound(List<Card> hand, CardValue value)
        {

            if(hand.Count(card => card.Value == value) >= 1){
                return true;
            }
                  

              return false;

        }

       
        /// <summary>
        ///  Method to generate a hand of 5 cards from a sting input 
        /// </summary>
        /// <param name="input">format: As Ah Kc 5d 6h</param>
        /// <returns>List of Cards containing 5 cards</Cardd></Cards></returns>
        public List<Card> generatehand(string input)
        {
            List<Card> hand = new List<Card>();
            CardValue value;
            Suit suit;

            string validvalues = "A K Q J 10 9 8 7 6 5 4 3 2";
            string validsuits = "s c h d";
            string z = "";
            string y = "";
            string[] cards = input.Split(' ');

            try
            {
                if (cards.Length != 5)
                {
                    throw new Exception("Please provide 5 cards in format:  As Ah Kc 5d 6h");
                }

                foreach (String x in cards)
                {
                    try
                    {
                        // Verify card format length 2 or 3 allowed
                        if (x.Length !=2 && x.Length !=3)
                        {
                            throw new Exception("Your Card " + x + " is not a valid card, please provide a valid card such as As" + "\n");
                        }
                        
                        // get first item of string length 2
                        if (x.Length == 2)
                        {
                            z = x.Substring(0, 1);
                        }
                        // Length 3
                        if (x.Length == 3)
                        {
                            z = x.Substring(0, 2);
                        }

                        // Verify valid value
                        if (!validvalues.Contains(z))
                        {
                            throw new Exception("Your Card " + x + " contains an invalid value " + z + " provide a valid value " + validvalues);
                          
                        }

                        // get value of suit for length 2
                        if (x.Length == 2)
                        {
                            // get second item of string
                            y = x.Substring(1, 1);
                          
                        }
                        // get value of suit for length 3
                        if (x.Length == 3)
                        {
                            y = x.Substring(2, 1);
                        }

                   
                       
                        // Verify valid Suit
                        if (!validsuits.Contains(y))
                        {
                            throw new Exception("Your Card " + x + " contains an invalid suit " + y + " provide a valid suit " + validsuits);

                        }

                        // get value
                        value = convertvalue(z);
                        // get suit
                        suit = convertsuit(y);
                        
                        // create card object and add to list
                        Card newcard = new Card();
                        newcard.Value = value;
                        newcard.Suit = suit;

                        // add Card to list
                        hand.Add(newcard);

                    }
                    catch (Exception e)
                    {
                        Console.Write(e.Message + "\n");
                        return null;
                    }

                }
               
            }
            catch (Exception e)
            {
                Console.Write(e.Message + "\n");
                return null;
            }

            return hand;
        }

        /// <summary>
        /// Method to convert a user input card value or suit to its longname. 
        /// </summary>
        /// <param name="input">single index string such as A or s</param>
        /// <returns>card value or suit longname used for Card object generation. </returns>
        public CardValue convertvalue(string input)
        {
          

            switch (input)
            {
                case "A":
                 
                return CardValue.Ace;

                case "K":
                return CardValue.King;

                case "Q":
                return CardValue.Queen;

                case "J":
                return CardValue.Jack;

                case "10":
                return CardValue.Ten;

                case "9":
                return CardValue.Nine;

                case "8":
                return CardValue.Eight;

                case "7":
                return CardValue.Seven;

                case "6":
                return CardValue.Six;

                case "5":
                return CardValue.Five;

                case "4":
                return CardValue.Four;

                case "3":
                return CardValue.Three;

                case "2":
                return CardValue.Two;

                //This will throw an exception when trying to generate an enum from string that does not exist. 
                default:
                Console.Write("Card Value or Suit " + input + "is not valid, please enter a valid Card Value or Suit");              
                CardValue notvalid = (CardValue) Enum.Parse(typeof(CardValue), input);
                return notvalid;
             


            }

        }

        public Suit convertsuit(string input)
        {
            switch (input)
            {
                case "s":
                    return Suit.Spade;

                case "c":
                    return Suit.Club;

                case "h":
                    return Suit.Heart;

                case "d":
                    return Suit.Diamond;

                //This will throw an exception when trying to generate an enum from string that does not exist. 
                default:
                    Console.Write("Card Value or Suit " + input + "is not valid, please enter a valid Card Value or Suit");
                    Suit notvalid = (Suit)Enum.Parse(typeof(Suit), input);
                    return notvalid;
             

            }
                 
        }

        /// <summary>
        /// Method to evaluate a poker hand
        /// </summary>
        /// <param name="input">string in format As Kh Qd 10c 9s</param>
        /// <returns>Rank of hand</returns>
        public string evaluatehand(string input)
        {

            try
            {

                List<Card> newhand = new List<Card>(generatehand(input));

                if (newhand.Count != 5)
                {
                    throw new Exception("Hand does not contain 5 cards, aborting");
                }

               // evaluate royal flush

                if(royalflush(newhand)){

                   return "Your hand " + input + " is a Royal Flush!" + "\n";
                }

                // evaluate straight flush 

                if (straightflush(newhand))
                {
                    return "Your hand " + input + " is a Straight Flush!" + "\n";
                }

                // evaluate 4 of a Kind

                if (fourofakind(newhand))
                {
                    return "Your hand " + input + " is a Four of a Kind!" + "\n";                    
                }

                // evaluate Full House
                if (fullhouse(newhand))
                {
                    return "Your hand " + input + " is a Full House!" + "\n";
                }

                //evaluate flush
                if(flush(newhand))
                {
                   return "Your hand " + input + " is a Flush!" + "\n";
                }

                //evaluate straight

                if (straight(newhand))
                {
                    return "Your hand " + input + " is a Straight!" + "\n";
                }

                //evaluate 3 of a kind
                if (threeofakind(newhand))
                {
                    return "Your hand " + input + " is a Three of a Kind!" + "\n";
                }


                //evaluate 2 pair

                if (twopair(newhand))
                {
                    return "Your hand " + input + " is a Two Pair!" + "\n";
                }

                //evaluate pair

                if (!pair(newhand).Equals("false"))
                {
                    return "Your hand " + input + " is a Pair of " + pair(newhand) + "s" + "\n";
                }

                //evaluate highcard

                return "Your hand has a high card of " + highcard(newhand) + "\n";


            }
            catch (Exception e)
            {
                Console.Write("Failed with Exception " + e.Message + "\n");
                return null;

            }

            return null;


        }

    }
}
