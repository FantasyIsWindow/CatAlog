namespace CatAlog_App.Db.DbContexts.DbModels.GeneralModels
{
    public class Screenshot
    {
        public uint Id { get; set; }

        public string Path { get; set; }

        public uint MainRecordDataId { get; set; }
        public MainRecordData MainRecordData { get; set; }
    }
}
