using CatAlog_App.Db.DbContexts.DbModels.Relationship;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.Db.DbContexts.ModelsConfiguration.Relationship
{
    public class AdditionallyData_CompanyConfig : IEntityTypeConfiguration<AdditionallyData_Company>
    {
        public void Configure(EntityTypeBuilder<AdditionallyData_Company> builder)
        {
            builder.HasOne(a => a.AdditionallyData).WithMany(c => c.AdditionallyData_Companies).HasForeignKey(k => k.AdditionallyDataId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Company).WithMany(a => a.AdditionallyData_Company).HasForeignKey(k => k.CompanyId).OnDelete(DeleteBehavior.Cascade);
            builder.HasKey(k => new { k.AdditionallyDataId, k.CompanyId });

            builder.HasData
                (
                    new AdditionallyData_Company[]
                    {
                        new AdditionallyData_Company() { Id = 1, AdditionallyDataId = 1, CompanyId = 1},
                        new AdditionallyData_Company() { Id = 2, AdditionallyDataId = 2, CompanyId = 2},
                        new AdditionallyData_Company() { Id = 3, AdditionallyDataId = 3, CompanyId = 1},
                        new AdditionallyData_Company() { Id = 4, AdditionallyDataId = 4, CompanyId = 3},
                        new AdditionallyData_Company() { Id = 5, AdditionallyDataId = 5, CompanyId = 2},
                        new AdditionallyData_Company() { Id = 6, AdditionallyDataId = 6, CompanyId = 3},
                    }
                );
        }
    }
}
