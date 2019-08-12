using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;

namespace MyStoreProject.Pages.Body.ProductCompare
{
    public class ProductComparison
    {
        protected ISearch Search;

        public ProductComparison() => Search = Application.Get().Search;
    }
}
