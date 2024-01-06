using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cityBikeApp.Domain.src.Entities;
using Microsoft.EntityFrameworkCore;



namespace cityBikeApp.WebApi.src.Database
{
    public class DatabaseContext: DbContext

    {
        private readonly IConfiguration _config;
        public DbSet<Station> Stations { get; set; }
        public DbSet<Journey> Journeys { get; set; }

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