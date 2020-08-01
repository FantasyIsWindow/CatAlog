using CatAlog_App.DbWorker.Models.Relationship;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.Relationship
{
    internal class AdditionallyData_CountryConfiguration : IEntityTypeConfiguration<AdditionallyData_Country>
    {
        public void Configure(EntityTypeBuilder<AdditionallyData_Country> builder)
        {
            builder.HasData
                (
                    new AdditionallyData_Country[]
                    {
                        new AdditionallyData_Country() { AdditionallyInfoId = 1, CountryId = 1},
                        new AdditionallyData_Country() { AdditionallyInfoId = 2, CountryId = 2},
                        new AdditionallyData_Country() { AdditionallyInfoId = 3, CountryId = 3},
                        new AdditionallyData_Country() { AdditionallyInfoId = 4, CountryId = 1},
                        new AdditionallyData_Country() { AdditionallyInfoId = 5, CountryId = 5},
                        new AdditionallyData_Country() { AdditionallyInfoId = 6, CountryId = 4}
                    }
                );
        }
    }
}
