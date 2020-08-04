using CatAlog_App.Db.DbContexts.DbModels.Relationship;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.Db.DbContexts.ModelsConfiguration.Relationship
{
    public class AdditionallyData_CountryConfig : IEntityTypeConfiguration<AdditionallyData_Country>
    {
        public void Configure(EntityTypeBuilder<AdditionallyData_Country> builder)
        {
            builder.HasOne(a => a.AdditionallyData).WithMany(c => c.AdditionallyData_Countries).HasForeignKey(k => k.AdditionallyDataId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Country).WithMany(a => a.AdditionallyData_Country).HasForeignKey(k => k.CountryId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData
                (
                    new AdditionallyData_Country[]
                    {
                        new AdditionallyData_Country() { Id = 1, AdditionallyDataId = 1, CountryId = 1},
                        new AdditionallyData_Country() { Id = 2, AdditionallyDataId = 2, CountryId = 2},
                        new AdditionallyData_Country() { Id = 3, AdditionallyDataId = 3, CountryId = 3},
                        new AdditionallyData_Country() { Id = 4, AdditionallyDataId = 4, CountryId = 1},
                        new AdditionallyData_Country() { Id = 5, AdditionallyDataId = 5, CountryId = 5},
                        new AdditionallyData_Country() { Id = 6, AdditionallyDataId = 6, CountryId = 4}
                    }
                );
        }
    }
}
