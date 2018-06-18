using System;
using System.Collections.Generic;

namespace CardGame
{
    public class Deck : IDeck
    {
        private List<Card> _cardDeck;

        public Deck()
        {
            _cardDeck = new List<Card>();
            SetCards();
        }

        /*
         * This method initializes the deck with the all the cards
         */
        private void SetCards()
        {
            foreach (CardValue cardValue in Enum.GetValues(typeof(CardValue)))
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    _cardDeck.Add(new Card(cardValue, suit));
                }
            }
        }

        /*
         * This method resets the deck for a ne game
         */
        public void ResetCards()
        {
            if (_cardDeck != null)
            {
                _cardDeck.Clear();
            }
            else
            {
                _cardDeck = new List<Card>();
            }
            SetCards();
        }

        /*
         * This method shuffles the deck 
         */
        public void Shuffle()
        {
            Random random = new Random();

            int count = _cardDeck.Count;
            for (int i = 0; i < count ; i++)
            {
                int randomIndex = random.Next(count - i);
                Swap(i, randomIndex);
            }
        }

        private void Swap(int index, int secondIndex)
        {
            Card temp = _cardDeck[index];
            _cardDeck[index] = _cardDeck[secondIndex];
            _cardDeck[secondIndex] = temp;
        }

        /*
         * This method deals the card on top of the deck to the player 
         */
        public Card DealCard()
        {
            if(_cardDeck.Count == 0)
                throw new EmptyDeckException("No card left in the deck");

            Card card = _cardDeck[0];
            _cardDeck.RemoveAt(0);
            return card;
        }
    }
}