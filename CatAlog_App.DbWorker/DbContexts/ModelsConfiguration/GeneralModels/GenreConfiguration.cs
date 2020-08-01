using CatAlog_App.DbWorker.Models.GeneralModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.GeneralModels
{
    internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasMany(ad => ad.AdditionallyInfo_Genre).WithOne(g => g.Genre).HasForeignKey(k => k.GenreId);
            builder.HasData
                (
                    new Genre[]
                    {
                        new Genre() { Id = 1, Name = "Фантастика" },
                        new Genre() { Id = 2, Name = "Боевик" },
                        new Genre() { Id = 3, Name = "Триллер" },
                        new Genre() { Id = 4, Name = "Криминал" },
                        new Genre() { Id = 5, Name = "Комедия" },
                        new Genre() { Id = 6, Name = "Ужасы" },
                        new Genre() { Id = 7, Name = "Комикс" },
                        new Genre() { Id = 8, Name = "Приключения" },
                        new Genre() { Id = 9, Name = "Фэнтези" }
                    }
                );
        }
    }
}
