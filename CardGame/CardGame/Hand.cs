using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class Hand : IHand
    {
        private List<Card> _hand;

        public Hand()
        {
            _hand = new List<Card>();
        }

        public void AddCard(Card card)
        {
            _hand.Add(card);
        }
        
        public int GetCardsInHand()
        {
            if (_hand != null) return _hand.Count;

            return 0;
        }

        public string ShowHand()
        {
            StringBuilder output = new StringBuilder();
            _hand.Sort();
            foreach (var card in _hand)
            {
                if (string.IsNullOrEmpty(output.ToString()))
                {
                    output.Append(card);
                }
                else
                {
                    output.AppendFormat($"-{card}");
                }
            }
            return output.ToString();
        }

        
    }
}