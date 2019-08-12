namespace MyStoreProject.Data.SignedUser
{
    public class SignedUserRepository
    {
        private static volatile SignedUserRepository _instance;
        private static readonly object LookingObject = new object();

        private SignedUserRepository ()
        { }
        public static SignedUserRepository Get()
        {
            if (_instance == null)
            {
                lock (LookingObject)
                {
                    if (_instance == null)
                    {
                        _instance = new SignedUserRepository();
                    }
                }
            }
            return _instance;
        }

        public ISignedUser Login()
        {
            return SignedUser.Get()
                .SetEmail("testing6@gmail.com")
                .SetPassword("qwerty")
                .Build();
        }
    }
}
