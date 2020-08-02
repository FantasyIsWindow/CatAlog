using CatAlog_App.DbWorker.DbContexts.DbModels.Relationship;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.Relationship
{
    internal class AdditionallyData_ProducerConfiguration : IEntityTypeConfiguration<AdditionallyData_Producer>
    {
        public void Configure(EntityTypeBuilder<AdditionallyData_Producer> builder)
        {
            builder.HasData
                (
                    new AdditionallyData_Producer[]
                    {
                        new AdditionallyData_Producer() { AdditionallyInfoId = 1, ProducerId = 1 },
                        new AdditionallyData_Producer() { AdditionallyInfoId = 2, ProducerId = 2 },
                        new AdditionallyData_Producer() { AdditionallyInfoId = 3, ProducerId = 3 },
                        new AdditionallyData_Producer() { AdditionallyInfoId = 4, ProducerId = 4 },
                        new AdditionallyData_Producer() { AdditionallyInfoId = 5, ProducerId = 5 },
                        new AdditionallyData_Producer() { AdditionallyInfoId = 6, ProducerId = 6 },
                    }
                );
        }
    }
}
