using libFootballWorldCupScore;
using NUnit.Framework;

namespace FootballWorldCupScoreTest
{
    public class FootballWorldCupScoreTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RepeatedMatch()
        {
            IOperations operations = new InMemoryOperations();
            
            operations.StartGame("France", "Spain");
            operations.StartGame("Germany", "Belgium");
            operations.StartGame("France", "Spain");
            Assert.AreEqual("Germany 0 - Belgium 0\nFrance 0 - Spain 0", operations.GetSummary());
        }

        [Test]
        public void DeletedMatch()
        {
            IOperations operations = new InMemoryOperations();
            
            operations.StartGame("France", "Spain");
            operations.StartGame("Germany", "Belgium");
            operations.StartGame("Japan", "Peru");
            
            operations.FinishGame("France", "Spain");
            
            Assert.AreEqual("Japan 0 - Peru 0\nGermany 0 - Belgium 0", operations.GetSummary());
        }

        [Test]
        public void UpdateMatch()
        {            
            IOperations operations = new InMemoryOperations();
            
            operations.StartGame("France", "Spain");
            operations.StartGame("Germany", "Belgium");
            operations.StartGame("Argentina", "EEUU");
            operations.StartGame("Japan", "Croatia");

            operations.UpdateScore("Germany", "Belgium",1,0);
            operations.UpdateScore("Argentina", "EEUU",1,1);
            operations.UpdateScore("Japan", "Croatia",2,2);
            operations.UpdateScore("France", "Spain", 1, 0);
            operations.UpdateScore("Germany", "Belgium",2,0);
            
            Assert.AreEqual("Japan 2 - Croatia 2\nGermany 2 - Belgium 0\nArgentina 1 - EEUU 1\nFrance 1 - Spain 0", operations.GetSummary());
        }
    }
}