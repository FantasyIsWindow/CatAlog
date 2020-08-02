using CatAlog_App.DbWorker.DbContexts.DbModels.GeneralModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.GeneralModels
{
    internal class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasMany(ad => ad.AdditionallyData_Company).WithOne(c => c.Company).HasForeignKey(k => k.CompanyId);
            builder.HasData
                (
                    new Company[]
                    {
                        new Company() { Id = 1, Name = "20th Century Fox" },
                        new Company() { Id = 2, Name = "Studio 3Hz" },
                        new Company() { Id = 3, Name = "OLM" }
                    }
                );
        }
    }
}
