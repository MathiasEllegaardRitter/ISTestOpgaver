using System;
using System.Collections.Generic;
using System.Text;

namespace IntelligentSystemsTestOpgave
{
   public class CardGameThreadSafe
    {
        // Data kan kun ændres Receivecard metoden, da data er private.
        private static int deck = 50;
        private int hand;
        private Object lockObject = new Object();

        public  void ReceiveCard(int amountOfCards)
        {
            lock (lockObject) // sikrer af andre threads ikke kan ændre data.
            {
            hand += amountOfCards;
            Console.WriteLine("hand is " + hand);
            deck -= amountOfCards;
            Console.WriteLine("deck is " + deck);
            }
        }

    }
}
