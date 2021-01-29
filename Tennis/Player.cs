using System;
namespace Tennis
{
    public class Player
    {
        private string Server { get; set; }

        private string Receiver { get; set; }

        private int ServerScore { get; set; }

        private int ReceiverScore { get; set; }

        public Player(string server, string receiver)
        {
            // initialise players
            Server = server;
            Receiver = receiver;

            // initialise scoreboard
            ServerScore = 0;
            ReceiverScore = 0;
        }
    }
}
