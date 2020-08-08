using CatAlog_App.Db.DbContexts.DbModels.VideoModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.Db.DbContexts.ModelsConfiguration.VideoModels
{
    public class EpisodeDataConfig : IEntityTypeConfiguration<EpisodeData>
    {
        public void Configure(EntityTypeBuilder<EpisodeData> builder)
        {
            builder.HasOne(s => s.SerialData).WithMany(e => e.Episodes).HasForeignKey(k => k.SerialDataId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData
                (
                    new EpisodeData[]
                    {
                        new EpisodeData() { Id = 1,  SerialDataId = 1, Number = 1,  Name = "Сражение красавиц за честь и престиж!" },
                        new EpisodeData() { Id = 2,  SerialDataId = 1, Number = 2,  Name = "Советы для братьев-бойцов!" },
                        new EpisodeData() { Id = 3,  SerialDataId = 1, Number = 3,  Name = "Возвращение домой!" },
                        new EpisodeData() { Id = 4,  SerialDataId = 1, Number = 4,  Name = "Дрейден против Ирис. Прошлое, настоящее и будущее!" },
                        new EpisodeData() { Id = 5,  SerialDataId = 1, Number = 5,  Name = "Команда Иви и спасательный отряд Покемонов!" },
                        new EpisodeData() { Id = 6,  SerialDataId = 1, Number = 6,  Name = "Лига Юновы начинается!" },
                        new EpisodeData() { Id = 7,  SerialDataId = 1, Number = 7,  Name = "Задача: одолеть соперника!" },
                        new EpisodeData() { Id = 8,  SerialDataId = 1, Number = 8,  Name = "Потерянные на лиге!" },
                        new EpisodeData() { Id = 9,  SerialDataId = 1, Number = 9,  Name = "Сильная стратегия – это главное!" },
                        new EpisodeData() { Id = 10, SerialDataId = 1, Number = 10, Name = "Секретное оружие Камерона!" },
                        new EpisodeData() { Id = 11, SerialDataId = 1, Number = 11, Name = "Эволюция Лиги Юновы!" },
                        new EpisodeData() { Id = 12, SerialDataId = 1, Number = 12, Name = "Новые места, знакомые лица!" },
                        new EpisodeData() { Id = 13, SerialDataId = 1, Number = 13, Name = "Меня зовут Н!" },
                        new EpisodeData() { Id = 14, SerialDataId = 1, Number = 14, Name = "В городе новый гим - лидер!" },
                        new EpisodeData() { Id = 15, SerialDataId = 1, Number = 15, Name = "Заговор команды Плазмы!" },
                        new EpisodeData() { Id = 16, SerialDataId = 1, Number = 16, Name = "Огонь ранчо Флокеси!" },
                        new EpisodeData() { Id = 17, SerialDataId = 1, Number = 17, Name = "Спасая Бревиари!" },
                        new EpisodeData() { Id = 18, SerialDataId = 1, Number = 18, Name = "Прибрежный патруль Покемонов!" },
                        new EpisodeData() { Id = 19, SerialDataId = 1, Number = 19, Name = "Огни жаркой встречи!" },
                        new EpisodeData() { Id = 20, SerialDataId = 1, Number = 20, Name = "Команда Плазма манипулирует покемонами!" },
                        new EpisodeData() { Id = 21, SerialDataId = 1, Number = 21, Name = "Секреты из тумана!" },
                        new EpisodeData() { Id = 22, SerialDataId = 1, Number = 22, Name = "Мяут, Колрес и соперничество команд!" },
                        new EpisodeData() { Id = 23, SerialDataId = 1, Number = 23, Name = "Эш и Н: столкновение идеалов!" },
                        new EpisodeData() { Id = 24, SerialDataId = 1, Number = 24, Name = "Команда Плазма и церемония пробуждения!" },
                        new EpisodeData() { Id = 25, SerialDataId = 1, Number = 25, Name = "Что лежит за правдой и идеалами!" },
                        new EpisodeData() { Id = 26, SerialDataId = 1, Number = 26, Name = "Прощай, Юнова!Вперед, к новым приключениям!" },
                        new EpisodeData() { Id = 27, SerialDataId = 1, Number = 27, Name = "Опасность!Сладкая как мёд!" },
                        new EpisodeData() { Id = 28, SerialDataId = 1, Number = 28, Name = "Сайлан и дело свидетельницы Пурлойн!" },
                        new EpisodeData() { Id = 29, SerialDataId = 1, Number = 29, Name = "Коронация короля Гребешков!" },
                        new EpisodeData() { Id = 30, SerialDataId = 1, Number = 30, Name = "Остров Иллюзий!" },
                        new EpisodeData() { Id = 31, SerialDataId = 1, Number = 31, Name = "Поймать Ротома!" },
                        new EpisodeData() { Id = 32, SerialDataId = 1, Number = 32, Name = "Пираты Деколор!" },
                        new EpisodeData() { Id = 33, SerialDataId = 1, Number = 33, Name = "Баттерфри и я!"  },
                        new EpisodeData() { Id = 34, SerialDataId = 1, Number = 34, Name = "Дорога, ведущая к прощанию!" },
                        new EpisodeData() { Id = 35, SerialDataId = 1, Number = 35, Name = "В поисках Желания!" },
                        new EpisodeData() { Id = 36, SerialDataId = 1, Number = 36, Name = "НЛО на острове Капация!" },
                        new EpisodeData() { Id = 37, SerialDataId = 1, Number = 37, Name = "Журналист Покемонов из другого региона!" },
                        new EpisodeData() { Id = 38, SerialDataId = 1, Number = 38, Name = "Покемон необычной расцветки!" },
                        new EpisodeData() { Id = 39, SerialDataId = 1, Number = 39, Name = "Загадка пустынного острова!" },
                        new EpisodeData() { Id = 40, SerialDataId = 1, Number = 40, Name = "Вперёд, Гогоут!" },
                        new EpisodeData() { Id = 41, SerialDataId = 1, Number = 41, Name = "Встреча кометы героя!" },
                        new EpisodeData() { Id = 42, SerialDataId = 1, Number = 42, Name = "Спасение гима Стриатон!" },
                        new EpisodeData() { Id = 43, SerialDataId = 1, Number = 43, Name = "Новый шокирующий член Команды Р!" },
                        new EpisodeData() { Id = 44, SerialDataId = 1, Number = 44, Name = "Всего хорошего и до новых встреч!" },
                        new EpisodeData() { Id = 45, SerialDataId = 1, Number = 45, Name = "Мечта продолжается!" }
                    }
                );
        }
    }
}
