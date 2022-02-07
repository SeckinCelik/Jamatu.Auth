using Jamatu.Auth.Core.Entity;
using Jamatu.Auth.Core.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Jamatu.Auth.Data.Context
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TokenEntity> Tokens { get; set; }
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("SqlDatabase"));
        }
    }
}
