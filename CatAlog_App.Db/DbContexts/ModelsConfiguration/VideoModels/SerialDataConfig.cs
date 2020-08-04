using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;
using CatAlog_App.Db.DbContexts.DbModels.VideoModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.Db.DbContexts.ModelsConfiguration.VideoModels
{
    internal class SerialDataConfig : IEntityTypeConfiguration<SerialData>
    {
        public void Configure(EntityTypeBuilder<SerialData> builder)
        {
            builder.HasOne(m => m.MainRecordData).WithOne(s => s.SerialData).HasForeignKey<SerialData>(k => k.MainRecordDataId).OnDelete(DeleteBehavior.Cascade);
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