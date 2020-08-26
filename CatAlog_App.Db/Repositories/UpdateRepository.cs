using CatAlog_App.Db.DbContexts;
using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;
using CatAlog_App.Db.DbContexts.DbModels.Relationship;
using CatAlog_App.Db.DbContexts.DbModels.VideoModels;
using CatAlog_App.Db.DtoModels;
using System.Collections.Generic;
using System.Linq;

namespace CatAlog_App.Db.Repositories
{
    public class UpdateRepository
    {
        private CatalogContext _db;

        public UpdateRepository()
        {
            _db = new CatalogContext();
        }

        public void UpdateRecord(DtoFullVideoData record)
        {
            var main = MainRecordUpdate(record.DtoMainData);
            main.Media = MediaUpdate(record.DtoMediaData);
            main.SerialData = SerialUpdate(record.DtoSerialData);
            main.AdditionallyData = AdditionallyUpdate(record.DtoAdditionallyData);

            _db.SaveChanges();
        }

        private MainRecordData MainRecordUpdate(DtoMainRecordModel record)
        {
            var main = _db.MainRecordDatas.FirstOrDefault(m => m.Id == record.Id);
            main.Name = NameUpdate(record.Name);
            main.Description = record.Description;
            main.Duration = record.Duration;
            main.Rating = record.Rating;
            main.ReleaseDate = record.ReleaseDate;
            main.TitleImage = record.TitleImage;
            main.Screenshots = ScreenshotsUpdate(record);
            return main;
        }

        private NameData NameUpdate(DtoNameModel dto)
        {
            var names = _db.NameDatas.FirstOrDefault(n => n.Id == dto.Id);
            names.FirstName = dto.FirstName;
            names.SecondName = dto.SecondName;
            names.ThirdName = dto.ThirdName;
            names.FourthName = dto.FourthName;
            return names;
        }

        private IEnumerable<Screenshot> ScreenshotsUpdate(DtoMainRecordModel dto)
        {
            var screenshots = _db.Screenshots.Where(s => s.MainRecordDataId == dto.Id).ToList();
            _db.Screenshots.RemoveRange(screenshots);
            screenshots.Clear();
            dto.Screenshots.ForEach(s => screenshots.Add(new Screenshot() { Path = s.Path }));
            return screenshots;
        }

        private Media MediaUpdate(DtoMediaModel record)
        {
            var media = _db.Medias.FirstOrDefault(m => m.Id == record.Id);
            media.VideoData = VideoUpdate(record);
            media.AudioData = AudioUpdate(record);
            media.SubtitleData = SubtitleUpdate(record);
            media.Size = record.Size;
            return media;
        }

        private SerialData SerialUpdate(DtoSerialData record)
        {
            var serial = _db.SerialDatas.FirstOrDefault(s => s.Id == record.Id);
            if (serial != null)
            {
                serial.CountSpecials = record.CountSpecials;
                serial.Note = record.Note;
                serial.SeasonNumber = record.SeasonNumber;
                serial.Type = record.Type;
                serial.Episodes = EpisodesUpdate(record);
            }
            return serial;
        }

        private List<EpisodeData> EpisodesUpdate(DtoSerialData record)
        {
            var episodes = _db.EpisodeDatas.Where(e => e.SerialDataId == record.Id).ToList();
            for (int i = 0; i < episodes.Count; i++)
            {
                var tempItem = record.Episodes.FirstOrDefault(e => e.Id == episodes[i].Id);
                if (tempItem != null)
                {
                    episodes[i].Name = tempItem.Name;
                    episodes[i].Number = tempItem.Number;

                    record.Episodes.Remove(tempItem);
                }
                else
                {
                    episodes.RemoveAt(i);
                }
            }

            if (record.Episodes.Count > 0)
            {
                record.Episodes.ForEach(e => episodes.Add
                (
                    new EpisodeData()
                    {
                        Name = e.Name,
                        Number = e.Number
                    }
                ));
            }
            return episodes;
        }

        private List<VideoData> VideoUpdate(DtoMediaModel record)
        {
            var video = _db.VideoDatas.Where(v => v.MediaId == record.Id).ToList();
            for (int i = 0; i < video.Count; i++)
            {
                var tempItem = record.VideoData.FirstOrDefault(a => a.Id == video[i].Id);
                if (tempItem == null)
                {
                    _db.VideoDatas.Remove(video[i]);
                    video.RemoveAt(i);
                    i--;
                }
            }

            if (record.VideoData.Count > 0)
            {
                foreach (var item in record.VideoData)
                {
                    if (item.Id == 0)
                    {
                        video.Add
                            (
                                new VideoData()
                                {
                                    Bitrate = item.Bitrate,
                                    FrameRate = item.FrameRate,
                                    Note = item.Note,
                                    Relation = item.Relation,
                                    ResolutionHeigth = item.ResolutionHeigth,
                                    ResolutionWidth = item.ResolutionWidth,
                                    VideoFormat = item.VideoFormat,
                                    VideoQuality = item.VideoQuality
                                }
                            );
                    }
                    else
                    {
                        var existingRecord = video.FirstOrDefault(v => v.Id == item.Id);
                        existingRecord.Bitrate = item.Bitrate;
                        existingRecord.FrameRate = item.FrameRate;
                        existingRecord.Note = item.Note;
                        existingRecord.Relation = item.Relation;
                        existingRecord.ResolutionHeigth = item.ResolutionHeigth;
                        existingRecord.ResolutionWidth = item.ResolutionWidth;
                        existingRecord.VideoFormat = item.VideoFormat;
                        existingRecord.VideoQuality = item.VideoQuality;
                    }
                }
            }
            return video;
        }

        private List<AudioData> AudioUpdate(DtoMediaModel record)
        {
            var audio = _db.AudioDatas.Where(a => a.MediaId == record.Id).ToList();
            for (int i = 0; i < audio.Count; i++)
            {
                var tempItem = record.AudioData.FirstOrDefault(a => a.Id == audio[i].Id);
                if (tempItem == null)
                {
                    _db.AudioDatas.Remove(audio[i]);
                    audio.RemoveAt(i);
                    i--;
                }
            }

            if (record.VideoData.Count > 0)
            {
                foreach (var item in record.AudioData)
                {
                    if (item.Id == 0)
                    {
                        audio.Add
                            (
                                new AudioData()
                                {
                                    AudioFormat = item.AudioFormat,
                                    Author = item.Author,
                                    Bitrate = item.Bitrate,
                                    Channel = item.Channel,
                                    Frequency = item.Frequency,
                                    Language = item.Language,
                                    Note = item.Note
                                }
                            );
                    }
                    else
                    {
                        var existingRecord = audio.FirstOrDefault(v => v.Id == item.Id);
                        existingRecord.AudioFormat = item.AudioFormat;
                        existingRecord.Author = item.Author;
                        existingRecord.Bitrate = item.Bitrate;
                        existingRecord.Channel = item.Channel;
                        existingRecord.Frequency = item.Frequency;
                        existingRecord.Language = item.Language;
                        existingRecord.Note = item.Note;
                    }
                }
            }
            return audio;
        }

        private List<SubtitleData> SubtitleUpdate(DtoMediaModel record)
        {
            var subtitles = _db.SubtitleDatas.Where(a => a.MediaId == record.Id).ToList();
            for (int i = 0; i < subtitles.Count; i++)
            {
                var tempItem = record.SubtitleData.FirstOrDefault(a => a.Id == subtitles[i].Id);
                if (tempItem == null)
                {
                    _db.SubtitleDatas.Remove(subtitles[i]);
                    subtitles.RemoveAt(i);
                    i--;
                }
            }

            if (record.VideoData.Count > 0)
            {
                foreach (var item in record.SubtitleData)
                {
                    if (item.Id == 0)
                    {
                        subtitles.Add
                            (
                                new SubtitleData()
                                {
                                    Author = item.Author,
                                    Language = item.Language,
                                    Note = item.Note,
                                    SubtitleFormat = item.SubtitleFormat
                                }
                             );
                    }
                    else
                    {
                        var existingRecord = subtitles.FirstOrDefault(v => v.Id == item.Id);
                        existingRecord.Author = item.Author;
                        existingRecord.Language = item.Language;
                        existingRecord.Note = item.Note;
                        existingRecord.SubtitleFormat = item.SubtitleFormat;
                    }
                }
            }

            return subtitles;
        }

        private AdditionallyData AdditionallyUpdate(DtoAdditionalDataModel record)
        {
            var addit = _db.AdditionallyDatas.FirstOrDefault(a => a.Id == record.Id);
            addit.Note = record.Note;
            addit.ReleaseAuthor = record.ReleaseAuthor;
            addit.AdditionallyData_Actors = ActorsUpdate(record);
            addit.AdditionallyData_Companies = CompaniesUpdate(record);
            addit.AdditionallyData_Countries = CountriesUpdate(record);
            addit.AdditionallyData_Genres = GenresUpdate(record);
            addit.AdditionallyData_Producers = ProducersUpdate(record);
            addit.AdditionallyData_Screenwriters = ScreenwritersUpdate(record);
            return addit;
        }

        private IEnumerable<AdditionallyData_Actor> ActorsUpdate(DtoAdditionalDataModel record)
        {
            var actors = _db.AdditionallyData_Actors.Where(a => a.AdditionallyDataId == record.Id).ToList();
            for (int i = 0; i < actors.Count; i++)
            {
                var tempItem = record.Actors.FirstOrDefault(a => a.Id == actors[i].ActorId);
                if (tempItem == null)
                {
                    _db.AdditionallyData_Actors.Remove(actors[i]);
                }
                else
                {
                    record.Actors.Remove(tempItem);
                }
            }

            if (record.Actors.Count > 0)
            {
                actors.Clear();
                foreach (var item in record.Actors)
                {
                    if (item.Id == 0)
                    {
                        actors.Add(new AdditionallyData_Actor() { Actor = new Actor() { Name = item.Name } });
                    }
                    else
                    {
                        actors.Add(new AdditionallyData_Actor() { ActorId = item.Id});
                    }
                }
            }

            return actors;
        }

        private IEnumerable<AdditionallyData_Company> CompaniesUpdate(DtoAdditionalDataModel record)
        {
            var companies = _db.AdditionallyData_Companies.Where(a => a.AdditionallyDataId == record.Id).ToList();
            for (int i = 0; i < companies.Count; i++)
            {
                var tempItem = record.Companies.FirstOrDefault(a => a.Id == companies[i].CompanyId);
                if (tempItem == null)
                {
                    _db.AdditionallyData_Companies.Remove(companies[i]);
                }
                else
                {
                    record.Companies.Remove(tempItem);
                }
            }

            if (record.Companies.Count > 0)
            {
                companies.Clear();
                foreach (var item in record.Companies)
                {
                    if (item.Id == 0)
                    {
                        companies.Add(new AdditionallyData_Company() { Company = new Company() { Name = item.Name } });
                    }
                    else
                    {
                        companies.Add(new AdditionallyData_Company() { CompanyId = item.Id });
                    }
                }
            }

            return companies;
        }

        private IEnumerable<AdditionallyData_Country> CountriesUpdate(DtoAdditionalDataModel record)
        {
            var countries = _db.AdditionallyData_Countries.Where(a => a.AdditionallyDataId == record.Id).ToList();
            for (int i = 0; i < countries.Count; i++)
            {
                var tempItem = record.Countries.FirstOrDefault(a => a.Id == countries[i].CountryId);
                if (tempItem == null)
                {
                    _db.AdditionallyData_Countries.Remove(countries[i]);
                }
                else
                {
                    record.Countries.Remove(tempItem);
                }
            }

            if (record.Countries.Count > 0)
            {
                countries.Clear();
                foreach (var item in record.Countries)
                {
                    if (item.Id == 0)
                    {
                        countries.Add(new AdditionallyData_Country() { Country = new Country() { Name = item.Name } });
                    }
                    else
                    {
                        countries.Add(new AdditionallyData_Country() { CountryId = item.Id });
                    }
                }
            }

            return countries;
        }

        private IEnumerable<AdditionallyData_Genre> GenresUpdate(DtoAdditionalDataModel record)
        {
            var genres = _db.AdditionallyData_Genres.Where(a => a.AdditionallyDataId == record.Id).ToList();
            for (int i = 0; i < genres.Count; i++)
            {
                var tempItem = record.Genres.FirstOrDefault(a => a.Id == genres[i].GenreId);
                if (tempItem == null)
                {
                    _db.AdditionallyData_Genres.Remove(genres[i]);
                }
                else
                {
                    record.Genres.Remove(tempItem);
                }
            }

            if (record.Genres.Count > 0)
            {
                genres.Clear();
                foreach (var item in record.Genres)
                {
                    if (item.Id == 0)
                    {
                        genres.Add(new AdditionallyData_Genre() { Genre = new Genre() { Name = item.Name } });
                    }
                    else
                    {
                        genres.Add(new AdditionallyData_Genre() { GenreId = item.Id });
                    }
                }
            }

            return genres;
        }

        private IEnumerable<AdditionallyData_Producer> ProducersUpdate(DtoAdditionalDataModel record)
        {
            var producers = _db.AdditionallyData_Producers.Where(a => a.AdditionallyDataId == record.Id).ToList();
            for (int i = 0; i < producers.Count; i++)
            {
                var tempItem = record.Producers.FirstOrDefault(a => a.Id == producers[i].ProducerId);
                if (tempItem == null)
                {
                    _db.AdditionallyData_Producers.Remove(producers[i]);
                }
                else
                {
                    record.Producers.Remove(tempItem);
                }
            }

            if (record.Producers.Count > 0)
            {
                producers.Clear();
                foreach (var item in record.Producers)
                {
                    if (item.Id == 0)
                    {
                        producers.Add(new AdditionallyData_Producer() { Producer = new Producer() { Name = item.Name } });
                    }
                    else
                    {
                        producers.Add(new AdditionallyData_Producer() { ProducerId = item.Id });
                    }
                }
            }

            return producers;
        }

        private IEnumerable<AdditionallyData_Screenwriter> ScreenwritersUpdate(DtoAdditionalDataModel record)
        {
            var screenwriters = _db.AdditionallyData_Screenwriters.Where(a => a.AdditionallyDataId == record.Id).ToList();
            for (int i = 0; i < screenwriters.Count; i++)
            {
                var tempItem = record.Screenwriters.FirstOrDefault(a => a.Id == screenwriters[i].ScreenwriterId);
                if (tempItem == null)
                {
                    _db.AdditionallyData_Screenwriters.Remove(screenwriters[i]);
                }
                else
                {
                    record.Screenwriters.Remove(tempItem);
                }
            }

            if (record.Screenwriters.Count > 0)
            {
                screenwriters.Clear();
                foreach (var item in record.Screenwriters)
                {
                    if (item.Id == 0)
                    {
                        screenwriters.Add(new AdditionallyData_Screenwriter() { Screenwriter = new Screenwriter() { Name = item.Name } });
                    }
                    else
                    {
                        screenwriters.Add(new AdditionallyData_Screenwriter() { ScreenwriterId = item.Id });
                    }
                }
            }

            return screenwriters;
        }
    }
}
