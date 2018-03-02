using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class Game
    {
        private static Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"}
        };

        private string _Deuce;

        public Game()
        {
            _Deuce = "Deuce";
        }

        public string FirstPlayerName { get; set; }
        public int FirstPlayerScore { get; set; }
        public int Id { get; set; }
        public string SecondPlayerName { get; set; }
        public int SecondPlayerScore { get; set; }

        public string ScoreResult()
        {
            return IsSameScore() ?
                (IsDeuce() ? _Deuce : SameScoreLookup()) :
                (IsReadyForWin() ? AdvState() : LookupScore());
        }

        private string SameScoreLookup()
        {
            return _scoreLookup[FirstPlayerScore] + " All";
        }

        private bool IsDeuce()
        {
            return FirstPlayerScore >= 3;
        }

        private string AdvPlayer()
        {
            return FirstPlayerScore > SecondPlayerScore
                ? FirstPlayerName
                : SecondPlayerName;
        }

        private string AdvState()
        {
            return AdvPlayer() + " " + (IsAdv() ? "Adv" : "Win");
        }

        private bool IsAdv()
        {
            return Math.Abs(FirstPlayerScore - SecondPlayerScore) == 1;
        }

        private bool IsReadyForWin()
        {
            return FirstPlayerScore > 3 || SecondPlayerScore > 3;
        }

        private bool IsSameScore()
        {
            return FirstPlayerScore == SecondPlayerScore;
        }

        private string LookupScore()
        {
            return _scoreLookup[FirstPlayerScore] + " " + _scoreLookup[SecondPlayerScore];
        }
    }
}