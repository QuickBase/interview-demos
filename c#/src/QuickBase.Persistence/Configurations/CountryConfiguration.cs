using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBase.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBase.Persistence.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");
            builder.HasKey(x => x.CountryId);

            //builder.Property(x => x.CountryId)
            //    .IsRequired(false);

            builder.Property(x => x.CountryName)
                .HasMaxLength(2000)
                .IsRequired(false);
        }
    }
}
