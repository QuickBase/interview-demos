using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBase.Demo.Domain.Models;
using QuickBase.Demo.Domain.Shared;

namespace QuickBase.Demo.EntityFrameworkCore.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Id)
                .IsRequired()
                .HasColumnName("CityId");

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(ValidationConstants.MaxNameLength)
                .HasColumnName("CityName");

            builder
                .Property(c => c.Population)
                .IsRequired()
                .HasColumnName("Population");

            builder
                .HasOne(c => c.State)
                .WithMany(s => s.Cities)
                .HasForeignKey(c => c.StateId);

            builder
                .ToTable("City");
        }
    }
}
