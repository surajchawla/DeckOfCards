namespace CardGame
{
    public class Constants
    {
        public const int NUMBER_OF_CARDS = 5;
        public const int NUMBER_OF_HANDS = 5;
    }

    public enum CardValue
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14,
    }

    public enum Suit
    {
        Hearts = 'H',
        Diamonds = 'D',
        Spades = 'S',
        Clubs = 'C'
    }
}