using System;

namespace Tennis
{
    class Program
    {
        static void Main(string[] args)
        {
            // Run a sample case
            TestScenario_B_Won();

            Console.WriteLine("Sample scenario finished. Press any key to exit ...");
            Console.ReadKey();
            
        }

        private static void TestScenario_B_Won()
        {
            Player server = new Player("J");
            Player receiver = new Player("B");
            Game game = new Game(server, receiver);

            Console.WriteLine("Server: " + server.GetName());
            Console.WriteLine("Receiver: " + receiver.GetName());

            game.Point_To(server);
            game.Point_To(receiver);

            Console.WriteLine(game.GetMatchScore());

            game.Point_To(server);
            game.Point_To(receiver);

            Console.WriteLine(game.GetMatchScore());

            game.Point_To(server);
            game.Point_To(receiver);
            game.Point_To(receiver);

            Console.WriteLine(game.GetMatchScore());

            game.Point_To(receiver);

            Console.WriteLine(game.GetMatchScore());
        }
    }
}