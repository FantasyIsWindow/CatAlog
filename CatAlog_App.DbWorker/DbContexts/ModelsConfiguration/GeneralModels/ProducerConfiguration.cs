using CatAlog_App.DbWorker.DbContexts.DbModels.GeneralModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.GeneralModels
{
    internal class ProducerConfiguration : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.HasMany(ad => ad.AdditionallyInfo_Producer).WithOne(p => p.Producer).HasForeignKey(k => k.ProducerId);
            builder.HasData
                (
                    new Producer[]
                    {
                        new Producer() { Id = 1, Name = "Джеймс Кэмерон" },
                        new Producer() { Id = 2, Name = "Джон Г. Эвилдсен" },
                        new Producer() { Id = 3, Name = "Абе Форсайт" },
                        new Producer() { Id = 4, Name = "Джастин Копеланд" },
                        new Producer() { Id = 5, Name = "Номура Кадзуя" },
                        new Producer() { Id = 6, Name = "Норихико Судо" }
                    }
                );
        }
    }
}
