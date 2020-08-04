using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.Db.DbContexts.ModelsConfiguration.GeneralModels
{
    public class ProducerConfig : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.HasIndex(n => n.Name).IsUnique();
            builder.HasData
                (
                    new Producer[]
                    {
                        new Producer() { Id = 1, Name = "Джеймс Кэмерон"    },
                        new Producer() { Id = 2, Name = "Джон Г. Эвилдсен"  },
                        new Producer() { Id = 3, Name = "Абе Форсайт"       },
                        new Producer() { Id = 4, Name = "Джастин Копеланд"  },
                        new Producer() { Id = 5, Name = "Номура Кадзуя"     },
                        new Producer() { Id = 6, Name = "Норихико Судо"     }
                    }
                );
        }
    }
}
