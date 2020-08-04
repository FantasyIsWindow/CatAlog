using CatAlog_App.Db.DbContexts.DbModels.Relationship;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.Db.DbContexts.ModelsConfiguration.Relationship
{
    public class AdditionallyData_ProducerConfig : IEntityTypeConfiguration<AdditionallyData_Producer>
    {
        public void Configure(EntityTypeBuilder<AdditionallyData_Producer> builder)
        {
            builder.HasOne(a => a.AdditionallyData).WithMany(p => p.AdditionallyData_Producers).HasForeignKey(k => k.AdditionallyInfoId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Producer).WithMany(a => a.AdditionallyData_Producer).HasForeignKey(k => k.ProducerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData
                (
                    new AdditionallyData_Producer[]
                    {
                        new AdditionallyData_Producer() { Id = 1, AdditionallyInfoId = 1, ProducerId = 1 },
                        new AdditionallyData_Producer() { Id = 2, AdditionallyInfoId = 2, ProducerId = 2 },
                        new AdditionallyData_Producer() { Id = 3, AdditionallyInfoId = 3, ProducerId = 3 },
                        new AdditionallyData_Producer() { Id = 4, AdditionallyInfoId = 4, ProducerId = 4 },
                        new AdditionallyData_Producer() { Id = 5, AdditionallyInfoId = 5, ProducerId = 5 },
                        new AdditionallyData_Producer() { Id = 6, AdditionallyInfoId = 6, ProducerId = 6 },
                    }
                );
        }
    }
}
