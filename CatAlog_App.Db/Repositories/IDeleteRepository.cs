namespace CatAlog_App.Db.Repositories
{
    public interface IDeleteRepository
    {
        void RemoveCategoryTree(string categoryName);

        void RemoveRecord(uint id);
    }
}
