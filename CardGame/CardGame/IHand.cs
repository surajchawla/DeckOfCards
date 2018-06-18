namespace CardGame
{
    public interface IHand
    {
        void AddCard(Card card);
        int GetCardsInHand();
        string ShowHand();
    }
}