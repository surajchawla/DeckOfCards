namespace CardGame
{
    public interface IDeck
    {
        void Shuffle();
        Card DealCard();
        void ResetCards();
    }
}