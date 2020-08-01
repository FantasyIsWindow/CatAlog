using CatAlog_App.DbWorker.Models.Relationship;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.Relationship
{
    internal class AdditionallyData_CompanyConfiguration : IEntityTypeConfiguration<AdditionallyData_Company>
    {
        public void Configure(EntityTypeBuilder<AdditionallyData_Company> builder)
        {
            builder.HasData
                (
                    new AdditionallyData_Company[]
                    {
                        new AdditionallyData_Company() { AdditionallyInfoId = 1, CompanyId = 1},
                        new AdditionallyData_Company() { AdditionallyInfoId = 2, CompanyId = 2},
                        new AdditionallyData_Company() { AdditionallyInfoId = 3, CompanyId = 1},
                        new AdditionallyData_Company() { AdditionallyInfoId = 4, CompanyId = 3},
                        new AdditionallyData_Company() { AdditionallyInfoId = 5, CompanyId = 2},
                        new AdditionallyData_Company() { AdditionallyInfoId = 6, CompanyId = 3},
                    }
                );
        }
    }
}
