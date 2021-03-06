using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBase.Demo.Domain.Models;
using QuickBase.Demo.Domain.Shared;

namespace QuickBase.Demo.EntityFrameworkCore.Configurations
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .Property(s => s.Id)
                .IsRequired()
                .HasColumnName("StateId");

            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(ValidationConstants.MaxNameLength)
                .HasColumnName("StateName");

            builder
                .HasOne(s => s.Country)
                .WithMany(c => c.States)
                .HasForeignKey(s => s.CountryId);

            builder
                .ToTable("State");
        }
    }

}
