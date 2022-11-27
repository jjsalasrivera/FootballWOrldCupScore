namespace libFootballWorldCupScore
{
    /// <summary>
    /// You can store your data in memory or in a database, files etc
    /// </summary>
    public interface IOperations
    {
        void StartGame( string HomeTeam, string AwayTeam );
        
        void FinishGame( string HomeTeam, string AwayTeam  );
        
        void UpdateScore( string HomeTeam, string AwayTeam, ushort HomeScore, ushort AwayScore);

        string GetSummary();
    }
}