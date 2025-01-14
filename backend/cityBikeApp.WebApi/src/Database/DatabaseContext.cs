using cityBikeApp.Domain.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace cityBikeApp.WebApi.src.Database
{
    public class DatabaseContext: DbContext

    {
        private readonly IConfiguration _config;
        public DbSet<Station> Station { get; set; }
        public DbSet<Journey> Journey { get; set; }

        public DatabaseContext (DbContextOptions options, IConfiguration config) : base (options)
        {
            _config = config;
        }

        static DatabaseContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Station>().ToTable("station");
            modelBuilder.Entity<Journey>().ToTable("journey");
            modelBuilder.Entity<Journey>()
            .HasOne(j => j.DepartureStation)
            .WithMany()
            .HasForeignKey(j => j.DepartureStationId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Journey>()
            .HasOne(j => j.ReturnStation)
            .WithMany()
            .HasForeignKey(j => j.ReturnStationId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}