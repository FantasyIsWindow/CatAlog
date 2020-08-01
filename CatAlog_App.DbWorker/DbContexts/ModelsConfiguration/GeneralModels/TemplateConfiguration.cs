using CatAlog_App.DbWorker.Models.GeneralModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.GeneralModels
{
    public class TemplateConfiguration : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
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
