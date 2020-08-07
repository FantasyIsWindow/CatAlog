using CatAlog_App.Db.DbContexts.DbModels.Relationship;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.Db.DbContexts.ModelsConfiguration.Relationship
{
    public class AdditionallyData_ScreenwriterConfig : IEntityTypeConfiguration<AdditionallyData_Screenwriter>
    {
        public void Configure(EntityTypeBuilder<AdditionallyData_Screenwriter> builder)
        {
            builder.HasOne(a => a.AdditionallyData).WithMany(s => s.AdditionallyData_Screenwriters).HasForeignKey(k => k.AdditionallyDataId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.Screenwriter).WithMany(a => a.AdditionallyData_Screenwriter).HasForeignKey(k => k.ScreenwriterId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData
                (
                    new AdditionallyData_Screenwriter[]
                    {
                        new  AdditionallyData_Screenwriter() { Id = 1, AdditionallyDataId = 4, ScreenwriterId = 1 },
                        new  AdditionallyData_Screenwriter() { Id = 2, AdditionallyDataId = 6, ScreenwriterId = 1 }
                    }
                );
        }
    }
}
