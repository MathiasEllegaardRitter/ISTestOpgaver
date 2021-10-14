using System;
using System.Threading;

namespace IntelligentSystemsTestOpgave
{
    class Program
    {
        // Et meget simple spill, hvor programmet trækker 10 kort ud af et deck med 50.
        static void Main(string[] args)
        {
            // antallet der skal trækkes fra.
            int cardPull = 10;

            CardGameThreadSafe cardGame = new CardGameThreadSafe();


            for (int i = 0; i < 5; i++)
            {
                Thread th1 = new Thread(() => cardGame.ReceiveCard(cardPull));
                th1.Start();
            }

        }


    }
}
