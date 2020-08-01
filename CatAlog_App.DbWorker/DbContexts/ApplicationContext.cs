using CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.GeneralModels;
using CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.Relationship;
using CatAlog_App.DbWorker.DbContexts.ModelsConfiguration.VideoModels;
using CatAlog_App.DbWorker.Models.GeneralModels;
using CatAlog_App.DbWorker.Models.Relationship;
using CatAlog_App.DbWorker.Models.VideoModels;
using CatAlog_App.DbWorker.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CatAlog_App.DbWorker.DbContexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<AdditionallyData> AdditionallyData { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MainRecordData> MainRecordData { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<NameData> NameDatas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Screenshot> Screenshots { get; set; }
        public DbSet<Screenwriter> Screenwriters { get; set; }
        public DbSet<Template> Templates { get; set; }

        public DbSet<AudioData> AudioDatas { get; set; }
        public DbSet<EpisodeData> EpisodesData { get; set; }
        public DbSet<SerialData> SerialsData { get; set; }
        public DbSet<SubtitleData> SubtitlesData { get; set; }
        public DbSet<VideoData> VideosData { get; set; }


        public DbSet<AdditionallyData_Actor> AdditionallyData_Actors { get; set; }
        public DbSet<AdditionallyData_Company> AdditionallyData_Companies { get; set; }
        public DbSet<AdditionallyData_Country> AdditionallyData_Countries { get; set; }
        public DbSet<AdditionallyData_Genre> AdditionallyData_Genres { get; set; }
        public DbSet<AdditionallyData_Producer> AdditionallyData_Producers { get; set; }
        public DbSet<AdditionallyData_Screenwriter> AdditionallyData_Screenwriters { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseLoggerFactory(LoggerProvider);
        }

        public static readonly ILoggerFactory LoggerProvider = LoggerFactory.Create(builder =>
            builder.AddProvider(new LoggerProvider()));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Actor>(new ActorConfiguration());
            modelBuilder.ApplyConfiguration<AdditionallyData>(new AdditionallyDataConfiguration());
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration<Company>(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration<Country>(new CountryConfiguration());
            modelBuilder.ApplyConfiguration<Genre>(new GenreConfiguration());
            modelBuilder.ApplyConfiguration<MainRecordData>(new MainRecordDataConfiguration());
            modelBuilder.ApplyConfiguration<Media>(new MediaConfiguration());
            modelBuilder.ApplyConfiguration<NameData>(new NameDataConfiguration());
            modelBuilder.ApplyConfiguration<Producer>(new ProducerConfiguration());
            modelBuilder.ApplyConfiguration<Screenshot>(new ScreenshotConfiguration());
            modelBuilder.ApplyConfiguration<Screenwriter>(new ScreenwriterConfiguration));
            modelBuilder.ApplyConfiguration<Template>(new TemplateConfiguration());

            modelBuilder.ApplyConfiguration<AdditionallyData_Actor>(new AdditionallyData_ActorConfiguration));
            modelBuilder.ApplyConfiguration<AdditionallyData_Company>(new AdditionallyData_CompanyConfiguration());
            modelBuilder.ApplyConfiguration<AdditionallyData_Country>(new AdditionallyData_CountryConfiguration());
            modelBuilder.ApplyConfiguration<AdditionallyData_Genre>(new AdditionallyData_GenreConfiguration());
            modelBuilder.ApplyConfiguration<AdditionallyData_Producer>(new AdditionallyData_ProducerConfiguration());
            modelBuilder.ApplyConfiguration<AdditionallyData_Screenwriter>(new AdditionallyData_ScreenwriterConfiguration());

            modelBuilder.ApplyConfiguration<AudioData>(new AudioDataConfiguration());
            modelBuilder.ApplyConfiguration<EpisodeData>(new EpisodeDataConfiguration());
            modelBuilder.ApplyConfiguration<SerialData>(new SerialDataConfiguration());
            modelBuilder.ApplyConfiguration<SubtitleData>(new SubtitleDataConfiguration());
            modelBuilder.ApplyConfiguration<VideoData>(new VideoDataConfiguration());
        }
    }
}
