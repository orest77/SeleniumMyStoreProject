using MyStoreProject.Data.ShoppingProcess;
using MyStoreProject.Pages.Body.ProductPage;
using MyStoreProject.Pages.Body.ShoppingCartPages;
using MyStoreProject.Pages.Body.TopsPages;
using MyStoreProject.Pages.Body.TshirtsPages;
using MyStoreProject.Pages.Body.WomenPages;
using MyStoreProject.Pages.Header;

namespace MyStoreProject.Logic
{
    class AddToCartMethods
    {
      
        public WomenPage GoToHeaderWomenPage()
        {
            LowerBar lowerBar = new LowerBar();
            return lowerBar.ClickedOnWomenButton();
        }

        public TopsPage GoToHeaderWomenAndTops()
        {
            LowerBar lowerBar = new LowerBar();
            lowerBar.HoldWomenButton();
            HeaderWomen headerWomen = new HeaderWomen();
            return headerWomen.ClickTopsButton();
        }

        public string GoToHeaderWomenTopsPage(IShoppingProcess bought)
        {
            return GoToHeaderWomenAndTops().GetTextProductName(bought.GetProductName());
        }

        public TshirtsPage GoToTshirtsPage()
        {
            LowerBar lowerBar = new LowerBar();
            lowerBar.ClickTshirtsButton();            
            return new TshirtsPage();
        }    
        
        public void AddCartToProduct()
        {
            TopsPage topPage = new TopsPage();
            topPage.GetYourProductItem("Blouse").ClickProductName();
        }

        public string GetStingProductName(IShoppingProcess bought)
        {
            return new TopsPage().GetTextProductName(bought.GetProductName());
        }

        public bool IsDisplayedProductsName(IShoppingProcess bought)
        {
            return new TopsPage().IsDisplayedProductName(bought.GetProductName());
        }

        public SuccessfullyAddToCart ClickOnAddToCart(IShoppingProcess bought)
        {
            TopsPage topPage = new TopsPage();
            topPage.ClickAddToCart(bought.GetProductName());
            return new SuccessfullyAddToCart();
        }

        public string ProductSuccessfulAddToCart(IShoppingProcess bought)
        {
            ClickOnAddToCart(bought);
            return new SuccessfullyAddToCart().GetTextTitlePage();
        }

        public  bool IsDisplayedSuccessfulAddToCart(IShoppingProcess bought)
        {
            ClickOnAddToCart(bought);
            return new SuccessfullyAddToCart().IsDisplayTitlePage();
        }

        public TopsPage ContinueShoppingButton()
        {
            new SuccessfullyAddToCart().ClickContinueShoppingButton();
            return new TopsPage();
        }


        public ShoppingCart ClickProceedToCheckout()
        {
            return new SuccessfullyAddToCart().ClickProceedCheckoutButton();
        }

        public string CheckAddToCartText()
        {
            return new Header().GetHeadCartBoxTex();
        }

        public string ClickingButtonContinueShopping()
        {
            ContinueShoppingButton();
            return CheckAddToCartText();
        }
    }
}
