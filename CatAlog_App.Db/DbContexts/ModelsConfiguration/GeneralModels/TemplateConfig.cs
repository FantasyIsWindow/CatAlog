using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.Db.DbContexts.ModelsConfiguration.GeneralModels
{
    public class TemplateConfig : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.HasIndex(n => n.Name).IsUnique();
            builder.HasData
                (
                    new Template[]
                    {
                        new Template() { Id = 1, Name = "Video" },
                        new Template() { Id = 2, Name = "Game" }
                    }
                );
        }
    }
}
