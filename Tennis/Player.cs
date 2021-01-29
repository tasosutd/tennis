using System;
using System.Collections.Generic;

namespace Tennis
{
    public class Player
    {
        public List<String> pointsDescription = new List<string>() { "love", "fifteen", "thirty", "forty" };

        private int score;
        public int GetPlayerScore()
        {
            return score;
        }

        String name;
        public String getName()
        {
            return name;
        }

        public void AddPoint()
        {
            this.score = this.score + 1;
        }

        public Player(String name)
        {
            this.name = name;
        }

        public String getScoreDescription()
        {
            return pointsDescription[score];
        }
    }
}
