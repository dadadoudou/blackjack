using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.classes
{
    internal class Hand
    {
        private ArrayList cards;
        public Hand() { 
            this.cards = new ArrayList();
        }
        /// <summary>
        /// Add a card to hand
        /// </summary>
        /// <param name="card">Card</param>
        /// <returns></returns>
        public Card AddCard(Card card)
        {
            int total = this.Total();
            if (card.IsAce && card.Value > 1 && total > 10)
            {
                // if total is more than 10 than ace value can only be 1
                card.ToggleAceValue();
            }
            this.cards.Add(card);
            return card;
        }
        /// <summary>
        /// Total valule of hand's cards
        /// </summary>
        /// <returns>total value</returns>
        public int Total()
        {
            int total = 0;
            foreach (Card card in this.cards)
            {
                total += card.Value;
            }
            return total;
        }
        /// <summary>
        /// Hand is busted when total is > than 21
        /// </summary>
        /// <returns></returns>
        public bool IsBusted()
        {
            return this.Total() > 21;
        }
        /// <summary>
        /// BlackJack is when hand has 2 cards, on ace and one 10 value card
        /// </summary>
        /// <returns>true if hand is blackjack</returns>
        public bool BlackJack()
        {
            if (this.cards.Count == 2)
            {
                Card ace = null;
                int total = 0;
                foreach (Card card in this.cards)
                {
                    if (card.IsAce)
                    {
                        ace = card;
                    }
                    else
                    {
                        total += card.Value;
                    }
                }
                if (ace != null)
                {
                    if (ace.Value == 1)
                    {
                        ace.ToggleAceValue();
                    }
                    total += ace.Value;
                }
                return total == 21;
            }
            return false;
        }
        public override string ToString() {
            string message = "Hand: ";
            foreach (Card card in this.cards)
            {
                message += "\n " + card.ToString();
            }
            message += "\n Total: ";
            message += this.Total();
            return message;
        }
    }
}
