using CatAlog_App.DbWorker.DbContexts.DbModels.GeneralModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.GeneralModels
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasOne(t => t.Template).WithMany(c => c.Categories).HasForeignKey(k => k.TemplateId);
            builder.HasData
                (
                    new Category[]
                    {
                        new Category() { Id = 1, Type = "Film" },
                        new Category() { Id = 2, Type = "Animation" },
                        new Category() { Id = 3, Type = "Anime" }
                    }
                );
        }
    }
}
