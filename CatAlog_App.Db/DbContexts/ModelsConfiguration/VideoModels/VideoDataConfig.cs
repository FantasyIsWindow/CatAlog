using CatAlog_App.Db.DbContexts.DbModels.VideoModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.Db.DbContexts.ModelsConfiguration.VideoModels
{
    public class VideoDataConfig : IEntityTypeConfiguration<VideoData>
    {
        public void Configure(EntityTypeBuilder<VideoData> builder)
        {
            builder.HasOne(m => m.Media).WithMany(v => v.VideoData).HasForeignKey(k => k.MediaId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData
                (
                    new VideoData[]
                    {
                        new VideoData()
                        {
                            Id = 1,
                            Bitrate = 6352,
                            Relation = "2.37:1",
                            FrameRate = 24.000f,
                            ResolutionHeigth = 1980,
                            ResolutionWidth = 1254,
                            VideoFormat = "BDMV",
                            VideoQuality = "HDTVRip",
                            MediaId = 1
                        },
                        new VideoData()
                        {
                            Id = 2,
                            Bitrate = 44582,
                            Relation = "16:9",
                            FrameRate = 23.976f,
                            ResolutionHeigth = 720,
                            ResolutionWidth = 640,
                            VideoFormat = "XVID",
                            VideoQuality = "WEBRip",
                            MediaId = 2
                        },
                        new VideoData()
                        {
                            Id = 3,
                            Bitrate = 65485,
                            Relation = "2.37:1",
                            FrameRate = 29.970f,
                            ResolutionHeigth = 520,
                            ResolutionWidth = 320,
                            VideoFormat = "XVID",
                            VideoQuality = "WEB-DL",
                            MediaId = 3
                        },
                        new VideoData()
                        {
                            Id = 4,
                            Bitrate = 4422,
                            Relation = "16:9",
                            FrameRate = 29.970f,
                            ResolutionHeigth = 1024,
                            ResolutionWidth = 987,
                            VideoFormat = "BDMV",
                            VideoQuality = "WEB-DLRip",
                            MediaId = 4
                        },
                        new VideoData()
                        {
                            Id = 5,
                            Bitrate = 1254,
                            Relation = "2.37:1",
                            FrameRate = 24.000f,
                            ResolutionHeigth = 720,
                            ResolutionWidth = 640,
                            VideoFormat = "MKV",
                            VideoQuality = "BDRip",
                            MediaId = 5
                        },
                        new VideoData()
                        {
                            Id = 6,
                            Bitrate = 4366,
                            Relation = "16:9",
                            FrameRate = 23.976f,
                            ResolutionHeigth = 524,
                            ResolutionWidth = 325,
                            VideoFormat = "MKV",
                            VideoQuality = "Blu-ray disc",
                            MediaId = 6
                        }
                    }
                );
        }
    }
}
