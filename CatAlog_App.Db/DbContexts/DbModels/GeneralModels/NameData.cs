namespace CatAlog_App.Db.DbContexts.DbModels.GeneralModels
{
    public class NameData
    {
        public uint Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }

        public string FourthName { get; set; }

        public uint MainRecordDataId { get; set; }
        public MainRecordData MainRecordData { get; set; }
    }
}
