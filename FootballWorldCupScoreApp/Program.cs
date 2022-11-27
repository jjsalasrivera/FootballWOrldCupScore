using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using libFootballWorldCupScore;
using log4net;
using log4net.Config;

namespace FootballWorldCupScoreApp
{
    class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            InitializeLog4net();
           
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
            
            _log.Info(operations.GetSummary());
            
        }
        
        private static void InitializeLog4net() {
            Assembly EntryAssembly = Assembly.GetEntryAssembly();
            string AppPath = string.Format("{0}{1}", Path.GetDirectoryName(EntryAssembly.Location), Path.DirectorySeparatorChar);
            Directory.SetCurrentDirectory(AppPath);
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath));
            _log.Info(AppPath + ", " + Environment.CurrentDirectory);
            _log.Info("Initializating application");
        }
    }
}