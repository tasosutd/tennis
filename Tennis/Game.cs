using System;
using System.Collections.Generic;

namespace Tennis
{
    public class Game
    {
        private Player server;
        private Player reveiver;

        private List<string> pointsLog = new List<string>();

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
                    return "Game, " + getLeadPlayer().getName();
                }
                else if (server.GetPlayerScore() == reveiver.GetPlayerScore())
                { 
                    return "Deuce";
                }
                else
                {
                    return "Advantage, " + getLeadPlayer().getName();
                }
            }
            else
            {
                return "Score: " + server.getScoreDescription() + ", " + reveiver.getScoreDescription();
            }
        }

        public Player getLeadPlayer()
        {
            return (server.GetPlayerScore() > reveiver.GetPlayerScore()) ? server : reveiver;
        }

        // game.point_to(server/reveiver)
        public string Point_To (Player player)
        {
            player.AddPoint();
            pointsLog.Add(player.getName());

            return "Points won: " + string.Join(", ", pointsLog);
        }
    }
}
