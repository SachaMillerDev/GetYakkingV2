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
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        public DataTable GetQuestionData()
        {
            string query = "SELECT QuestionID, QuestionText, Category FROM YourTableName";
            return ExecuteQuery(query);
        }

        // Add more methods for Insert, Update, Delete as needed
    }
}
