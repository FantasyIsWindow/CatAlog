using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.Db.DbContexts.ModelsConfiguration.GeneralModels
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasIndex(n => n.Name).IsUnique();
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
