using CatAlog_App.DbWorker.DbContexts.DbModels.GeneralModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.GeneralModels
{
    internal class ScreenwriterConfiguration : IEntityTypeConfiguration<Screenwriter>
    {
        public void Configure(EntityTypeBuilder<Screenwriter> builder)
        {
            builder.HasMany(ad => ad.AdditionallyData_Screenwriter).WithOne(s => s.Screenwriter).HasForeignKey(k => k.ScreenwriterId);
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
