using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Jamatu.Auth.Data.Context
{
    public class SqlLiteDbContext : DataContext
    {
        public string DbPath { get; }
        public SqlLiteDbContext(IConfiguration configuration) : base(configuration)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Authentication.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}", x => x.MigrationsHistoryTable("__TransferMigrationsHistory"));
        }
    }
}
