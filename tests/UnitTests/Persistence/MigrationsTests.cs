using System;
using System.Data;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using tests.UnitTests.Persistence.Context;
using Xunit;

public class MigrationTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly DbContextOptions<PipocaAgilPodcastDbContextTest> _options;

    public MigrationTests()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();

        _options = new DbContextOptionsBuilder<PipocaAgilPodcastDbContextTest>()
            .UseSqlite(_connection)
            .Options;

        using (var context = new PipocaAgilPodcastDbContextTest(_options))
        {
            context.Database.EnsureCreated();
        }
    }

    private bool TableExists(string tableName, PipocaAgilPodcastDbContextTest context)
    {
        using (var command = context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}'";
            context.Database.OpenConnection();
            return command.ExecuteScalar() != null;
        }
    }

    private void TestTableExists(string tableName)
    {
        using var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<PipocaAgilPodcastDbContextTest>(options =>
                {
                    options.UseSqlite(_connection);
                });
            })
            .Build();

        using var scope = host.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        var dbContext = serviceProvider.GetRequiredService<PipocaAgilPodcastDbContextTest>();

        dbContext.Database.Migrate();

        bool tableExists = TableExists(tableName, dbContext);

        Assert.True(tableExists);
    }

    [Fact]
    public void TestUsersTableExists()
    {
        TestTableExists("Users");
    }

    [Fact]
    public void TestActivityHistoryTableExists()
    {
        TestTableExists("ActivityHistory");
    }
    
    [Fact]
    public void TestStatisticsTableExists()
    {
        TestTableExists("Statistics");
    }

    [Fact]
    public void TestInterestsTableExists()
    {
        TestTableExists("Interests");
    }

    [Fact]
    public void TestUsersActivitiesLogsTableExists()
    {
        TestTableExists("UsersActivitiesLogs");
    }
    public void Dispose()
    {
        _connection.Close();
    }
}






