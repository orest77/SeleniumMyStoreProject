namespace MyStoreProject.Data.ShoppingProcess
{
    public class ShoppingProcessRepository
    {
        private  static volatile ShoppingProcessRepository _instance;
        private static readonly object LookingObject = new object();

        private ShoppingProcessRepository()
        { }

        public static ShoppingProcessRepository Get()
        {
            if (_instance == null)
            {
                lock (LookingObject)
                {
                    if (_instance == null)
                    {
                        _instance = new ShoppingProcessRepository();
                    }
                }
            }
            return _instance;
        }

        public IShoppingProcess Choose()
        {
            return ShoppingProcess.Get()
                .SetProductName("Blouse")
                .SetQty("2")
                .SetDeliveryAddress("Dj.Washington street")
                .SetDeliveryAsBilling(true)
                .SetTermsOfService(true)
                .SetEmail("testing6@gmail.com")
                .SetPassword("qwerty")
                .Build();
        }
    }
}
