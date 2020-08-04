using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.Db.DbContexts.ModelsConfiguration.GeneralModels
{
    public class AdditionallyDataConfig : IEntityTypeConfiguration<AdditionallyData>
    {
        public void Configure(EntityTypeBuilder<AdditionallyData> builder)
        {
            builder.HasOne(m => m.MainRecordData).WithOne(a => a.AdditionallyData).HasForeignKey<AdditionallyData>(k => k.MainRecordDataId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData
                (
                 new AdditionallyData[]
                    {
                        new AdditionallyData()
                        {
                            Id = 1,
                            MainRecordDataId = 1
                        },
                        new AdditionallyData()
                        {
                             Id = 2,
                             MainRecordDataId = 2
                        },
                        new AdditionallyData()
                        {
                             Id = 3,
                             MainRecordDataId = 3
                        },
                        new AdditionallyData()
                        {
                             Id = 4,
                             MainRecordDataId = 4,
                             Note = "Посмотреть как будет возможность."
                        },
                        new AdditionallyData()
                        {
                             Id = 5,
                             MainRecordDataId = 5
                        },
                        new AdditionallyData()
                        {
                             Id = 6,
                             MainRecordDataId = 6,
                             ReleaseAuthor = "Free Releasers Team \"SORA\""
                        },
                    }
               );
        }
    }
}
