using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace OpenB.BPM.Core
{

    internal class ProcessDataService : IProcessDataService
    {
        SQLiteConnection connection;
        readonly XmlConfigurationManager configurationManager;

        public ProcessDataService(SQLiteConnection connection, XmlConfigurationManager configurationManager)
        {

            if (configurationManager == null)
                throw new ArgumentNullException(nameof(configurationManager));
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

            this.connection = connection;
            this.configurationManager = configurationManager;
        }

        public static ProcessDataService GetInstance()
        {
            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "openb.bpmengine.sqlite");
            bool createTables = false;

            // Create database if not existent.
            if (!File.Exists(fullPath))
            {
                SQLiteConnection.CreateFile(fullPath);
                createTables = true;

            }

            // Create connection if non existant.
            SQLiteConnection connection = new SQLiteConnection($"Data Source={fullPath}");

            if (createTables)
            {
                connection.Open();
                string commandText = "CREATE TABLE RunningProcesses (Key varchar(36) not null, Started DATETIME not null)";
                var command = new SQLiteCommand(commandText, connection);

                command.ExecuteNonQuery();
                connection.Close();
            }

            return new ProcessDataService(connection, XmlConfigurationManager.GetInstance());

        }

        public ProcessDefinition GetDefinition(string processDefinitionKey)
        {
            return this.configurationManager.GetConfigurations<ProcessDefinition>().Where(pd => pd.Key == processDefinitionKey).Single();
        }

        public IList<Process> GetRunningProcesses()
        {
            connection.Open();
            string commandText = "SELECT * FROM RunningProcesses";
            var command = new SQLiteCommand(commandText, connection);

            SQLiteDataReader dataReader = command.ExecuteReader();

            var result = new List<Process>();
            while (dataReader.Read())
            {
                NameValueCollection singleResult = dataReader.GetValues();

            }
            connection.Close();

            return result;
        }
    }
}