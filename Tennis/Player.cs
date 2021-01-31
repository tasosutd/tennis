using System;
using System.Collections.Generic;

namespace Tennis
{
    public class Player
    {
        public List<String> pointsDescription = new List<string>() { "Love", "Fifteen", "Thirty", "Forty" };

        private int score;
        public int GetPlayerScore()
        {
            return score;
        }

        private string name;
        public string GetName()
        {
            return name;
        }

        public void AddPoint()
        {
            this.score += 1;
        }

        public Player(string name)
        {
            this.name = name;
        }

        public string GetScoreDescription()
        {
            return pointsDescription[score];
        }
    }
}
