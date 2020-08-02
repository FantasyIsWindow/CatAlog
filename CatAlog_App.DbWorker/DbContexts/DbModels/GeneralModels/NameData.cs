namespace CatAlog_App.DbWorker.DbContexts.DbModels.GeneralModels
{
    public class NameData
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }

        public string FourthName { get; set; }


        public int MainRecordDataId { get; set; }
        public MainRecordData MainRecordData { get; set; }
    }
}
