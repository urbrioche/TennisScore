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

            if (IsSameScore(game))
            {
                return IsDeuce(game) ? "Deuce" : $"{ _scoreLookup[game.FirstPlayerScore] } All";
            }

            if (IsReadyForWin(game) && Math.Abs(game.FirstPlayerScore - game.SecondPlayerScore) == 1)
            {
                return $"{ AdvPlayer(game) } Adv";
            }

            if (IsReadyForWin(game) && Math.Abs(game.FirstPlayerScore - game.SecondPlayerScore) == 2)
            {
                return $"{ AdvPlayer(game) } Win";
            }
            //if (game.FirstPlayerScore == game.SecondPlayerScore && game.FirstPlayerScore == 3)
            //{
            //    return "Deuce";
            //}

            //if (game.FirstPlayerScore == game.SecondPlayerScore)
            //{
            //    return _scoreLookup[game.FirstPlayerScore] + " All";
            //}

            //if (game.FirstPlayerScore >= 4 || game.SecondPlayerScore >= 4 && Math.Abs(game.FirstPlayerScore - game.SecondPlayerScore) == 1)
            //{
            //    return (game.FirstPlayerScore > game.SecondPlayerScore
            //               ? game.FirstPlayerName
            //               : game.SecondPlayerName) +
            //           " Adv";
            //}

            //if (game.FirstPlayerScore >= 4 || game.SecondPlayerScore >= 4 &&
            //    Math.Abs(game.FirstPlayerScore - game.SecondPlayerScore) == 2)
            //{
            //    return (game.FirstPlayerScore > game.SecondPlayerScore
            //        ? game.FirstPlayerName
            //        : game.SecondPlayerName) + " Win";
            //}

            return _scoreLookup[game.FirstPlayerScore] + " " + _scoreLookup[game.SecondPlayerScore];

        }

        private static bool IsReadyForWin(Game game)
        {
            var isReadyForWin = game.FirstPlayerScore > 3 || game.SecondPlayerScore > 3;
            return isReadyForWin;
        }

        private static string AdvPlayer(Game game)
        {
            return game.FirstPlayerScore > game.SecondPlayerScore ? game.FirstPlayerName : game.SecondPlayerName;
        }

        private static bool IsDeuce(Game game)
        {
            return game.FirstPlayerScore == 3;
        }

        private static bool IsSameScore(Game game)
        {
            return game.FirstPlayerScore == game.SecondPlayerScore;
        }
    }
}