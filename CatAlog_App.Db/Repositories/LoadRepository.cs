using CatAlog_App.Db.DbContexts;
using CatAlog_App.Db.DtoModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

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

        public List<string> GetTemplates() =>
            (from i in _db.Templates orderby i.Name select i.Name).ToList();

        public List<string> GetCategories() =>
            (from c in _db.Categories orderby c.Type select c.Type).ToList();

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
            (from c in _db.Countries
             select new DtoPairModel
             {
                 Id = c.Id,
                 Name = c.Name
             }).ToList();

        public List<DtoPairModel> GetGenresList() =>
            (from g in _db.Genres
             select new DtoPairModel
             {
                 Id = g.Id,
                 Name = g.Name
             }).ToList();

        public List<DtoPairModel> GetCompaniesList() =>
            (from c in _db.Companies
             select new DtoPairModel
             {
                 Id = c.Id,
                 Name = c.Name
             }).ToList();

        public List<string> GetReleaseAuthorsList() =>
            (from a in _db.AdditionallyDatas
             orderby a.ReleaseAuthor
             select a.ReleaseAuthor).ToList();

        public List<DtoPairModel> GetProducersList() =>
            (from p in _db.Producers
             select new DtoPairModel
             {
                 Id = p.Id,
                 Name = p.Name
             }).ToList();

        public List<DtoPairModel> GetScreenwritersList() =>
            (from s in _db.Screenwriters
             select new DtoPairModel
             {
                 Id = s.Id,
                 Name = s.Name
             }).ToList();

        public List<DtoPairModel> GetActorsList() =>
            (from s in _db.Actors
             select new DtoPairModel
             {
                 Id = s.Id,
                 Name = s.Name
             }).ToList();

        public List<string> GetSerialTypeList() =>
            (from a in _db.SerialDatas
             orderby a.Type 
             select a.Type).ToList();

        public List<string> GetVideoQualityList() =>
            (from a in _db.VideoDatas
             orderby a.VideoQuality
             select a.VideoQuality).ToList();

        public List<string> GetVideoRelationList() =>
            (from a in _db.VideoDatas
             orderby a.Relation
             select a.Relation).ToList();

        public List<ushort> GetVideoWidthList() =>
            (from a in _db.VideoDatas
             orderby a.ResolutionWidth
             select a.ResolutionWidth).ToList();

        public List<ushort> GetVideoHeightList() =>
            (from a in _db.VideoDatas
             orderby a.ResolutionHeigth
             select a.ResolutionHeigth).ToList();

        public List<string> GetVideoFormatsList() =>
            (from a in _db.VideoDatas
             orderby a.VideoFormat
             select a.VideoFormat).ToList();

        public List<string> GetAudioChanelsList() =>
            (from a in _db.AudioDatas
             orderby a.Channel
             select a.Channel).ToList();

        public List<string> GetAudioLanguagesList() =>
            (from a in _db.AudioDatas
             orderby a.Language
             select a.Language).ToList();

        public List<string> GetAudioAuthorsList() =>
            (from a in _db.AudioDatas
             orderby a.Author
             select a.Author).ToList();

        public List<string> GetAudioFormatsList() =>
            (from a in _db.AudioDatas
             orderby a.AudioFormat
             select a.AudioFormat).ToList();

        //public List<string> GetSubtitleLanguagesList() =>
        //    (from a in _db.SubtitleDatas
        //     orderby a.Language
        //     select a.Language).ToList();

        public List<string> GetSubtitleLanguagesList() => 
            _db.SubtitleDatas.Select(l => l.Language).Distinct().ToList();

        public List<string> GetSubtitleAuthorsList() =>
            (from a in _db.SubtitleDatas
             orderby a.Author
             select a.Author).ToList();

        //public List<string> GetSubtitlesFormatList() =>
        //    (from a in _db.SubtitleDatas
        //     orderby a.SubtitleFormat
        //     select a.SubtitleFormat).ToList();

        public List<string> GetSubtitlesFormatList() => 
            _db.SubtitleDatas.Select(n => n.SubtitleFormat).Distinct().ToList();
    }
}
