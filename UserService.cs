using Dapper;
using Npgsql;

public class UserService
{
    private readonly NpgsqlConnection _connection;

    public UserService(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public void CreateUser(string name)
    {
        _connection.Execute("INSERT INTO users (name) VALUES (@name)", new { name });
    }

    public bool UserExists(string name)
    {
        return _connection.ExecuteScalar<bool>(
            "SELECT EXISTS (SELECT 1 FROM users WHERE name = @name)", new { name });
    }
}