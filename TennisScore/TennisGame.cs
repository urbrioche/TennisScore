using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class TennisGame
    {
        private readonly IRepository<Game> _repo;
        private static Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"}
        };

        public TennisGame(IRepository<Game> repo)
        {
            _repo = repo;
        }

        public string ScoreResult(int gameId)
        {
            var game = this._repo.GetGame(gameId);

            if (game.FirstPlayerScore == game.SecondPlayerScore && game.FirstPlayerScore == 3)
            {
                return "Deuce";
            }

            if (game.FirstPlayerScore == game.SecondPlayerScore)
            {
                return  _scoreLookup[game.FirstPlayerScore] + " All";
            }
            

            throw new NotImplementedException();

        }
    }
}