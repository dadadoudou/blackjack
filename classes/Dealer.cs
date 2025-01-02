using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.classes
{
    internal class Dealer : Player
    {
        public Dealer() : base("Dealer") { }
        /// <summary>
        /// Dealer playing
        /// </summary>
        /// <param name="deck"></param>
        /// <returns>Dealer hand</returns>
        public override Hand Deal(Deck deck)
        {
            bool stop = false;
            Console.WriteLine("Dealer is playing...");
            while (!stop)
            {
                stop = !base.DealCard(deck);
                if (!stop)
                {
                    stop = this.hand.BlackJack() || this.hand.IsBusted();
                }
                if (!stop)
                {
                    if (21 - this.hand.Total() < 4)
                    {
                        stop = true;
                    }
                }
            }
            Console.WriteLine("Dealer is done.");
            return this.hand;
        }
    }
}
