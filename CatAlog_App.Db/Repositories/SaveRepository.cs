using CatAlog_App.Db.DbContexts;
using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;
using CatAlog_App.Db.DtoModels;
using System.Collections.Generic;
using CatAlog_App.Db.DbContexts.DbModels.VideoModels;
using CatAlog_App.Db.DbContexts.DbModels.Relationship;
using System.Linq;

namespace CatAlog_App.Db.Repositories
{
    public class SaveRepository
    {
        private CatalogContext _db;

        public SaveRepository()
        {
            _db = new CatalogContext();
        }
        
        public void SaveNewRecord(DtoFullVideoData record)
        {
            MainRecordData mainRecord = new MainRecordData()
            {
                Rating = record.DtoMainData.Rating,
                ReleaseDate = record.DtoMainData.ReleaseDate,
                Duration = record.DtoMainData.Duration,
                TitleImage = record.DtoMainData.TitleImage,
                Description = record.DtoMainData.Description,
                Name = new NameData()
                {
                    FirstName = record.DtoMainData.Name.FirstName,
                    SecondName = record.DtoMainData.Name.SecondName,
                    ThirdName = record.DtoMainData.Name.ThirdName,
                    FourthName = record.DtoMainData.Name.FourthName
                },
                SerialData = new SerialData()
                {
                    CountSpecials = record.DtoSerialData.CountSpecials,
                    Note = record.DtoSerialData.Note,
                    SeasonNumber = record.DtoSerialData.SeasonNumber,
                    Type = record.DtoSerialData.Type
                },
                AdditionallyData = new AdditionallyData()
                {
                    Note = record.DtoAdditionallyData.Note,
                    ReleaseAuthor = record.DtoAdditionallyData.ReleaseAuthor
                },
                Media = new Media()
                {
                    Size = record.DtoMediaData.Size
                }
            };

            mainRecord.Category = GetCategory(record.DtoMainData);
            mainRecord.Category.Template = GetTemplate(record.DtoMainData);
            mainRecord.Screenshots = GetScreenshots(record.DtoMainData.Screenshots);
            mainRecord.SerialData.Episodes = GetEpisodes(record.DtoSerialData.Episodes);
            mainRecord.AdditionallyData.AdditionallyData_Actors = GetActors(record.DtoAdditionallyData.Actors);
            mainRecord.AdditionallyData.AdditionallyData_Companies = GetCompanies(record.DtoAdditionallyData.Companies);
            mainRecord.AdditionallyData.AdditionallyData_Countries= GetCountries(record.DtoAdditionallyData.Countries);
            mainRecord.AdditionallyData.AdditionallyData_Genres= GetGenres(record.DtoAdditionallyData.Genres);
            mainRecord.AdditionallyData.AdditionallyData_Producers= GetProducers(record.DtoAdditionallyData.Producers);
            mainRecord.AdditionallyData.AdditionallyData_Screenwriters = GetScreenwriters(record.DtoAdditionallyData.Screenwriters);
            mainRecord.Media.VideoData = GetVideosData(record.DtoMediaData.VideoData);
            mainRecord.Media.AudioData = GetAudiosData(record.DtoMediaData.AudioData);
            mainRecord.Media.SubtitleData = GetSubtitleData(record.DtoMediaData.SubtitleData);

            _db.MainRecordDatas.Add(mainRecord);
            _db.SaveChanges();
        }

        private Template GetTemplate(DtoMainRecordModel model) => 
            _db.Templates.FirstOrDefault(t => t.Name == model.Template) ?? 
            new Template() 
            {
                Name = model.Template 
            };        

        private Category GetCategory(DtoMainRecordModel model) => 
            _db.Categories.FirstOrDefault(c => c.Type == model.Category) ?? 
            new Category() 
            {
                Type = model.Category 
            };

        private IEnumerable<Screenshot> GetScreenshots(List<DtoScreenshotModel> models)
        {
            List<Screenshot> screenshots = new List<Screenshot>();
            models.ForEach(s => screenshots.Add(new Screenshot() { Path = s.Path }));
            return screenshots;
        }

        private IEnumerable<EpisodeData> GetEpisodes(List<DtoEpisode> models)
        {
            List<EpisodeData> episodes = new List<EpisodeData>();
            models.ForEach(e => episodes.Add(new EpisodeData() { Number = e.Number, Name = e.Name }));
            return episodes;
        }

        private IEnumerable<AdditionallyData_Actor> GetActors(List<DtoPairModel> models)
        {
            List<AdditionallyData_Actor> actors = new List<AdditionallyData_Actor>();
            var result = _db.Actors.ToList();
            for (int i = 0; i < models.Count; i++)
            {
                var element = result.FirstOrDefault(a => a.Name == models[i].Name);
                if (element != null)
                {
                    actors.Add(new AdditionallyData_Actor() { Actor = element });
                }
                else
                {
                    actors.Add(new AdditionallyData_Actor() { Actor = new Actor() { Name = models[i].Name } });
                }
            }

            return actors;
        }

        private IEnumerable<AdditionallyData_Company> GetCompanies(List<DtoPairModel> models)
        {
            List<AdditionallyData_Company> companies = new List<AdditionallyData_Company>();
            var result = _db.Companies.ToList();
            for (int i = 0; i < models.Count; i++)
            {
                var element = result.FirstOrDefault(a => a.Name == models[i].Name);
                if (element != null)
                {
                    companies.Add(new AdditionallyData_Company() { Company = element });
                }
                else
                {
                    companies.Add(new AdditionallyData_Company() { Company = new Company() { Name = models[i].Name } });
                }
            }

            return companies;
        }

        private IEnumerable<AdditionallyData_Country> GetCountries(List<DtoPairModel> models)
        {
            List<AdditionallyData_Country> countries = new List<AdditionallyData_Country>();
            var result = _db.Countries.ToList();
            for (int i = 0; i < models.Count; i++)
            {
                var element = result.FirstOrDefault(a => a.Name == models[i].Name);
                if (element != null)
                {
                    countries.Add(new AdditionallyData_Country() { Country = element });
                }
                else
                {
                    countries.Add(new AdditionallyData_Country() { Country = new Country() { Name = models[i].Name } });
                }
            }

            return countries;
        }

        private IEnumerable<AdditionallyData_Genre> GetGenres(List<DtoPairModel> models)
        {
            List<AdditionallyData_Genre> genres = new List<AdditionallyData_Genre>();
            var result = _db.Genres.ToList();
            for (int i = 0; i < models.Count; i++)
            {
                var element = result.FirstOrDefault(a => a.Name == models[i].Name);
                if (element != null)
                {
                    genres.Add(new AdditionallyData_Genre() { Genre = element });
                }
                else
                {
                    genres.Add(new AdditionallyData_Genre() { Genre = new Genre() { Name = models[i].Name } });
                }
            }

            return genres;
        }

        private IEnumerable<AdditionallyData_Producer> GetProducers(List<DtoPairModel> models)
        {
            List<AdditionallyData_Producer> producers = new List<AdditionallyData_Producer>();
            var result = _db.Producers.ToList();
            for (int i = 0; i < models.Count; i++)
            {
                var element = result.FirstOrDefault(a => a.Name == models[i].Name);
                if (element != null)
                {
                    producers.Add(new AdditionallyData_Producer() { Producer = element });
                }
                else
                {
                    producers.Add(new AdditionallyData_Producer() { Producer = new Producer() { Name = models[i].Name } });
                }
            }

            return producers;
        }

        private IEnumerable<AdditionallyData_Screenwriter> GetScreenwriters(List<DtoPairModel> models)
        {
            List<AdditionallyData_Screenwriter> screenwriter = new List<AdditionallyData_Screenwriter>();
            var result = _db.Screenwriters.ToList();
            for (int i = 0; i < models.Count; i++)
            {
                var element = result.FirstOrDefault(a => a.Name == models[i].Name);
                if (element != null)
                {
                    screenwriter.Add(new AdditionallyData_Screenwriter() { Screenwriter = element });
                }
                else
                {
                    screenwriter.Add(new AdditionallyData_Screenwriter() { Screenwriter = new Screenwriter() { Name = models[i].Name } });
                }
            }

            return screenwriter;
        }

        private IEnumerable<VideoData> GetVideosData(List<DtoVideoData> models)
        {
            List<VideoData> videos = new List<VideoData>();
            models.ForEach(v => videos.Add(new VideoData()
            {
                Bitrate = v.Bitrate,
                FrameRate = v.FrameRate,
                Note = v.Note,
                Relation = v.Relation,
                ResolutionHeigth = v.ResolutionHeigth,
                ResolutionWidth = v.ResolutionWidth,
                VideoFormat = v.VideoFormat,
                VideoQuality = v.VideoQuality
            }));
            return videos;
        }

        private IEnumerable<AudioData> GetAudiosData(List<DtoAudioData> models)
        {
            List<AudioData> audios = new List<AudioData>();
            models.ForEach(a => audios.Add(new AudioData()
            {
                AudioFormat = a.AudioFormat,
                Author = a.Author,
                Bitrate = a.Bitrate,
                Channel = a.Channel,
                Frequency = a.Frequency,
                Language = a.Language,
                Note = a.Note
            }));
            return audios;
        }

        private IEnumerable<SubtitleData> GetSubtitleData(List<DtoSubtitleData> models)
        {
            List<SubtitleData> subtitles = new List<SubtitleData>();
            models.ForEach(s => subtitles.Add(new SubtitleData()
            {
                Author = s.Author,
                Language = s.Language,
                Note = s.Note,
                SubtitleFormat = s.SubtitleFormat
            }));
            return subtitles;
        }
    }
}
