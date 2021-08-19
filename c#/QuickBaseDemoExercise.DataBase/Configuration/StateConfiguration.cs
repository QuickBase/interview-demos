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
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("State").HasKey(s => s.StateId);

            builder.Property(e => e.StateId)
                .HasColumnType("int");

            builder.Property(e => e.CountryId).HasColumnType("int");

            builder.Property(e => e.StateName)
                .IsRequired()
                .HasColumnType("varchar(2000)");

            builder.HasOne(d => d.Country)
                .WithMany(p => p.States)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
