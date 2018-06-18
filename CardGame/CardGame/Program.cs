using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace CardGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();

            var players = GetPlayers(Constants.NUMBER_OF_HANDS);
            try
            {
                DealCards(deck, players, Constants.NUMBER_OF_CARDS);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while dealing the cards : {ex}");
            }
            

            var appSettings = ConfigurationManager.AppSettings;
            var outputFileName = appSettings["outputFileName"];

            if (string.IsNullOrEmpty(outputFileName))
            {
                outputFileName = "output.txt";
            }

            WriteAllPlayerHands(players, outputFileName);
            Console.ReadLine();
        }

        /*
         * This method writes the output to a file 
         */
        public static void WriteAllPlayerHands(IPlayer[] players, string fileName)
        {
            try
            {
                using (FileStream outputStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter(outputStream))
                    {
                        TextWriter textWriter = Console.Out;

                        Console.SetOut(streamWriter);
                        Console.WriteLine(GetAllPlayerHands(players));
                        Console.SetOut(textWriter);
                    }
                }

                Console.WriteLine("Finished writing to file !!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while writing to file  : {ex}");
            }
        }

        /*
        * This method writes the output to a Console
        * This method is an overload to the above method which writes to the file 
        */
        private static void WriteAllPlayerHands(IPlayer[] players)
        {
            try
            {
                Console.WriteLine(GetAllPlayerHands(players));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while displaying results on Console  : {ex}");
            }
        }
            
        

        /*
         * This method creates the output in a string builder and returns a string
         * In case we need to  write the output to Console we can re-use this method
         */
        public static string GetAllPlayerHands(IPlayer[] players)
        {
            try
            {
                StringBuilder output = new StringBuilder();
                foreach (var player in players)
                {
                    output.AppendLine(player.ShowHand());
                }
                return output.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /*
         * This method instantiates the list of players
         */
        public static void DealCards(IDeck deck, IPlayer[] players, int numberOfCards)
        {
            try
            {
                deck.Shuffle();
                for (int i = 0; i < numberOfCards; i++)
                {
                    foreach (var player in players)
                    {
                        player.ReceiveCard(deck.DealCard());
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /*
         * This method instantiates the list of players
         */
        public static IPlayer[] GetPlayers(int numberOfHands)
        {
            IPlayer[] players = new IPlayer[numberOfHands];
            try
            {
                for (int i = 0; i < numberOfHands; i++)
                {
                    players[i] = new Player($"Player #{i + 1}");
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while instantiating the player class  : {ex}");
            }
            return players;
        }
    }
}
