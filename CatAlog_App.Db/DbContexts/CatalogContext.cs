using CatAlog_App.ConfigurationWorker;
using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;
using CatAlog_App.Db.DbContexts.DbModels.Relationship;
using CatAlog_App.Db.DbContexts.DbModels.VideoModels;
using CatAlog_App.Db.DbContexts.ModelsConfiguration.GeneralModels;
using CatAlog_App.Db.DbContexts.ModelsConfiguration.Relationship;
using CatAlog_App.Db.DbContexts.ModelsConfiguration.VideoModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.IO;

namespace CatAlog_App.Db.DbContexts
{
    public class CatalogContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<AdditionallyData> AdditionallyDatas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MainRecordData> MainRecordDatas { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<NameData> NameDatas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Screenshot> Screenshots { get; set; }
        public DbSet<Screenwriter> Screenwriters { get; set; }
        public DbSet<Template> Templates { get; set; }

        public DbSet<AdditionallyData_Actor> AdditionallyData_Actors { get; set; }
        public DbSet<AdditionallyData_Company> AdditionallyData_Companies { get; set; }
        public DbSet<AdditionallyData_Country> AdditionallyData_Countries { get; set; }
        public DbSet<AdditionallyData_Genre> AdditionallyData_Genres { get; set; }
        public DbSet<AdditionallyData_Producer> AdditionallyData_Producers { get; set; }
        public DbSet<AdditionallyData_Screenwriter> AdditionallyData_Screenwriters { get; set; }

        public DbSet<AudioData> AudioDatas { get; set; }
        public DbSet<EpisodeData> EpisodeDatas { get; set; }
        public DbSet<SerialData> SerialDatas { get; set; }
        public DbSet<SubtitleData> SubtitleDatas { get; set; }
        public DbSet<VideoData> VideoDatas { get; set; }

        public CatalogContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            SettingsManager config = new SettingsManager();
            string connectionString = Path.Combine(config.Settings.DbFolderPath, config.Settings.DbFileName);

            builder.UseSqlite("Filename=" + connectionString);
            builder.UseLoggerFactory(LoggerProvider);
        }

        public static readonly ILoggerFactory LoggerProvider = LoggerFactory.Create(builder =>
        {
            builder.AddProvider(new LoggerProvider());
        });

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<Actor>(new ActorConfig());
            builder.ApplyConfiguration<AdditionallyData>(new AdditionallyDataConfig());
            builder.ApplyConfiguration<Category>(new CategoryConfig());
            builder.ApplyConfiguration<Company>(new CompanyConfig());
            builder.ApplyConfiguration<Country>(new CountryConfig());
            builder.ApplyConfiguration<Genre>(new GenreConfig());
            builder.ApplyConfiguration<MainRecordData>(new MainRecordDataConfig());
            builder.ApplyConfiguration<Media>(new MediaConfig());
            builder.ApplyConfiguration<NameData>(new NameDataConfig());
            builder.ApplyConfiguration<Producer>(new ProducerConfig());
            builder.ApplyConfiguration<Screenshot>(new ScreenshotConfig());
            builder.ApplyConfiguration<Screenwriter>(new ScreenwriterConfig());
            builder.ApplyConfiguration<Template>(new TemplateConfig());

            builder.ApplyConfiguration<AdditionallyData_Actor>(new AdditionallyData_ActorConfig());
            builder.ApplyConfiguration<AdditionallyData_Company>(new AdditionallyData_CompanyConfig());
            builder.ApplyConfiguration<AdditionallyData_Country>(new AdditionallyData_CountryConfig());
            builder.ApplyConfiguration<AdditionallyData_Genre>(new AdditionallyData_GenreConfig());
            builder.ApplyConfiguration<AdditionallyData_Producer>(new AdditionallyData_ProducerConfig());
            builder.ApplyConfiguration<AdditionallyData_Screenwriter>(new AdditionallyData_ScreenwriterConfig());
                        
            builder.ApplyConfiguration<AudioData>(new AudioDataConfig());
            builder.ApplyConfiguration<EpisodeData>(new EpisodeDataConfig());
            builder.ApplyConfiguration<SerialData>(new SerialDataConfig());
            builder.ApplyConfiguration<SubtitleData>(new SubtitleDataConfig());
            builder.ApplyConfiguration<VideoData>(new VideoDataConfig());
        }
    }
}
