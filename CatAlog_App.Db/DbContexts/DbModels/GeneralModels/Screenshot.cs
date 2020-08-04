namespace CatAlog_App.Db.DbContexts.DbModels.GeneralModels
{
    public class Screenshot
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public int MainRecordDataId { get; set; }
        public MainRecordData MainRecordData { get; set; }
    }
}
