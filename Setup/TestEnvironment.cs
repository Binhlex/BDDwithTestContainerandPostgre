using Testcontainers.PostgreSql;
using NUnit.Framework;
using System.Threading.Tasks;

[SetUpFixture]
public class TestEnvironment
{
    public static PostgreSqlContainer PostgresContainer;

    [OneTimeSetUp]
    public static async Task Setup()
    {
        PostgresContainer = new PostgreSqlBuilder()
            .WithDatabase("testdb")
            .WithUsername("postgres")
            .WithPassword("postgres")
            .WithImage("postgres:15")
            .Build();

        await PostgresContainer.StartAsync();

        using var conn = new Npgsql.NpgsqlConnection(PostgresContainer.GetConnectionString());
        conn.Open();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = @"CREATE TABLE IF NOT EXISTS users (
                             id SERIAL PRIMARY KEY,
                             name TEXT NOT NULL
                           );";
        cmd.ExecuteNonQuery();
    }

    [OneTimeTearDown]
    public static async Task TearDown()
    {
        await PostgresContainer.DisposeAsync();
    }
}