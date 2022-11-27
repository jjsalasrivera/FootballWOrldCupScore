using System;

namespace libFootballWorldCupScore
{
    public class Match
    { 
        private string _homeTeam { get; set; }
        private string _awayTeam { get; set; }
        private ushort _homeScore;
        private ushort _awayScore;
        private DateTime _lastUpdate = DateTime.UtcNow;
        
        public Match(string homeTeam, string awayTeam)
        {
            _homeTeam = homeTeam;
            _awayTeam = awayTeam;
        }
        
        public bool ContainsTeam(string team) => _homeTeam == team || _awayTeam == team;

        public void Update(ushort HomeScore, ushort AwayScore)
        {
            _homeScore = HomeScore;
            _awayScore = AwayScore;
            _lastUpdate = DateTime.UtcNow;
        }

        public DateTime getLastUpdate() => _lastUpdate;
        public string getId => $"{_homeTeam.ToLower()} - {_awayTeam.ToLower()}".Trim();
        
        public static string getIdFromTeams(string HomeTeam, string AwayTeam) => $"{HomeTeam.ToLower()} - {AwayTeam.ToLower()}".Trim();

        public int getTotalScore() => _homeScore + _awayScore;
        
        public override string ToString() => $"{_homeTeam} {_homeScore} - {_awayTeam} {_awayScore}";
    }
}