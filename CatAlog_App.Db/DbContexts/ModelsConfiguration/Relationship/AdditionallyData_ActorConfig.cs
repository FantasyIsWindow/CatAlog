using CatAlog_App.Db.DbContexts.DbModels.Relationship;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.Db.DbContexts.ModelsConfiguration.Relationship
{
    public class AdditionallyData_ActorConfig : IEntityTypeConfiguration<AdditionallyData_Actor>
    {
        public void Configure(EntityTypeBuilder<AdditionallyData_Actor> builder)
        {
            builder.HasOne(a => a.AdditionallyData).WithMany(actor => actor.AdditionallyData_Actors).HasForeignKey(k => k.AdditionallyDataId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(actor => actor.Actor).WithMany(a => a.AdditionallyData_Actor).HasForeignKey(k => k.ActorId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData
                (
                    new AdditionallyData_Actor[]
                    {
                        new AdditionallyData_Actor() { Id = 1,  AdditionallyDataId = 1, ActorId = 1  },
                        new AdditionallyData_Actor() { Id = 2,  AdditionallyDataId = 1, ActorId = 2  },
                        new AdditionallyData_Actor() { Id = 3,  AdditionallyDataId = 1, ActorId = 3  },
                        new AdditionallyData_Actor() { Id = 4,  AdditionallyDataId = 1, ActorId = 4  },
                        new AdditionallyData_Actor() { Id = 5,  AdditionallyDataId = 1, ActorId = 5  },
                        new AdditionallyData_Actor() { Id = 6,  AdditionallyDataId = 1, ActorId = 6  },
                        new AdditionallyData_Actor() { Id = 7,  AdditionallyDataId = 1, ActorId = 7  },
                        new AdditionallyData_Actor() { Id = 8,  AdditionallyDataId = 1, ActorId = 8  },
                        new AdditionallyData_Actor() { Id = 9,  AdditionallyDataId = 1, ActorId = 9  },
                        new AdditionallyData_Actor() { Id = 10, AdditionallyDataId = 1, ActorId = 10 },
                        new AdditionallyData_Actor() { Id = 11, AdditionallyDataId = 2, ActorId = 11 },
                        new AdditionallyData_Actor() { Id = 12, AdditionallyDataId = 2, ActorId = 12 },
                        new AdditionallyData_Actor() { Id = 13, AdditionallyDataId = 2, ActorId = 13 },
                        new AdditionallyData_Actor() { Id = 14, AdditionallyDataId = 2, ActorId = 14 },
                        new AdditionallyData_Actor() { Id = 15, AdditionallyDataId = 2, ActorId = 15 },
                        new AdditionallyData_Actor() { Id = 16, AdditionallyDataId = 2, ActorId = 16 },
                        new AdditionallyData_Actor() { Id = 17, AdditionallyDataId = 2, ActorId = 17 },
                        new AdditionallyData_Actor() { Id = 18, AdditionallyDataId = 2, ActorId = 18 },
                        new AdditionallyData_Actor() { Id = 19, AdditionallyDataId = 2, ActorId = 19 },
                        new AdditionallyData_Actor() { Id = 20, AdditionallyDataId = 2, ActorId = 20 },
                        new AdditionallyData_Actor() { Id = 21, AdditionallyDataId = 3, ActorId = 21 },
                        new AdditionallyData_Actor() { Id = 22, AdditionallyDataId = 3, ActorId = 22 },
                        new AdditionallyData_Actor() { Id = 23, AdditionallyDataId = 3, ActorId = 23 },
                        new AdditionallyData_Actor() { Id = 24, AdditionallyDataId = 3, ActorId = 24 },
                        new AdditionallyData_Actor() { Id = 25, AdditionallyDataId = 3, ActorId = 25 },
                        new AdditionallyData_Actor() { Id = 26, AdditionallyDataId = 3, ActorId = 26 },
                        new AdditionallyData_Actor() { Id = 27, AdditionallyDataId = 3, ActorId = 27 },
                        new AdditionallyData_Actor() { Id = 28, AdditionallyDataId = 3, ActorId = 28 },
                        new AdditionallyData_Actor() { Id = 29, AdditionallyDataId = 3, ActorId = 29 },
                        new AdditionallyData_Actor() { Id = 30, AdditionallyDataId = 3, ActorId = 30 },
                        new AdditionallyData_Actor() { Id = 31, AdditionallyDataId = 3, ActorId = 31 },
                        new AdditionallyData_Actor() { Id = 32, AdditionallyDataId = 3, ActorId = 32 },
                        new AdditionallyData_Actor() { Id = 33, AdditionallyDataId = 3, ActorId = 33 },
                        new AdditionallyData_Actor() { Id = 34, AdditionallyDataId = 4, ActorId = 34 },
                        new AdditionallyData_Actor() { Id = 35, AdditionallyDataId = 4, ActorId = 35 },
                        new AdditionallyData_Actor() { Id = 36, AdditionallyDataId = 4, ActorId = 36 },
                        new AdditionallyData_Actor() { Id = 37, AdditionallyDataId = 4, ActorId = 37 },
                        new AdditionallyData_Actor() { Id = 38, AdditionallyDataId = 4, ActorId = 38 },
                        new AdditionallyData_Actor() { Id = 39, AdditionallyDataId = 4, ActorId = 39 },
                        new AdditionallyData_Actor() { Id = 40, AdditionallyDataId = 4, ActorId = 40 },
                        new AdditionallyData_Actor() { Id = 41, AdditionallyDataId = 5, ActorId = 41 },
                        new AdditionallyData_Actor() { Id = 42, AdditionallyDataId = 5, ActorId = 42 },
                        new AdditionallyData_Actor() { Id = 43, AdditionallyDataId = 5, ActorId = 43 },
                        new AdditionallyData_Actor() { Id = 44, AdditionallyDataId = 5, ActorId = 44 },
                        new AdditionallyData_Actor() { Id = 45, AdditionallyDataId = 5, ActorId = 45 },
                        new AdditionallyData_Actor() { Id = 46, AdditionallyDataId = 5, ActorId = 46 },
                        new AdditionallyData_Actor() { Id = 47, AdditionallyDataId = 5, ActorId = 47 },
                        new AdditionallyData_Actor() { Id = 48, AdditionallyDataId = 5, ActorId = 48 },
                        new AdditionallyData_Actor() { Id = 49, AdditionallyDataId = 5, ActorId = 49 },
                        new AdditionallyData_Actor() { Id = 50, AdditionallyDataId = 6, ActorId = 50 },
                        new AdditionallyData_Actor() { Id = 51, AdditionallyDataId = 6, ActorId = 51 },
                        new AdditionallyData_Actor() { Id = 52, AdditionallyDataId = 6, ActorId = 52 },
                        new AdditionallyData_Actor() { Id = 53, AdditionallyDataId = 6, ActorId = 53 },
                        new AdditionallyData_Actor() { Id = 54, AdditionallyDataId = 6, ActorId = 54 },
                        new AdditionallyData_Actor() { Id = 55, AdditionallyDataId = 6, ActorId = 55 },
                        new AdditionallyData_Actor() { Id = 56, AdditionallyDataId = 6, ActorId = 56 },
                        new AdditionallyData_Actor() { Id = 57, AdditionallyDataId = 6, ActorId = 57 }
                    }
                );
        }
    }
}
