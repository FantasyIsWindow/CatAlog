using CatAlog_App.Db.DbContexts;
using CatAlog_App.Db.DtoModels;
using System.Collections.Generic;
using System.Linq;

namespace CatAlog_App.Db.Repositories
{
    public class LoadRepository
    {
        private CatalogContext _db;

        public LoadRepository()
        {
            _db = new CatalogContext();
        }

        public List<DtoCatalogHierarchy> GetHierarchy()
        {
            var data = new List<DtoCatalogHierarchy>();
            var templates = from t in _db.Templates select t.Name;
            foreach (string template in templates)
            {
                var category = (from c in _db.Categories
                                where c.Template.Name == template
                                select new DtoCategory
                                {
                                    CategoryName = c.Type,
                                    Count = (ushort)(from m in _db.MainRecordDatas
                                                     where c.Id == m.CategoryId
                                                     select m).Count()
                                }).ToList();

                data.Add(new DtoCatalogHierarchy
                {
                    TemplateName = template,
                    Categories = category
                });
            }

            return data;
        }

        public List<DtoShortRecordInfo> GetShortInfo(string category)
        {
            var result = (from m in _db.MainRecordDatas
                          where m.Category.Type == category
                          select new DtoShortRecordInfo
                          {
                              Id = m.Id,
                              FirstName = m.Name.FirstName,
                              SecondName = m.Name.SecondName,
                              Rating = m.Rating,
                              ReleaseDate = m.ReleaseDate,
                              TitleImage = m.TitleImage
                          }).ToList();

            return result;
        }

        public DtoShortRecordInfo GetShortInfo(uint id)
        {
            var result = (from m in _db.MainRecordDatas
                          where m.Id == id
                          select new DtoShortRecordInfo
                          {
                              Id = m.Id,
                              FirstName = m.Name.FirstName,
                              SecondName = m.Name.SecondName,
                              Rating = m.Rating,
                              ReleaseDate = m.ReleaseDate,
                              TitleImage = m.TitleImage
                          }).FirstOrDefault();

            return result;
        }

        public List<string> GetTemplates() => 
            _db.Templates.Select(t => t.Name).ToList();

        public List<string> GetCategories() => 
            _db.Categories.Select(c => c.Type).ToList();

        public DtoFullVideoData GetFullVideoData(uint id)
        {
            DtoFullVideoData model = new DtoFullVideoData()
            {
                DtoMainData = GetMaidDataModel(id),
                DtoAdditionallyData = GetAdditinallyDataModel(id),
                DtoMediaData = GetMediaDataModel(id),
                DtoSerialData = GetSerialDataModel(id)
            };
            return model;
        }

        private DtoMainRecordModel GetMaidDataModel(uint id)
        {
            var model = (from m in _db.MainRecordDatas
                         where m.Id == id
                         select new DtoMainRecordModel
                         {
                             Id = m.Id,
                             Category = m.Category.Type,
                             Template = m.Category.Template.Name,
                             Description = m.Description,
                             Duration = m.Duration,
                             Rating = m.Rating,
                             ReleaseDate = m.ReleaseDate,
                             TitleImage = m.TitleImage
                         }).FirstOrDefault();

            model.Name = (from n in _db.NameDatas
                          where n.MainRecordDataId == id
                          select new DtoNameModel
                          {
                              Id = n.Id,
                              FirstName = n.FirstName,
                              SecondName = n.SecondName,
                              ThirdName = n.ThirdName,
                              FourthName = n.FourthName
                          }).FirstOrDefault();

            model.Screenshots = (from s in _db.Screenshots
                                 where s.MainRecordDataId == id
                                 select new DtoScreenshotModel
                                 {
                                     Id = s.Id,
                                     Path = s.Path
                                 }).ToList();
            return model;
        }

        private DtoSerialData GetSerialDataModel(uint id)
        {
            var model = (from s in _db.SerialDatas
                         where s.MainRecordDataId == id
                         select new DtoSerialData
                         {
                             Id = s.Id,
                             CountSpecials = s.CountSpecials,
                             Note = s.Note,
                             SeasonNumber = s.SeasonNumber,
                             Type = s.Type,
                             Episodes = (from e in _db.EpisodeDatas
                                         where e.SerialDataId == s.Id
                                         select new DtoEpisode
                                         {
                                             Id = e.Id,
                                             Number = e.Number,
                                             Name = e.Name
                                         }).ToList()
                         }).FirstOrDefault();

            return model;
        }

        private DtoAdditionalDataModel GetAdditinallyDataModel(uint id)
        {
            var model = (from a in _db.AdditionallyDatas
                         where a.MainRecordDataId == id
                         select new DtoAdditionalDataModel
                         {
                             Id = a.Id,
                             Note = a.Note,
                             ReleaseAuthor = a.ReleaseAuthor
                         }).FirstOrDefault();


            model.Actors = (from a in _db.AdditionallyData_Actors
                            where a.AdditionallyDataId == model.Id
                            select new DtoPairModel
                            {
                                Id = a.Actor.Id,
                                Name = a.Actor.Name
                            }).ToList();

            model.Companies = (from c in _db.AdditionallyData_Companies
                               where c.AdditionallyDataId == model.Id
                               select new DtoPairModel
                               {
                                   Id = c.Company.Id,
                                   Name = c.Company.Name
                               }).ToList();

            model.Countries = (from c in _db.AdditionallyData_Countries
                               where c.AdditionallyDataId == model.Id
                               select new DtoPairModel
                               {
                                   Id = c.Country.Id,
                                   Name = c.Country.Name
                               }).ToList();

            model.Genres = (from g in _db.AdditionallyData_Genres
                            where g.AdditionallyDataId == model.Id
                            select new DtoPairModel
                            {
                                Id = g.Genre.Id,
                                Name = g.Genre.Name
                            }).ToList();

            model.Producers = (from p in _db.AdditionallyData_Producers
                               where p.AdditionallyDataId == model.Id
                               select new DtoPairModel
                               {
                                   Id = p.Producer.Id,
                                   Name = p.Producer.Name
                               }).ToList();

            model.Screenwriters = (from s in _db.AdditionallyData_Screenwriters
                                   where s.AdditionallyDataId == model.Id
                                   select new DtoPairModel
                                   {
                                       Id = s.Screenwriter.Id,
                                       Name = s.Screenwriter.Name
                                   }).ToList();
            return model;
        }

        private DtoMediaModel GetMediaDataModel(uint id)
        {
            var model = (from m in _db.Medias
                         where m.MainRecordDataId == id
                         select new DtoMediaModel
                         {
                             Id = m.Id,
                             Size = m.Size
                         }).FirstOrDefault();

            model.VideoData = (from v in _db.VideoDatas
                               where v.MediaId == model.Id
                               select new DtoVideoData
                               {
                                   Id = v.Id,
                                   Bitrate = v.Bitrate,
                                   FrameRate = v.FrameRate,
                                   Note = v.Note,
                                   Relation = v.Relation,
                                   ResolutionHeigth = v.ResolutionHeigth,
                                   ResolutionWidth = v.ResolutionWidth,
                                   VideoFormat = v.VideoFormat,
                                   VideoQuality = v.VideoQuality
                               }).ToList();

            model.AudioData = (from a in _db.AudioDatas
                               where a.MediaId == model.Id
                               select new DtoAudioData
                               {
                                   Id = a.Id,
                                   AudioFormat = a.AudioFormat,
                                   Author = a.Author,
                                   Bitrate = a.Bitrate,
                                   Channel = a.Channel,
                                   Frequency = a.Frequency,
                                   Language = a.Language,
                                   Note = a.Note
                               }).ToList();

            model.SubtitleData = (from s in _db.SubtitleDatas
                                  where s.MediaId == model.Id
                                  select new DtoSubtitleData
                                  {
                                      Id = s.Id,
                                      Author = s.Author,
                                      Language = s.Language,
                                      Note = s.Note,
                                      SubtitleFormat = s.SubtitleFormat
                                  }).ToList();
            return model;
        }

        public List<DtoPairModel> GetCountiesList() => 
            _db.Countries.Select(c => new DtoPairModel() { Id = c.Id, Name = c.Name }).ToList();

        public List<DtoPairModel> GetGenresList() => 
            _db.Genres.Select(g => new DtoPairModel() { Id = g.Id, Name = g.Name }).ToList();

        public List<DtoPairModel> GetCompaniesList() => 
            _db.Companies.Select(c => new DtoPairModel() { Id = c.Id, Name = c.Name }).ToList();

        public List<string> GetReleaseAuthorsList() => 
            _db.AdditionallyDatas.Select(r => r.ReleaseAuthor).Distinct().ToList();

        public List<DtoPairModel> GetProducersList() => 
            _db.Producers.Select(p => new DtoPairModel() { Id = p.Id, Name = p.Name }).ToList();

        public List<DtoPairModel> GetScreenwritersList() => 
            _db.Screenwriters.Select(s => new DtoPairModel() { Id = s.Id, Name = s.Name }).ToList();

        public List<DtoPairModel> GetActorsList() => 
            _db.Actors.Select(a => new DtoPairModel() { Id = a.Id, Name = a.Name }).ToList();

        public List<string> GetSerialTypeList() => 
            _db.SerialDatas.Select(t => t.Type).Distinct().ToList();

        public List<string> GetVideoQualityList() => 
            _db.VideoDatas.Select(q => q.VideoQuality).Distinct().ToList();

        public List<string> GetVideoRelationList() => 
            _db.VideoDatas.Select(r => r.Relation).Distinct().ToList();

        public List<ushort> GetVideoWidthList() => 
            _db.VideoDatas.Select(r => r.ResolutionWidth).Distinct().ToList();

        public List<ushort> GetVideoHeightList() => 
            _db.VideoDatas.Select(r => r.ResolutionHeigth).Distinct().ToList();

        public List<string> GetVideoFormatsList() => 
            _db.VideoDatas.Select(f => f.VideoFormat).Distinct().ToList();

        public List<string> GetAudioChanelsList() => 
            _db.AudioDatas.Select(c => c.Channel).Distinct().ToList();

        public List<string> GetAudioLanguagesList() => 
            _db.AudioDatas.Select(l => l.Language).Distinct().ToList();

        public List<string> GetAudioAuthorsList() => 
            _db.AudioDatas.Select(a => a.Author).Distinct().ToList();

        public List<string> GetAudioFormatsList() =>
            _db.AudioDatas.Select(f => f.AudioFormat).Distinct().ToList();

        public List<string> GetSubtitleLanguagesList() => 
            _db.SubtitleDatas.Select(l => l.Language).Distinct().ToList();

        public List<string> GetSubtitleAuthorsList() =>
            _db.SubtitleDatas.Select(a => a.Author).Distinct().ToList();

        public List<string> GetSubtitlesFormatList() => 
            _db.SubtitleDatas.Select(n => n.SubtitleFormat).Distinct().ToList();
    }
}