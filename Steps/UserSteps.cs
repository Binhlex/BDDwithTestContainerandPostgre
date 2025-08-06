using Reqnroll;
using NUnit.Framework;
using Npgsql;

[Binding]
public class UserSteps
{
    private UserService _userService;

    [BeforeScenario]
    public void Setup()
    {
        var conn = new NpgsqlConnection(TestEnvironment.PostgresContainer.GetConnectionString());
        conn.Open();
        _userService = new UserService(conn);
    }

    [Given(@"a user named ""(.*)"" is created")]
    public void GivenAUserNamedIsCreated(string name)
    {
        _userService.CreateUser(name);
    }

    [Then(@"the user ""(.*)"" should exist in the database")]
    public void ThenTheUserShouldExist(string name)
    {
        Assert.That(_userService.UserExists(name), Is.True);
    }
}