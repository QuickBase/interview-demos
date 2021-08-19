using Microsoft.EntityFrameworkCore;
using QuickBaseDemoExercise.DataBase.Models;
using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.Extensions.Configuration;


namespace QuickBaseDemoExercise.DataBase
{
    public partial class citystatecountryContext : DbContext
    {

        public citystatecountryContext()
        {
        }

        public citystatecountryContext(DbContextOptions<citystatecountryContext> options)
            : base(options)
        {

        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data source=citystatecountry.db");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityId)
                    .HasColumnType("int")
                    .ValueGeneratedNever();

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasColumnType("varchar(2000)");

                entity.Property(e => e.Population).HasColumnType("int");

                entity.Property(e => e.StateId).HasColumnType("int");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Country");

                entity.Property(e => e.CountryId).HasColumnType("int");

                entity.Property(e => e.CountryName).HasColumnType("varchar(2000)");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State");

                entity.Property(e => e.StateId)
                    .HasColumnType("int")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryId).HasColumnType("int");

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasColumnType("varchar(2000)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
