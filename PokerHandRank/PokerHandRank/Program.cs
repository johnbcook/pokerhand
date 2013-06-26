using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandRank
{
    class Program
    {
        static void Main(string[] args)
        {

           
            PokerHandEval test = new PokerHandEval();
                    
            
            bool more = true;

            try
            {
                while (more)
                {
                    Console.Write("Enter a Poker Hand in the following Format:  As Jd Kc Qc 10h" + "\n");
                   
                    string input = Console.ReadLine();
          
                    Console.Write(test.evaluatehand(input));

                    Console.Write("Would you like to evaluate another hand? Enter Y or N. ");

                    string x = Console.ReadLine();

                    if(x.Equals("N") || x.Equals("n")){ more = false;}
                }
            }
            catch (Exception e)
            {

                Console.Write("Failed with Exception: " + e.Message + "\n");

            }
    
            
        }
    }
}
