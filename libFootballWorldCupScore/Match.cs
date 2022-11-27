using System;

namespace libFootballWorldCupScore
{
    public class Match
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public ushort HomeScore { get; set; }
        public ushort AwayScore { get; set; }
    }
}