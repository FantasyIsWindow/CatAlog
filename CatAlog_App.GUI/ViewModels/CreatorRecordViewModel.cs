using CatAlog_App.ConfigurationWorker.Model;
using CatAlog_App.Db.Repositories;
using CatAlog_App.GUI.Infrastructure.Services;
using CatAlog_App.GUI.Models;
using System;
using System.Collections.ObjectModel;

namespace CatAlog_App.GUI.ViewModels
{
    public class CreatorRecordViewModel : RecordEditorBaseModel
    {
        public event EventHandler OkHandler;

        #region SHARED_PAGE_DATA

        public RellayCommand OkCommand
        {
            get
            {
                return _okCommand ??
                    (_okCommand = new RellayCommand(obj =>
                    {
                        if (_serialInfo.Episodes.Count != 0)
                        {
                            _serialInfo.Episodes = ParsingSeries();
                        }

                        DataPackModel gData = new DataPackModel();
                        gData.MainData = _generalData;
                        gData.AdditionallyData = _additionalInfo;
                        gData.SerialData = _serialInfo;
                        gData.MediaData = _mediaInfo;
                        gData.MediaData.VideoData = _videoInfo;
                        gData.MediaData.AudioData = _audioInfo;
                        gData.MediaData.SubtitleData = _subtitleInfo;

                        var result = gData.GetModel();
                        //int id = _repository.SaveData.SaveNewRecord(result.GetModel(), _configModel.PathToDbLocation);
                        //if (OkHandler != null)
                        //{
                        //    MessageEventArgs args = new MessageEventArgs()
                        //    {
                        //        Package = id
                        //    };
                        //    OkHandler.Invoke(null, args);
                        //}
                        CancelCommand.Execute(null);
                    }));
            }
        }

        #endregion
              
        #region INITIALIZATION

        public CreatorRecordViewModel(string template, string recordType, LoadRepository repository, PropertyLibrary config) : base(repository, config)
        {
            DisplayType = "Editing";
            _generalData = new MainDataModel()
            {
                Template = template,
                Category = recordType,
                TitleImage = "pack://application:,,,/Resources/Images/noImage.png"
            };

            _additionalInfo = new AdditionalDataModel();
            _serialInfo = new SerialDataModel();
            _mediaInfo = new MediaDataModel();
            _videoInfo = new ObservableCollection<VideoDataModel>();
            _audioInfo = new ObservableCollection<AudioDataModel>();
            _subtitleInfo = new ObservableCollection<SubtitleDataModel>();
        }

        #endregion
    }
}

/*
         private void qwe()
        {
            /*  MainRecordData mainRecord = new MainRecordData()
              {
                  Category = new Category()
                  {
                      Type = "qqq",
                      Template = new Template()
                      {
                          Name = "bbbbb"
                      }
                  },
                  Rating = 12.2f,
                  ReleaseDate = "12:5:61",
                  TitleImage = "htt:vpp.cam",
                  Description = "many many what",
                  Duration = "0:2:5",
                  Name = new NameData() { FirstName = "x", SecondName = "r" },
                  Screenshots = new List<Screenshot>()
                  {
                      new Screenshot() { Path = "D=fsdfsdfdsf" },
                      new Screenshot() { Path = "S=cvbcvbcvbc" },
                      new Screenshot() { Path = "V=jmghjghjgh" }
                  },
                  SerialData = new SerialData()
                  {
                      CountSpecials = 1,
                      Note = "Haip Haip",
                      SeasonNumber = 12,
                      Type = "Rav",
                      Episodes = new List<EpisodeData>()
                      {
                          new EpisodeData() { Number = "1", Name = "A" },
                          new EpisodeData() { Number = "2", Name = "B" },
                          new EpisodeData() { Number = "3", Name = "C" },
                          new EpisodeData() { Number = "4", Name = "D" },
                          new EpisodeData() { Number = "5", Name = "E" },
                      }
                  },
                  Media = new Media()
                  {
                      VideoData = new List<VideoData>()
                      {
                          new VideoData()
                          {
                              Bitrate = 12.2f,
                              FrameRate = 1.32f,
                              Note = "Vid",
                              Relation = "123",
                              ResolutionHeigth = 1980,
                              ResolutionWidth = 880,
                              VideoFormat = "VT",
                              VideoQuality = "Qool"
                          },
                          new VideoData()
                          {
                              Bitrate = 32.2f,
                              FrameRate = 21.11f,
                              Note = "Div",
                              Relation = "321",
                              ResolutionHeigth = 740,
                              ResolutionWidth = 480,
                              VideoFormat = "TV",
                              VideoQuality = "Midle"
                          }
                      },
                      AudioData = new List<AudioData>()
                      {
                          new AudioData()
                          {
                              AudioFormat = "For",
                              Author = "Not me",
                              Bitrate = 41.3f,
                              Channel = "12",
                              Frequency = 5,
                              Language = "Russian",
                              Note = "Listen"
                          },
                          new AudioData()
                          {
                              AudioFormat = "Rof",
                              Author = "Me not",
                              Bitrate = 21.8f,
                              Channel = "1",
                              Frequency = 21,
                              Language = "Russian",
                              Note = "Listen"
                          }
                      },
                      SubtitleData = new List<SubtitleData>()
                      {
                          new SubtitleData()
                          {
                              Author = "Who is",
                              Language = "Anderstud",
                              Note = "Interesting",
                              SubtitleFormat = "SRT"
                          },
                          new SubtitleData()
                          {
                              Author = "Is who",
                              Language = "Not Anderstud",
                              Note = "Wery Interesting",
                              SubtitleFormat = "TRS"
                          }
                      },
                      Size = 125.11f                    
                  },
                  AdditionallyData = new AdditionallyData()
                  {
                      ReleaseAuthor = "Dont now",
                      Note = "Happy mill",
                      AdditionallyData_Actors = new List<AdditionallyData_Actor>()
                      {
                          new AdditionallyData_Actor() { Actor = new Actor() { Name = "Babay"  } },                        
                          new AdditionallyData_Actor() { Actor = new Actor() { Name = "Mamay"  } },                        
                          new AdditionallyData_Actor() { Actor = new Actor() { Name = "Valday" } },                        
                          new AdditionallyData_Actor() { Actor = new Actor() { Name = "Opcions" } },                        
                          new AdditionallyData_Actor() { Actor = new Actor() { Name = "Pikchu" } }
                      },
                      AdditionallyData_Companies = new List<AdditionallyData_Company>()
                      {
                          new AdditionallyData_Company() { Company = new Company() { Name = "Hrundel" } },
                          new AdditionallyData_Company() { Company = new Company() { Name = "Slon" } }
                      },
                      AdditionallyData_Countries = new List<AdditionallyData_Country>()
                      { 
                         new AdditionallyData_Country() { Country = new Country() { Name = "Argentum" } },
                         new AdditionallyData_Country() { Country = new Country() { Name = "Ios" } }
                      },
                      AdditionallyData_Genres = new List<AdditionallyData_Genre>()
                      { 
                         new AdditionallyData_Genre() { Genre = new Genre() { Name = "Olla" } },
                         new AdditionallyData_Genre() { Genre = new Genre() { Name = "Voll" } }
                      },
                      AdditionallyData_Producers = new List<AdditionallyData_Producer>()
                      { 
                         new AdditionallyData_Producer() { Producer = new Producer() { Name = "Vasechkin" } },
                         new AdditionallyData_Producer() { Producer = new Producer() { Name = "Bubenchikov" } }
                      },
                      AdditionallyData_Screenwriters = new List<AdditionallyData_Screenwriter>()
                      { 
                         new AdditionallyData_Screenwriter() { Screenwriter = new Screenwriter() { Name = "DOM" } },
                         new AdditionallyData_Screenwriter() { Screenwriter = new Screenwriter() { Name = "BOM" } }
                      }
                  }
              };*/

// var record = _db.Templates.FirstOrDefault(n => n.Id == 3);

//var qwe = _db.Actors.FirstOrDefault(f => f.Name == "Opcions");


//ObservableCollection<CatalogHierarchyModel> model = new ObservableCollection<CatalogHierarchyModel>();
//var result = _load.GetHierarchy();
//result.ForEach(d => model.Add(new CatalogHierarchyModel(d)));

//using (_db = new CatalogContext())
//{
//    //_db.Remove(record);
//    //_db.Remove(qwe);
//    //_db.Add(mainRecord);

//    //_db.SaveChanges();

//    var qwe = from i in _db.Templates
//              select new
//              {
//                  Name = i.Name,
//                  Types = i.Categories.Select(n => n.Type).Distinct()                            
//              };

//    foreach (var item in qwe)
//    {

//    }

//    var x = 0;
//}
