using CatAlog_App.ConfigurationWorker;
using CatAlog_App.DbWorker.DbContexts.DbModels.GeneralModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.IO;

namespace CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.GeneralModels
{
    public class ScreenshotConfiguration : IEntityTypeConfiguration<Screenshot>
    {
        public void Configure(EntityTypeBuilder<Screenshot> builder)
        {
            SettingsManager settings = new SettingsManager();
            string path = Path.Combine(settings.Settings.DbFolderPath, settings.Settings.GraphicDataFolderName);

            string _01 = Path.Combine(path, "Terminator 2", "01.png");
            string _02 = Path.Combine(path, "Terminator 2", "02.png");
            string _03 = Path.Combine(path, "Terminator 2", "03.png");
            string _04 = Path.Combine(path, "Inferno", "01.png");
            string _05 = Path.Combine(path, "Inferno", "02.png");
            string _06 = Path.Combine(path, "Inferno", "03.png");
            string _07 = Path.Combine(path, "Little Monsters", "01.png");
            string _08 = Path.Combine(path, "Little Monsters", "02.png");
            string _09 = Path.Combine(path, "Little Monsters", "03.png");
            string _10 = Path.Combine(path, "Batman - Hush", "01.png");
            string _11 = Path.Combine(path, "Batman - Hush", "02.png");
            string _12 = Path.Combine(path, "Batman - Hush", "03.png");
            string _13 = Path.Combine(path, "Batman - Hush", "04.png");
            string _14 = Path.Combine(path, "Black fox", "01.png");
            string _15 = Path.Combine(path, "Black fox", "02.png");
            string _16 = Path.Combine(path, "Black fox", "03.png");
            string _17 = Path.Combine(path, "Pokemon, Black and White - Adventures in Unova", "01.png");
            string _18 = Path.Combine(path, "Pokemon, Black and White - Adventures in Unova", "02.png");
            string _19 = Path.Combine(path, "Pokemon, Black and White - Adventures in Unova", "03.png");
            string _20 = Path.Combine(path, "Pokemon, Black and White - Adventures in Unova", "04.png");

            builder.HasData
                (
                    new Screenshot[]
                    {
                        new Screenshot() { Id = 1,  Path = _01, MainRecordDataId = 1},
                        new Screenshot() { Id = 2,  Path = _02, MainRecordDataId = 1},
                        new Screenshot() { Id = 3,  Path = _03, MainRecordDataId = 1},
                        new Screenshot() { Id = 4,  Path = _04, MainRecordDataId = 2},
                        new Screenshot() { Id = 5,  Path = _05, MainRecordDataId = 2},
                        new Screenshot() { Id = 6,  Path = _06, MainRecordDataId = 2},
                        new Screenshot() { Id = 7,  Path = _07, MainRecordDataId = 3},
                        new Screenshot() { Id = 8,  Path = _08, MainRecordDataId = 3},
                        new Screenshot() { Id = 9,  Path = _09, MainRecordDataId = 3},
                        new Screenshot() { Id = 10, Path = _10, MainRecordDataId = 4},
                        new Screenshot() { Id = 11, Path = _11, MainRecordDataId = 4},
                        new Screenshot() { Id = 12, Path = _12, MainRecordDataId = 4},
                        new Screenshot() { Id = 13, Path = _13, MainRecordDataId = 4},
                        new Screenshot() { Id = 14, Path = _14, MainRecordDataId = 5},
                        new Screenshot() { Id = 15, Path = _15, MainRecordDataId = 5},
                        new Screenshot() { Id = 16, Path = _16, MainRecordDataId = 5},
                        new Screenshot() { Id = 17, Path = _17, MainRecordDataId = 6},
                        new Screenshot() { Id = 18, Path = _18, MainRecordDataId = 6},
                        new Screenshot() { Id = 19, Path = _19, MainRecordDataId = 6},
                        new Screenshot() { Id = 19, Path = _20, MainRecordDataId = 6}
                    }
                );
        }
    }
}


