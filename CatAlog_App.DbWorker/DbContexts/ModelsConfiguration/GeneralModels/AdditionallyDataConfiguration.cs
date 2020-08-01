using CatAlog_App.DbWorker.Models.GeneralModels;
using CatAlog_App.DbWorker.Models.VideoModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.GeneralModels
{
    internal class AdditionallyDataConfiguration : IEntityTypeConfiguration<AdditionallyData>
    {
        public void Configure(EntityTypeBuilder<AdditionallyData> builder)
        {
            builder.HasMany(actors => actors.AdditionallyData_Actors).WithOne(a => a.AdditionallyData).HasForeignKey(k => k.AdditionallyInfoId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(companies => companies.AdditionallyData_Companies).WithOne(a => a.AdditionallyData).HasForeignKey(k => k.AdditionallyInfoId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(countries => countries.AdditionallyData_Countries).WithOne(a => a.AdditionallyData).HasForeignKey(k => k.AdditionallyInfoId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(genres => genres.AdditionallyData_Genres).WithOne(a => a.AdditionallyData).HasForeignKey(k => k.AdditionallyInfoId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(producers => producers.AdditionallyData_Producers).WithOne(a => a.AdditionallyData).HasForeignKey(k => k.AdditionallyInfoId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(screenwriters => screenwriters.AdditionallyData_Screenwriters).WithOne(a => a.AdditionallyData).HasForeignKey(k => k.AdditionallyInfoId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.SerialData).WithOne(a => a.AdditionallyData).HasForeignKey<SerialData>(k => k.AdditionallyDataId).OnDelete(DeleteBehavior.Cascade);
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
