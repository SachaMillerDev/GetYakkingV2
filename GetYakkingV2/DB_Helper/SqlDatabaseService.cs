using Azure.Core.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GetYakkingV2.Data
{
    public class SqlDatabaseService
    {
        private readonly string _connectionString;

        public SqlDatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable ExecuteQuery(string query)
        {
            // Setup a listener to monitor logged events.
            using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
            using SqlConnection connection = new(_connectionString);
            using SqlCommand command = new(query, connection);
            using SqlDataAdapter adapter = new(command);
            
            DataTable dataTable = new();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetQuestionData()
        {
            string query = "SELECT * from [dbo].[Questions]";
            return ExecuteQuery(query);
        }

        // Add more methods for Insert, Update, Delete as needed
    }
}
