using Domain.Database.Interfaces;
using Domain.Model.Database;
using Microsoft.EntityFrameworkCore;

namespace Backend.Web.Database.Implementation
{
    public class PostgresDbContext: DbContext, IDbContext
    {
        public DbSet<Place> Places { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Achievement> Achievements { get; set; }

        public PostgresDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Logo> Logos { get; set; }
    }
}