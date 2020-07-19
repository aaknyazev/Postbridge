using Microsoft.EntityFrameworkCore;
using PostBridge.Domain.Postmessage;

namespace PostBridge.Infrastructure.Contexts
{
    public class PostBridgeMsSqlServerContext : DbContext
    {
        private static readonly object ForLockObject = new object();

        public DbSet<Postmessage> Postmessage { get; set; }

        public PostBridgeMsSqlServerContext(DbContextOptions<PostBridgeMsSqlServerContext> options)
            : base(options)
        {
            // Database.EnsureCreated();

            lock (ForLockObject)
            {
                Database.Migrate();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettings.ConnectionMsSqlServerString);
        }
    }
}
