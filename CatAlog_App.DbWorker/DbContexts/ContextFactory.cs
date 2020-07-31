using CatAlog_App.ConfigurationWorker;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace CatAlog_App.DbWorker.DbContexts
{
    internal class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            SettingsManager config = new SettingsManager();
            string connectionString = Path.Combine(config.Settings.DbFolderPath, config.Settings.DbFileName);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlite(connectionString);
            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
