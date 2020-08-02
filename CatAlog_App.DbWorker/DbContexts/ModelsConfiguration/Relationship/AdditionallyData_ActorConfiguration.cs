using CatAlog_App.DbWorker.DbContexts.DbModels.Relationship;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.Relationship
{
    internal class AdditionallyData_ActorConfiguration : IEntityTypeConfiguration<AdditionallyData_Actor>
    {
        public void Configure(EntityTypeBuilder<AdditionallyData_Actor> builder)
        {
            builder.HasData
                (
                    new AdditionallyData_Actor[]
                    {
                        new AdditionallyData_Actor() { AdditionallyInfoId = 1, ActorId = 1 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 1, ActorId = 2 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 1, ActorId = 3 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 1, ActorId = 4 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 1, ActorId = 5 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 1, ActorId = 6 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 1, ActorId = 7 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 1, ActorId = 8 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 1, ActorId = 9 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 1, ActorId = 10 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 2, ActorId = 11 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 2, ActorId = 12 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 2, ActorId = 13 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 2, ActorId = 14 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 2, ActorId = 15 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 2, ActorId = 16 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 2, ActorId = 17 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 2, ActorId = 18 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 2, ActorId = 19 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 2, ActorId = 20 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 3, ActorId = 21 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 3, ActorId = 22 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 3, ActorId = 23 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 3, ActorId = 24 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 3, ActorId = 25 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 3, ActorId = 26 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 3, ActorId = 27 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 3, ActorId = 28 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 3, ActorId = 29 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 3, ActorId = 30 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 3, ActorId = 31 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 3, ActorId = 32 },
                        new AdditionallyData_Actor() { AdditionallyInfoId = 3, ActorId = 33 },
                    }
                );
        }
    }
}
