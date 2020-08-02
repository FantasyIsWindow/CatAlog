using CatAlog_App.DbWorker.DbContexts.DbModels.VideoModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.VideoModels
{
    internal class SerialDataConfiguration : IEntityTypeConfiguration<SerialData>
    {
        public void Configure(EntityTypeBuilder<SerialData> builder)
        {
            builder.HasMany(e => e.Episodes).WithOne(s => s.SerialData).HasForeignKey(k => k.SerialDataId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData
                (
                    new SerialData[]
                    {
                        new SerialData()
                        {
                            Id = 1,
                            CountSpecials = 0,
                            SeasonNumber = 18,
                            Type = "TV",
                            MainRecordDataId = 6,
                            Note = "Very interesting"
                        }
                    }
                );
        }
    }
}
