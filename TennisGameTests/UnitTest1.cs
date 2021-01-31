using System;
using NUnit.Framework;
using Tennis;

namespace TennisGameTests
{
    public class Tests
    {
        Player server;
        Player receiver;
        Game game;

        [SetUp]
        public void BeforeTest()
        {
            server = new Player("J");
            receiver = new Player("B");
            game = new Game(server, receiver);
        }

        [Test]
        public void Initialise_Players()
        {
            Assert.IsNotNull(server.GetName());
            Assert.IsNotNull(receiver.GetName());
        }

        [Test]
        public void Update_Score()
        {
            game.Point_To(server);
            game.Point_To(receiver);

            Assert.IsTrue(server.GetPlayerScore() > 0);
            Assert.IsTrue(receiver.GetPlayerScore() > 0);
        }

        [Test]
        public void Check_Score_Board()
        {
            // Rule:
            // The serving player's score is always first, the receiving player's score is second

            game.Point_To(server);
            game.Point_To(server);
            game.Point_To(receiver);
            game.Point_To(server);

            string output = "Score: Forty, Fifteen";
            Assert.AreEqual(output, game.GetMatchScore());
        }

        [Test]
        public void Check_Love_For_0()
        {
            // Rule:  scores from zero to three points are described as "love", "fifteen", "thirty", and "forty" respectively

            string output = "Love";
            Assert.AreEqual(output, server.GetScoreDescription());
        }

        [Test]
        public void Check_Fifteen_For_15()
        {
            // Rule:  scores from zero to three points are described as "love", "fifteen", "thirty", and "forty" respectively

            game.Point_To(server);

            string output = "Fifteen";
            Assert.AreEqual(output, server.GetScoreDescription());
        }

        [Test]
        public void Check_Thirty_For_2()
        {
            // Rule:  scores from zero to three points are described as "love", "fifteen", "thirty", and "forty" respectively

            game.Point_To(server);
            game.Point_To(server);

            string output = "Thirty";
            Assert.AreEqual(output, server.GetScoreDescription());
        }

        [Test]
        public void Check_Forty_For_2()
        {
            // Rule:  scores from zero to three points are described as "love", "fifteen", "thirty", and "forty" respectively

            game.Point_To(server);
            game.Point_To(server);
            game.Point_To(server);

            string output = "Forty";
            Assert.AreEqual(output, server.GetScoreDescription());
        }

        [Test]
        public void Check_Advantage()
        {
            // Rule:
            // If at least three points have been scored by each side and a player has one more point than his opponent,
            // the score of the game is "advantage" for the player in the lead

            game.Point_To(server);
            game.Point_To(receiver);
            game.Point_To(server);
            game.Point_To(receiver);
            game.Point_To(server);
            game.Point_To(receiver);
            game.Point_To(receiver);

            string output = "Score: Advantage, B";
            Assert.AreEqual(output, game.GetMatchScore());
        }

        [Test]
        public void Check_Deuce()
        {
            // Rule:
            // If at least three points have been scored by each player,
            // and the scores are equal, the score is "deuce"

            game.Point_To(server);
            game.Point_To(receiver);
            game.Point_To(server);
            game.Point_To(receiver);
            game.Point_To(server);
            game.Point_To(receiver);

            string output = "Score: Deuce";
            Assert.AreEqual(output, game.GetMatchScore());
        }

        [Test]
        public void Check_Game_Won()
        {
            // Rule:
            // first player to have won at least four points in total
            // and at least two points more than the opponent

            for (int i = 1; i <= 4; i++)
            {
                game.Point_To(server);
            }

            for (int i = 1; i <= 3; i++)
            {
                game.Point_To(receiver);
            }

            string outputServerWins = "Score: Game, J";
            string outputReceiverWins = "Score: Game, B";
            Assert.AreNotEqual(outputServerWins, game.GetMatchScore());
            Assert.AreNotEqual(outputReceiverWins, game.GetMatchScore());

            game.Point_To(server);
            Assert.AreEqual(outputServerWins, game.GetMatchScore());
        }

    }
}