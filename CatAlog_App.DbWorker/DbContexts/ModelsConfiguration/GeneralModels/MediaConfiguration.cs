using CatAlog_App.DbWorker.DbContexts.DbModels.GeneralModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.GeneralModels
{
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.HasMany(v => v.VideoData).WithOne(m => m.Media).HasForeignKey(k => k.MediaId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(a => a.AudioData).WithOne(m => m.Media).HasForeignKey(k => k.MediaId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(s => s.SubtitleData).WithOne(m => m.Media).HasForeignKey(k => k.MediaId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData
                (
                    new Media[]
                    {
                        new Media()
                        {
                            Id = 1,
                            Size = 13.5f,
                            MainRecordDataId = 1
                        },
                        new Media()
                        {
                            Id = 2,
                            Size = 8.25f,
                            MainRecordDataId = 2
                        },
                        new Media()
                        {
                            Id = 3,
                            Size = 4.3f,
                            MainRecordDataId = 3
                        },
                        new Media()
                        {
                            Id = 4,
                            Size = 7.8f,
                            MainRecordDataId = 4
                        },
                        new Media()
                        {
                            Id = 5,
                            Size = 15.8f,
                            MainRecordDataId = 5
                        },
                        new Media()
                        {
                            Id = 6,
                            Size = 24.9f,
                            MainRecordDataId = 6
                        },
                    }
                );
        }
    }
}
