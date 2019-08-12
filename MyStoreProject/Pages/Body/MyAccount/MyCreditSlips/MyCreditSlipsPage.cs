using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;

namespace MyStoreProject.Pages.Body.MyAccount.MyCreditSlips
{
    public class MyCreditSlipsPage
    {
        protected ISearch Search { get; private set; }
        public MyCreditSlipsPage() => Search = Application.Get().Search;
    }
}
