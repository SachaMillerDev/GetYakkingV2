using System.Data.SqlClient;

namespace GetYakkingV2;

public class DatabaseService
{
    private readonly string connectionString;

    public DatabaseService(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public async Task<Question> GetQuestionAsync(int questionId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

            string sql = "SELECT QuestionID, QuestionText, Category FROM Questions WHERE QuestionID = @QuestionID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@QuestionID", questionId);

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    return new Question
                    {
                        QuestionID = reader.GetString(0),
                        QuestionText = reader.GetString(1),
                        Category = reader.GetString(2)
                    };
                }
            }
        }

        return null; // Or handle as needed
    }
}

public class Question
{
    public string QuestionID { get; set; }
    public string QuestionText { get; set; }
    public string Category { get; set; }
}