namespace MyStoreProject.Data.ShoppingProcess
{
    public interface ISetProductName
    {
        ISetQty SetProductName(string name);
    }

    public interface ISetQty
    {
        ISetDeliveryAddress SetQty(string qty);
    }

    public interface ISetDeliveryAddress
    {
        ISetDeliveryAsBilling SetDeliveryAddress(string address);
    }

    public interface ISetDeliveryAsBilling
    {
        ISetTermsOfService SetDeliveryAsBilling(bool choose);
    }

    public interface ISetTermsOfService
    {
        IShoppingProcessBuild SetTermsOfService(bool choose);
    }

    public interface IShoppingProcessBuild
    {
        IShoppingProcessBuild SetComments(string comments);
        IShoppingProcessBuild SetBillingAddress(string billing);        
        IShoppingProcessBuild SetEmail(string email);        
        IShoppingProcessBuild SetPassword(string pass);        
        IShoppingProcess Build();
    }

    public interface IShoppingProcess
    {
        string GetProductName();
        string GetQty();
        string GetDeliveryAddress();
        bool GetDeliveryAsBilling();
        bool GetTermsOfService();
        string GetComments();
        string GetBillingAddress();
        string GetEmail();
        string GetPassword();
    }

    public interface ICommonInterface : ISetProductName, ISetQty, ISetDeliveryAddress,
        ISetDeliveryAsBilling, ISetTermsOfService, IShoppingProcessBuild, IShoppingProcess
    {
    }
    public class ShoppingProcess : ICommonInterface
    {
        private string _productName;
        private string _qty;
        private string _deliveryAddress;
        private bool _deliveryAsTheBilling;
        private bool _termsOfService;

        // Advanced
        private string _comments;
        private string _billingAddress;
        private string _email;
        private string _password;

     
      
        public static ISetProductName Get()
        {
            return new ShoppingProcess();
        }

        public ISetQty SetProductName(string productName)
        {
            _productName = productName;
            return this;
        }

        public ISetDeliveryAddress SetQty(string qty)
        {
            _qty = qty;
            return this;
        }

        public ISetDeliveryAsBilling SetDeliveryAddress(string deliveryAddress)
        {
            _deliveryAddress = deliveryAddress;
            return this;
        }

        public ISetTermsOfService SetDeliveryAsBilling(bool deliveryAsTheBilling)
        {
            _deliveryAsTheBilling = deliveryAsTheBilling;
            return this;
        }

        public IShoppingProcessBuild SetTermsOfService(bool termsOfService)
        {
            _termsOfService = termsOfService;
            return this;
        }

        public IShoppingProcessBuild SetComments(string comments)
        {
            _comments = comments;
            return this;
        }

        public IShoppingProcessBuild SetBillingAddress(string billingAddress)
        {
            _billingAddress = billingAddress;
            return this;
        }

        public IShoppingProcessBuild SetEmail(string email)
        {
            _email = email;
            return this;
        }
        public IShoppingProcessBuild SetPassword(string password)
        {
            _password = password;
            return this;
        }

        public IShoppingProcess Build()
        {
            return this;
        }

        //Getters
        public string GetProductName()
        {
            return _productName;
        }

        public string  GetQty()
        {
            return _qty;
        }

        public string GetDeliveryAddress()
        {
            return _deliveryAddress;
        }

        public bool GetDeliveryAsBilling()
        {
            return _deliveryAsTheBilling;
        }

        public bool GetTermsOfService()
        {
            return _termsOfService;
        }
        //
        public string GetComments()
        {
            return _comments;
        }       

        public string GetBillingAddress()
        {
            return _billingAddress;
        }       

        public string GetPassword()
        {
            return _password;
        }

        public string GetEmail()
        {
            return _email;
        }
    }
}
