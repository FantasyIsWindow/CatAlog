using CatAlog_App.Db.DbContexts;
using CatAlog_App.Db.DtoModels;

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

        }
    }
}
