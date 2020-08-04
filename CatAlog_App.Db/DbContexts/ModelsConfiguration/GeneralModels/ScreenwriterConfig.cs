using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.Db.DbContexts.ModelsConfiguration.GeneralModels
{
    public class ScreenwriterConfig : IEntityTypeConfiguration<Screenwriter>
    {
        public void Configure(EntityTypeBuilder<Screenwriter> builder)
        {
            builder.HasData
                (
                    new Screenwriter[]
                    {
                        new Screenwriter() { Id = 1, Name = "Хаяси Наоки" }
                    }
                );
        }
    }
}
