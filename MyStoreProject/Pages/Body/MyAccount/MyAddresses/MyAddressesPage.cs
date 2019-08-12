using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;

namespace MyStoreProject.Pages.Body.MyAccount.MyAddresses
{
    public class MyAddressesPage
    {
        protected ISearch Search { get; private set; }

        public MyAddressesPage() => Search = Application.Get().Search;

    }
}
