using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.Db.DbContexts.ModelsConfiguration.GeneralModels
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(t => t.Type).IsUnique();
            builder.HasOne(t => t.Template).WithMany(c => c.Categories).HasForeignKey(k => k.TemplateId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData
                (
                    new Category[]
                    {
                        new Category() { Id = 1, Type = "Film",      TemplateId = 1 },
                        new Category() { Id = 2, Type = "Animation", TemplateId = 1 },
                        new Category() { Id = 3, Type = "Anime",     TemplateId = 1 }
                    }
                );
        }
    }
}

