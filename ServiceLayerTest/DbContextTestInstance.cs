using DataAccessLayer.DbContext;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace ServiceLayerTest
{
    public abstract class DbContextTestInstance:IDisposable
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;

        protected readonly GameShopDbContext DbContext;

        protected DbContextTestInstance()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<GameShopDbContext>()
                    .UseSqlite(_connection)
                    .Options;
            DbContext = new GameShopDbContext(options);
            DbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
