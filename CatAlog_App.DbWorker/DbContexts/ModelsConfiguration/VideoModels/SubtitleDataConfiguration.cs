using CatAlog_App.DbWorker.Models.VideoModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.VideoModels
{
    internal class SubtitleDataConfiguration : IEntityTypeConfiguration<SubtitleData>
    {
        public void Configure(EntityTypeBuilder<SubtitleData> builder)
        {
            builder.HasData
                (
                    new SubtitleData[]
                    {
                         new SubtitleData()
                         {
                             Id = 1,
                             Author = "Киномания",
                             Language = "Английский",
                             SubtitleFormat = "SRT",
                             Note = "ненормативная лексика",
                             MediaId = 1
                         },
                         new SubtitleData()
                         {
                             Id = 2,
                             Author = "Юрий Сербин",
                             Language = "Русский",
                             SubtitleFormat = "ASS",
                             Note = "ненормативная лексика",
                             MediaId = 1
                         },
                         new SubtitleData()
                         {
                             Id = 3,
                             Author = "Ziggy Team & Serick Sub",
                             Language = "Английский",
                             SubtitleFormat = "ASS",
                             Note = "ненормативная лексика",
                             MediaId = 3
                         },
                         new SubtitleData()
                         {
                             Id = 4,
                             Author = "Киномания",
                             Language = "Русский",
                             SubtitleFormat = "SRT",
                             Note = "ненормативная лексика",
                             MediaId = 4
                         },
                         new SubtitleData()
                         {
                             Id = 5,
                             Author = "Ziggy Team & Serick Sub",
                             Language = "Русский",
                             SubtitleFormat = "SRT",
                             Note = "ненормативная лексика",
                             MediaId = 4
                         }
                    }
                );
        }
    }
}
