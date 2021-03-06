using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBase.Demo.Domain.Models;
using QuickBase.Demo.Domain.Shared;

namespace QuickBase.Demo.EntityFrameworkCore.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                 .HasKey(c => c.Id);

            builder
                .Property(c => c.Id)
                .IsRequired()
                .HasColumnName("CountryId");

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(ValidationConstants.MaxNameLength)
                .HasColumnName("CountryName");

            builder
                .ToTable("Country");
        }
    }

}
