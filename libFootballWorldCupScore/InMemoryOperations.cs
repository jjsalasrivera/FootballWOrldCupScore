using System.Collections.Generic;
using System.Reflection;
using log4net;
using System.Linq;

namespace libFootballWorldCupScore
{
    public class InMemoryOperations : IOperations
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private Dictionary<string, Match> _matches = new();

        public void StartGame(string HomeTeam, string AwayTeam)
        {
            var match = new Match(HomeTeam, AwayTeam);
            
            if(_matches.ContainsKey(match.getId))
            {
                _log.Error($"Match {match.getId} already exists");
            }
            else if( _matches.Values.Any(m => m.ContainsTeam(HomeTeam) || m.ContainsTeam(AwayTeam)))
            {
                _log.Error($"Team {HomeTeam} or {AwayTeam} already has a match");
            }
            else
            {
                _matches.Add(match.getId, match);
            }
        }

        public void FinishGame(string HomeTeam, string AwayTeam)
        {
            _matches.Remove(Match.getIdFromTeams(HomeTeam, AwayTeam));
        }

        public void UpdateScore(string HomeTeam, string AwayTeam, ushort HomeScore, ushort AwayScore)
        {
            if (_matches.TryGetValue(Match.getIdFromTeams(HomeTeam, AwayTeam), out var match))
            {
                match.Update(HomeScore, AwayScore);
            }
            else
                _log.Error($"Match {HomeTeam} - {AwayTeam} not found");
        }

        public string GetSummary()
        {
            var ordered = _matches.Values.OrderByDescending(v => v.getTotalScore())
                .ThenByDescending(v => v.getLastUpdate());
            
            return string.Join("\n", ordered.Select(v => v.ToString()));
        }
    }
}