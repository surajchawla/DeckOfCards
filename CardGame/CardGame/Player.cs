using System.Text;

namespace CardGame
{
    public class Player : IPlayer
    {
        private IHand _hand;
        private string _playerName;

        public Player(string playerName)
        {
            _playerName = playerName;
            _hand = new Hand();
        }

        /*
         * This method add the card to the hand once it is dealt
         */
        public void ReceiveCard(Card card)
        {
            _hand.AddCard(card);
        }

        /*
         * This method concatenates all the cards that a player has in hand and returns a string 
         */
        public string ShowHand()
        {
            if (_hand != null && _hand.GetCardsInHand() > 0)
            {
                return $"{_playerName} : {_hand.ShowHand()}";
            }

            return "No cards dealt yet";
        }

    }
}