using MyStoreProject.Tools;
using MyStoreProject.Tools.SearchWebElements;

namespace MyStoreProject.Pages.Body.ContactUs
{
    public class ContactUs
    {
        protected ISearch Search { get; private set; }

        public ContactUs()
        {
            Search = Application.Get().Search;
        }

    }
}
