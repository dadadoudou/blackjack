using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.classes
{
    internal class Card
    {
        public int Value { get; private set; }
        
        public string Name { get; private set; }
        public bool IsAce { get; private set; }

        public Card(string name, int value, bool isAce) { 
            this.Name = name;
            this.Value = value;
            this.IsAce = isAce;
        }

        /// <summary>
        /// Ace value can be 1 or 11
        /// Toggle value
        /// </summary>
        public void ToggleAceValue()
        {
            if (IsAce)
            {
                if (this.Value == 1)
                {
                    this.Value = 11;
                }
                else
                {
                    this.Value = 1;
                }
            }
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
