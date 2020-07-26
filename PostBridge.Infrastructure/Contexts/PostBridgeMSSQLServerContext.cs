using Microsoft.EntityFrameworkCore;
using PostBridge.Domain.Postmessage;
using PostBridge.Infrastructure.Configurations;

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
            optionsBuilder.UseSqlServer(AppSettings.ConnectionMsSqlServerString, b => b.MigrationsAssembly("PostBridge.Publisher"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostmessageConfiguration());
        }
    }
}
