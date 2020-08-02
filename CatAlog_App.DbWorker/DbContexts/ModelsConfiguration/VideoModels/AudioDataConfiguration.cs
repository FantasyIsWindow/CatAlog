using CatAlog_App.DbWorker.DbContexts.DbModels.VideoModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.VideoModels
{
    internal class AudioDataConfiguration : IEntityTypeConfiguration<AudioData>
    {
        public void Configure(EntityTypeBuilder<AudioData> builder)
        {
            builder.HasData
                (
                    new AudioData[]
                    {
                        new AudioData()
                        {
                            Id = 1,
                            AudioFormat = "DTS-HD Master Audio",
                            Bitrate = 4833,
                            Channel = "5.1",
                            Frequency = 48f,
                            Language = "Французский",
                            Author = "Киномания",
                            Note = "Одноголосый закадровый (ненормативная лексика)",
                            MediaId = 1
                        },
                        new AudioData()
                        {
                            Id = 2,
                            AudioFormat = "DTS-HD Master Audio",
                            Bitrate = 3382,
                            Channel = "2.0",
                            Frequency = 41.1f,
                            Language = "Японский",
                            Author = "Сергей Визгунов",
                            Note = "(ненормативная лексика)",
                            MediaId = 2
                        },
                        new AudioData()
                        {
                            Id = 3,
                            AudioFormat = "DTS",
                            Bitrate = 1425,
                            Channel = "5.1",
                            Frequency = 44.5f,
                            Language = "Немецкий",
                            Author = "РТР/РЕН ТВ",
                            Note = "Профессиональный (двухголосый закадровый)",
                            MediaId = 3
                        },
                        new AudioData()
                        {
                            Id = 4,
                            AudioFormat = "DTS",
                            Bitrate = 3325,
                            Channel = "7.1",
                            Frequency = 44.1f,
                            Language = "Русский",
                            Author = "Держиморда",
                            Note = "Авторский (одноголосый закадровый)",
                            MediaId = 4
                        },
                        new AudioData()
                        {
                            Id = 5,
                            AudioFormat = "AC3",
                            Bitrate = 7477,
                            Channel = "Моно",
                            Frequency = 48f,
                            Language = "Английский",
                            Author = "ОРТ",
                            Note = "Одноголосый закадровый (ненормативная лексика)",
                            MediaId = 5
                        },
                        new AudioData()
                        {
                            Id = 6,
                            AudioFormat = "Dolby Digital Audio",
                            Bitrate = 4544,
                            Channel = "6.1",
                            Frequency = 44.5f,
                            Language = "Русский",
                            Author = "Позитив",
                            Note = "Профессиональный (многоголосый закадровый)",
                            MediaId = 6
                        },
                    }
               );
        }
    }
}
