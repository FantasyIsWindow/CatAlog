using CatAlog_App.Db.DbContexts;
using System.Linq;

namespace CatAlog_App.Db.Repositories
{
    public class DeleteRepository
    {
        private CatalogContext _db;

        public DeleteRepository()
        {
            _db = new CatalogContext();
        }

        public void RemoveCategoryTree(string categoryName)
        {
            var removedCategoryTree = _db.Categories.FirstOrDefault(c => c.Type == categoryName);
            _db.Categories.Remove(removedCategoryTree);
            _db.SaveChanges();
        }

        public void RemoveRecord(uint id)
        {
            var removedMainRecord = _db.MainRecordDatas.FirstOrDefault(m => m.Id == id);
            _db.MainRecordDatas.Remove(removedMainRecord);
            _db.SaveChanges();
        }
    }
}
