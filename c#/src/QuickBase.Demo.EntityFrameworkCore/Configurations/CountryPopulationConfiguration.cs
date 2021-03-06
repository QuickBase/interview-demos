using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBase.Demo.Domain.Models;

namespace QuickBase.Demo.EntityFrameworkCore.Configurations
{
    public class CountryPopulationConfiguration : IEntityTypeConfiguration<CountryPopulation>
    {
        public void Configure(EntityTypeBuilder<CountryPopulation> builder)
        {
            builder.ToSqlQuery(
                @"SELECT Country.CountryName, SUM(city.Population) as 'Population' FROM Country
                INNER JOIN State state ON Country.CountryId = state.CountryId
                INNER JOIN City city ON state.StateId = city.StateId
                GROUP BY Country.CountryName
                ORDER BY Country.CountryName");

            builder.HasKey(cp => cp.Name);

            builder
                .Property(c => c.Name)
                .HasColumnName("CountryName");

            builder
                .Property(c => c.Population)
                .HasColumnName("Population");
        }
    }
}