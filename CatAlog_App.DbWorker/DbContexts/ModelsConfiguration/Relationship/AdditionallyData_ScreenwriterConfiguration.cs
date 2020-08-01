using CatAlog_App.DbWorker.Models.Relationship;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.Relationship
{
    internal class AdditionallyData_ScreenwriterConfiguration : IEntityTypeConfiguration<AdditionallyData_Screenwriter>
    {
        public void Configure(EntityTypeBuilder<AdditionallyData_Screenwriter> builder)
        {
            builder.HasData
                (
                    new AdditionallyData_Screenwriter[]
                    {
                        new  AdditionallyData_Screenwriter() { AdditionallyInfoId = 4, ScreenwriterId = 1 },
                        new  AdditionallyData_Screenwriter() { AdditionallyInfoId = 6, ScreenwriterId = 1 }
                    }
                );
        }
    }
}
