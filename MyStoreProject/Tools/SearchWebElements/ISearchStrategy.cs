namespace MyStoreProject.Tools.SearchWebElements
{
    public interface ISearchStrategy : ISearch
    {
        void SetImplicitStrategy();

        void SetExplicitStrategy();
    }
}
