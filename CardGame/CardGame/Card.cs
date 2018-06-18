using System;

namespace CardGame
{
    public class Card : IComparable<Card>
    {
        private readonly CardValue _cardValue;
        private readonly Suit _suit;

        /*
         * This method sets the card to a particular suit and value
         */
        public Card(CardValue cardValue, Suit suit)
        {
            _cardValue = cardValue;
            _suit = suit;
        }

        /*
         * This method displays the card in the required format
         */
        public override string ToString()
        {
            switch (_cardValue)
            {
                case CardValue.Ace:
                    return $"A{(char)_suit}";

                case CardValue.King:
                    return $"K{(char)_suit}";

                case CardValue.Queen:
                    return $"Q{(char)_suit}";

                case CardValue.Jack:
                    return $"J{(char)_suit}";

                default:
                    return $"{(int)_cardValue}{(char)_suit}";

            }
            
        }

        /*
         * Since we implement the IComparable interface we implement the CompareTo method in order to compare two different card.
         * This method is being used internally when we call the Sort method on the List<Card> 
         */
        public int CompareTo(Card other)
        {
            return this._cardValue.CompareTo(other._cardValue);
        }
    }
}