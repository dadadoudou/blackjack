using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.classes
{
    internal class Player
    {
        public string Name { get; private set; }
        protected Hand hand;
        public Player(string name) { 
            this.Name = name;
            this.hand = new Hand();
        }
        /// <summary>
        /// deal 
        /// </summary>
        /// <param name="deck">!Deck</param>
        /// <returns></returns>
        public virtual Hand Deal(Deck deck)
        {
            bool stop = this.hand.IsBusted();
            Console.WriteLine($"{this.Name}''s turn...");
            while(!stop)
            {
                Console.WriteLine(this.hand.ToString());
                Console.WriteLine("Would you like to continue (Y/N)? ");
                string? response = Console.ReadLine();
                if (response != null)
                {
                    switch (response.ToUpper())
                    {
                        case "Y":
                            if (this.DealCard(deck))
                            {
                                stop = this.hand.BlackJack() || this.hand.IsBusted();
                            } else
                            {
                                stop = true;
                            }
                            break;
                        case "N": 
                            stop = true; 
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                }
            }
            return this.hand;
        }
        /// <summary>
        /// Add a card to hand
        /// </summary>
        /// <param name="deck">Deck</param>
        /// <returns>True if deck is not empty</returns>
        protected bool DealCard(Deck deck)
        {
            Card? card = deck.GetCard();
            if (card != null)
            {
                this.hand.AddCard(card);
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"{this.Name}''s {this.hand.ToString()}" ;
        }
    }
}
