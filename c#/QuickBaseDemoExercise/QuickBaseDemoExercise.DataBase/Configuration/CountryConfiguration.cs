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
   public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country").HasKey( c => c.CountryId);

            builder.Property(e => e.CountryId).HasColumnType("int");

            builder.Property(e => e.CountryName).HasColumnType("varchar(2000)");
        }
    }
}
