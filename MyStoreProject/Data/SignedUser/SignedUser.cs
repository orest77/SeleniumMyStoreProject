namespace MyStoreProject.Data.SignedUser
{
    public interface ISetEmail
    {
        ISetPassword SetEmail(string email);
    }

    public interface ISetPassword
    {
        ISignedUserBuild SetPassword(string firstname);
    }

    public interface ISignedUserBuild
    {
        ISignedUser Build();
    }

    public interface ISignedUser
    {
        string GetEmail();
        string GetPassword();
    }


    public class SignedUser : ISetEmail, ISetPassword, ISignedUserBuild, ISignedUser
    {
        private string _email;
        private string _password;

        private SignedUser()
        { }


        public static ISetEmail Get()
        {
            return new SignedUser();
        }

       

        public ISetPassword SetEmail(string email)
        {
            _email = email;
            return this;
        }

        public ISignedUserBuild SetPassword(string password)
        {
            _password = password;
            return this;
        }

        public ISignedUser Build()
        {
            return this;
        }
      

        //Getters 
        public string GetEmail()
        {
            return _email;
        }

        public string GetPassword()
        {
            return _password;
        }
    }
}
