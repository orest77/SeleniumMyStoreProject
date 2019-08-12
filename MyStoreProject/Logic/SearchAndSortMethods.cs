using MyStoreProject.Pages.Body.SearchPages;
using MyStoreProject.Pages.Header;

namespace MyStoreProject.Logic
{
    public class SearchAndSortMethods
    {

        public string SearchProduct(string product)
        {
            Header header = new Header();
            header.SetTexInHeadSearchBox(product);
            return new SearchPage().GetTextTitleSearchName();
        }

        public string SortProductsByPrice(string text)
        {
            return new SearchPage().ClickedClickViewList().SelectedSortBy(text).GetListProductItems()[0].GetTextProductPrice();
        }

        public string SortProductsByName(string text)
        {
            return new SearchPage().ClickedClickViewList().SelectedSortBy(text).GetListProductItems()[0].GetTextProductName();
        }

        public int SortProductsByReference(string text)
        {
            return new SearchPage().ClickedClickViewList().SelectedSortBy(text).GetListProductItems()[0].GetTextDescriptionProduct().Length;
        }
    }
}
