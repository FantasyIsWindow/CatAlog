using System.Collections.Generic;

namespace CatAlog_App.Db.DtoModels
{
    public class DtoMainRecordModel
    {
        public int Id { get; set; }

        public string TitleImage { get; set; }

        public string Template { get; set; }

        public string Category { get; set; }

        public DtoNameModel Name { get; set; }

        public string Duration { get; set; }

        public string ReleaseDate { get; set; }

        public string Description { get; set; }

        public float? Rating { get; set; }

        public List<DtoScreenshotModel> Screenshots { get; set; }
    }

    public class DtoNameModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }

        public string FourthName { get; set; }
    }

    public class DtoScreenshotModel
    {
        public int Id { get; set; }

        public string Path { get; set; }
    }
}
