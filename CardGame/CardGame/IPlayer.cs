namespace CardGame
{
    public interface IPlayer
    {
        void ReceiveCard(Card card);
        string ShowHand();
    }
}