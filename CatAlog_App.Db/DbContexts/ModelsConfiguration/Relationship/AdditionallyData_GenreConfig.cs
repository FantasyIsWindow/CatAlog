using CatAlog_App.Db.DbContexts.DbModels.Relationship;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.Db.DbContexts.ModelsConfiguration.Relationship
{
    public class AdditionallyData_GenreConfig : IEntityTypeConfiguration<AdditionallyData_Genre>
    {
        public void Configure(EntityTypeBuilder<AdditionallyData_Genre> builder)
        {
            builder.HasOne(a => a.AdditionallyData).WithMany(g => g.AdditionallyData_Genres).HasForeignKey(k => k.AdditionallyDataId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(g => g.Genre).WithMany(a => a.AdditionallyData_Genre).HasForeignKey(k => k.GenreId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData
                (
                    new AdditionallyData_Genre[]
                    {
                        new AdditionallyData_Genre(){ Id = 1, AdditionallyDataId = 1 , GenreId = 1 },
                        new AdditionallyData_Genre(){ Id = 2, AdditionallyDataId = 1 , GenreId = 2 },
                        new AdditionallyData_Genre(){ Id = 3, AdditionallyDataId = 1 , GenreId = 7 },
                        new AdditionallyData_Genre(){ Id = 4, AdditionallyDataId = 2 , GenreId = 8 },
                        new AdditionallyData_Genre(){ Id = 5, AdditionallyDataId = 2 , GenreId = 3 },
                        new AdditionallyData_Genre(){ Id = 6, AdditionallyDataId = 2 , GenreId = 4 },
                        new AdditionallyData_Genre(){ Id = 7, AdditionallyDataId = 2 , GenreId = 5 },
                        new AdditionallyData_Genre(){ Id = 8, AdditionallyDataId = 3 , GenreId = 2 },
                        new AdditionallyData_Genre(){ Id = 9, AdditionallyDataId = 3 , GenreId = 4 },
                        new AdditionallyData_Genre(){ Id = 10, AdditionallyDataId = 4 , GenreId = 8 },
                        new AdditionallyData_Genre(){ Id = 11, AdditionallyDataId = 4 , GenreId = 7 },
                        new AdditionallyData_Genre(){ Id = 12, AdditionallyDataId = 5 , GenreId = 1 },
                        new AdditionallyData_Genre(){ Id = 13, AdditionallyDataId = 5 , GenreId = 3 },
                        new AdditionallyData_Genre(){ Id = 14, AdditionallyDataId = 5 , GenreId = 5 },
                        new AdditionallyData_Genre(){ Id = 15, AdditionallyDataId = 5 , GenreId = 6 },
                        new AdditionallyData_Genre(){ Id = 16, AdditionallyDataId = 6 , GenreId = 8 },
                        new AdditionallyData_Genre(){ Id = 17, AdditionallyDataId = 6 , GenreId = 2 },
                        new AdditionallyData_Genre(){ Id = 18, AdditionallyDataId = 6 , GenreId = 3 }
                    }
                );
        }
    }
}