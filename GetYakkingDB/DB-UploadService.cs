using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class DatabaseUploader
{
    private readonly string connectionString;

    public DatabaseUploader(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public async Task UploadQuestionsAsync(string filePath)
    {
        var questions = JsonSerializer.Deserialize<List<Question>>(File.ReadAllText(filePath));

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

            foreach (var question in questions)
            {
                string sql = "INSERT INTO Questions (QuestionID, QuestionText, Category) VALUES (@QuestionID, @QuestionText, @Category)";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@QuestionID", question.QuestionID);
                command.Parameters.AddWithValue("@QuestionText", question.QuestionText);
                command.Parameters.AddWithValue("@Category", question.Category);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}

public class Question
{
    public string QuestionID { get; set; }
    public string QuestionText { get; set; }
    public string Category { get; set; }
}

// Usage
public static async Task Main(string[] args)
{
    string connectionString = "Server=tcp:get-yakking.database.windows.net,1433;Initial Catalog=get-yakking;Persist Security Info=False;User ID=CloudSAbb1d7222;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;\r\n";
    string jsonFilePath = "C:\Users\SachaMiller\source\repos\GetYakkingV2\GetYakkingV2\Resources\Questions\ClassicQuestions.json";

    DatabaseUploader uploader = new DatabaseUploader(connectionString);
    await uploader.UploadQuestionsAsync(jsonFilePath);
}
