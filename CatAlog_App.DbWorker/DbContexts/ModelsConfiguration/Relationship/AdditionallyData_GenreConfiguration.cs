using CatAlog_App.DbWorker.DbContexts.DbModels.Relationship;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.Relationship
{
    internal class AdditionallyData_GenreConfiguration : IEntityTypeConfiguration<AdditionallyData_Genre>
    {
        public void Configure(EntityTypeBuilder<AdditionallyData_Genre> builder)
        {
            builder.HasData
                (
                    new AdditionallyData_Genre[]
                    {
                        new AdditionallyData_Genre(){ AdditionallyInfoId = 1 , GenreId = 1 },
                        new AdditionallyData_Genre(){ AdditionallyInfoId = 1 , GenreId = 2 },
                        new AdditionallyData_Genre(){ AdditionallyInfoId = 1 , GenreId = 7 },
                        new AdditionallyData_Genre(){ AdditionallyInfoId = 2 , GenreId = 8 },
                        new AdditionallyData_Genre(){ AdditionallyInfoId = 2 , GenreId = 3 },
                        new AdditionallyData_Genre(){ AdditionallyInfoId = 2 , GenreId = 4 },
                        new AdditionallyData_Genre(){ AdditionallyInfoId = 2 , GenreId = 5 },
                        new AdditionallyData_Genre(){ AdditionallyInfoId = 3 , GenreId = 2 },
                        new AdditionallyData_Genre(){ AdditionallyInfoId = 3 , GenreId = 4 },
                        new AdditionallyData_Genre(){ AdditionallyInfoId = 4 , GenreId = 8 },
                        new AdditionallyData_Genre(){ AdditionallyInfoId = 4 , GenreId = 7 },
                        new AdditionallyData_Genre(){ AdditionallyInfoId = 5 , GenreId = 1 },
                        new AdditionallyData_Genre(){ AdditionallyInfoId = 5 , GenreId = 3 },
                        new AdditionallyData_Genre(){ AdditionallyInfoId = 5 , GenreId = 5 },
                        new AdditionallyData_Genre(){ AdditionallyInfoId = 5 , GenreId = 6 },
                        new AdditionallyData_Genre(){ AdditionallyInfoId = 6 , GenreId = 8 },
                        new AdditionallyData_Genre(){ AdditionallyInfoId = 6 , GenreId = 2 },
                        new AdditionallyData_Genre(){ AdditionallyInfoId = 6 , GenreId = 3 }
                    }
                );
        }
    }
}
