using System;
using System.Collections.Generic;

namespace Tennis
{
    public class Game
    {
        private Player server;
        private Player reveiver;

        // game.new(server, reveiver)
        public Game(Player server, Player receiver)
        {
            this.server = server;
            this.reveiver = receiver;
        }

        // game.score()
        public string GetMatchScore()
        {
            if (server.GetPlayerScore() >= 3 && reveiver.GetPlayerScore() >= 3)
            {
                if (Math.Abs(reveiver.GetPlayerScore() - server.GetPlayerScore()) >= 2)
                {
                    return "Score: Game, " + GetLeadPlayer().GetName();
                }
                else if (server.GetPlayerScore() == reveiver.GetPlayerScore())
                { 
                    return "Score: Deuce";
                }
                else
                {
                    return "Score: Advantage, " + GetLeadPlayer().GetName();
                }
            }
            else
            {
                return "Score: " + server.GetScoreDescription() + ", " + reveiver.GetScoreDescription();
            }
        }

        public Player GetLeadPlayer()
        {
            return (server.GetPlayerScore() > reveiver.GetPlayerScore()) ? server : reveiver;
        }

        // game.point_to(server/reveiver)
        public void Point_To (Player player)
        {
            player.AddPoint();
        }
    }
}
