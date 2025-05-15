using BookApp1.Classes;
using System;
using System.Data.SQLite;
using System.IO;
using Xunit;

public class SQLiteStorageTests : IDisposable
{
    private readonly string _testConnectionString = "Data Source=test_library.db;Version=3;";
    private readonly SQLiteStorage<User> _userStorage;

    public SQLiteStorageTests()
    {
        _userStorage = new SQLiteStorage<User>("Users", _testConnectionString);
        InitializeTestDatabase();
    }

    private void InitializeTestDatabase()
    {
        if (File.Exists("test_library.db"))
        {
            File.Delete("test_library.db");
        }

        SQLiteConnection.CreateFile("test_library.db");

        using (var connection = new SQLiteConnection(_testConnectionString))
        {
            connection.Open();
            string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL,
                    HashedPassword TEXT NOT NULL,
                    Role TEXT NOT NULL
                )";
            using (var command = new SQLiteCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Test database initialized with Users table.");
            }
        }
    }

    [Fact]
    public void Add_User_ShouldAddUserAndAssignId()
    {
     
        var user = new User
        {
            Username = "testuser",
            HashedPassword = "hashedpassword12345",
            Role = "user"
        };
        int initialCount = _userStorage.GetAll().Count;

        
        _userStorage.Add(user);

      
        Assert.True(user.Id > 0, "User ID should be assigned after adding.");
        var addedUser = _userStorage.GetAll().FirstOrDefault(u => u.Username == "testuser");
        Assert.NotNull(addedUser);
        Assert.Equal(user.Username, addedUser.Username);
        Assert.Equal(user.HashedPassword, addedUser.HashedPassword);
        Assert.Equal(user.Role, addedUser.Role);
        Assert.True(_userStorage.GetAll().Count == initialCount + 1, "User count should increase by 1.");
    }

    [Fact]
    public void Add_NullUser_ShouldThrowException()
    {
       
        User user = null;

        var exception = Record.Exception(() => _userStorage.Add(user));
        Assert.NotNull(exception); 
        Assert.IsType<ArgumentNullException>(exception); 
    }

    public void Dispose()
    {
        
        // if (File.Exists("test_library.db"))
        // {
        //     File.Delete("test_library.db");
        //     Console.WriteLine("Test database deleted after test execution.");
        // }
        Console.WriteLine("Database file test_library.db is preserved in the current directory for inspection.");
    }
}