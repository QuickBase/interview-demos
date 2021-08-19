using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBaseDemoExercise.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBaseDemoExercise.DataBase.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City").HasKey(e => e.CityId);

            builder.Property(e => e.CityId)
                .HasColumnType("int");

            builder.Property(e => e.CityName)
                .IsRequired()
                .HasColumnType("varchar(2000)");

            builder.Property(e => e.Population).HasColumnType("int");

            builder.Property(e => e.StateId).HasColumnType("int");

            builder.HasOne(d => d.State)
                .WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
