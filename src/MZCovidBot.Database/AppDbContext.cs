using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MZCovidBot.Database.Entities;

namespace MZCovidBot.Database
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;
        
        public DbSet<CovidData> CovidData { get; set; }

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CovidData>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
            => SaveChangesAsync().GetAwaiter().GetResult();
    }
}