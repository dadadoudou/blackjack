using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.classes
{
    internal class Deck
    {
        private List<Card> cards;
        private Random random;

        public Deck() { 
            this.cards = new List<Card>();
            this.random = new Random();
        }   
        /// <summary>
        /// Builds deck
        /// </summary>
        public void Shuffle()
        {
            string[] families = { "club", "spades", "diamond", "heart" };
            string[] special = { "Jack", "Queen", "King" };
            // clear deck
            this.cards.Clear();
            foreach (string family in families)
            {
                Card card;
                // add cards from 1 to  10
                for (int i = 1; i <= 10; i++) {
                    card = new Card($"{i} of {family}", i, false);
                    this.cards.Add(card);
                }
                // add special cards
                foreach (string n in special)
                {
                    card = new Card($"{n} of {family}", 10, false);
                    this.cards.Add(card);
                }
                // add Aces
                card = new Card($"Ace of {family}", 1, true);
            }
        }
        /// <summary>
        /// Get a random card and removes the card from the deck
        /// </summary>
        /// <returns>Card</returns>
        public Card? GetCard()
        {
            if (this.cards.Count == 0) return null;   
            int index = this.random.Next(0, this.cards.Count - 1);
            Card card = this.cards[index];
            this.cards.RemoveAt(index);
            return card;
        }
    }
}
