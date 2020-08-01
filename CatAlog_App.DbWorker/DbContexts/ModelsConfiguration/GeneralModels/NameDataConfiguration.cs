using CatAlog_App.DbWorker.Models.GeneralModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.GeneralModels
{
    public class NameDataConfiguration : IEntityTypeConfiguration<NameData>
    {
        public void Configure(EntityTypeBuilder<NameData> builder)
        {
            builder.HasData
                (
                    new NameData[]
                    {
                        new NameData()
                        {
                             Id = 1,
                             FirstName = "Terminator 2: Judgment Day",
                             SecondName = "Терминатор 2: Судный день",
                             ThirdName = "",
                             FourthName = "",
                             MainRecordDataId = 1
                        },
                        new NameData()
                        {
                             Id = 2,
                             FirstName = "Inferno",
                             SecondName = "Инферно",
                             ThirdName = "",
                             FourthName = "",
                             MainRecordDataId = 2
                        },
                        new NameData()
                        {
                             Id = 3,
                             FirstName = "Little Monsters",
                             SecondName = "Маленькие чудовища",
                             ThirdName = "",
                             FourthName = "",
                             MainRecordDataId = 3
                        },
                        new NameData()
                        {
                             Id = 4,
                             FirstName = "Batman: Hush",
                             SecondName = "Бэтмен: Тихо",
                             ThirdName = "",
                             FourthName = "",
                             MainRecordDataId = 4
                        },
                        new NameData()
                        {
                             Id = 5,
                             FirstName = "Black Fox",
                             SecondName = "Чёрная лиса",
                             ThirdName = "",
                             FourthName = "",
                             MainRecordDataId = 5
                        },
                        new NameData()
                        {
                             Id = 6,
                             FirstName = "Pokemon: Black and White - Adventures in Unova",
                             SecondName = "Покемон: Чёрное и Белое - Приключения в Юнове",
                             ThirdName = "",
                             FourthName = "",
                             MainRecordDataId = 6
                        },
                    }
                );
        }
    }
}
