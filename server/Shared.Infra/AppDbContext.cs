using Albums.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Shared.Infra
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(x => Debug.WriteLine(x));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
