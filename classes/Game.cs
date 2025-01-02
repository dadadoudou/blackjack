namespace blackjack.classes
{
    internal class Game
    {
        /// <summary>
        /// Launch a BlackJack game with one dealer and one player
        /// </summary>
        public void Play()
        {
            Deck deck = new Deck();
            Dealer dealer = new Dealer();
            Console.WriteLine("Welcome to my simple blackjack !");

            deck.Shuffle();
            Console.WriteLine("What''s your name?");
            string? name = Console.ReadLine();
            if (name != null)
            {
                Player player = new Player(name);
                Hand playerHand = player.Deal(deck);
                Hand dealerHand = dealer.Deal(deck);

                Console.WriteLine(player.ToString());
                Console.WriteLine(dealer.ToString());
                int playerTotal = playerHand.Total();
                int dealerTotal = dealerHand.Total();
                bool playerBusted = playerHand.IsBusted();
                bool dealerBusted = dealerHand.IsBusted();
                bool playerBlackJack = playerHand.BlackJack();
                bool dealerBlacJack = dealerHand.BlackJack();
                if (playerBusted && !dealerBusted)
                {
                    Console.WriteLine("Dealer wins!");
                } else if (playerBusted && dealerBusted)
                {
                    Console.WriteLine("Nobody wins!");
                } else if (!playerBusted && dealerBusted) {
                    Console.WriteLine("You win!");
                } else
                {
                    if (playerBlackJack && !dealerBlacJack)
                    {
                        Console.WriteLine("You win!");
                    } else if(dealerBlacJack && !playerBlackJack)
                    {
                        Console.WriteLine("Dealer wins!");
                    } else
                    {
                        if (playerTotal > dealerTotal)
                        {
                            Console.WriteLine("You win!");
                        } else if  (playerTotal == dealerTotal)
                        {
                            Console.WriteLine("Draw!");   
                        } else
                        {
                            Console.WriteLine("Dealer wins!");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}
