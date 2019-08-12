using MyStoreProject.Tools;
using System.Collections.Generic;

namespace MyStoreProject.Data.User
{
    public interface ISetFirstName
    {
        ISetLastName SetFirstName(string firstName);
    }

    public interface ISetLastName
    {
        ISetPassword SetLastName(string lastName);
    }

    public interface ISetPassword
    {
        ISetAddress1 SetPassword(string password);
    }

    public interface ISetAddress1
    {
        ISetCountry SetAddress1(string address1);
    }

    public interface ISetCountry
    {
        ISetCity SetCountry(string country);
    }

    public interface ISetCity
    {
        ISetPostalCode SetCity(string city);
    }

    public interface ISetPostalCode
    {
        ISetState SetPostalCode(string postalCode);
    }

    public interface ISetState
    {
        ISetHomePhone SetState(string state);
    }

    public interface ISetHomePhone
    {
        IUserBuild SetHomePhone(string homePhone);
    }

    public interface IUserBuild
    {
        IUserBuild SetSex(string sex);
        IUserBuild SetEmail(string email);
        IUserBuild SetCompany(string company);
        IUserBuild SetAddInformation(string addInformation);
        IUserBuild SetMobilePhone(string mobilePhone);
        IUserBuild SetAddressAdd(string addressAdd);
        IUserBuild SetDateOfBirth(string dateOfBirth);
        IUserBuild SetSingNewsletter(bool singNewsletter);
        IUserBuild SetSpecialOffers(bool specialOffers);
        IUser Build();
    }

    public interface IUser
    {
        string GetFirstName();
        string GetLastName();
        string GetPassword();
        string GetAddress1();
        string GetCountry();
        string GetCity();
        string GetPostalCode();
        string GetState();
        string GetHomePhone();
        string GetSex();
        string GetEmail();
        string GetCompany();
        string GetAddInformation();
        string GetMobilePhone();
        string GetAddressAdd();
        string GetDateOfBirth();
        bool GetSingNewsletter();
        bool GetSpecialOffers();
    }

    public class User : ISetFirstName, ISetLastName, ISetPassword, ISetAddress1, ISetCountry,
                        ISetCity, ISetPostalCode, ISetState,
                        ISetHomePhone, IUserBuild, IUser
    {
        private string _firstName;
        private string _lastName;
        private string _password;
        private string _address1;
        private string _country;
        private string _city;
        private string _postalCode;
        private string _state;
        private string _homePhone;

        // Advanced
        private string _sex;
        private string _email;
        private string _company;
        private string _addInformation;
        private string _mobilePhone;
        private string _addressAdd;
        private string _dateOfBirth;
        private bool _singNewsletter;
        private bool _specialOffers;

        private User()
        { }


        //Builder
        public static ISetFirstName Get()
        {
            return new User();
        }

        public ISetLastName SetFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public ISetPassword SetLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public ISetAddress1 SetPassword(string password)
        {
            _password = password;
            return this;
        }

        public ISetCountry SetAddress1(string address1)
        {
            _address1 = address1;
            return this;
        }

        public ISetCity SetCountry(string country)
        {
            _country = country;
            return this;
        }

        public ISetPostalCode SetCity(string city)
        {
            _city = city;
            return this;
        }

        public ISetState SetPostalCode(string postalCode)
        {
            _postalCode = postalCode;
            return this;
        }

        public ISetHomePhone SetState(string state)
        {
            _state = state;
            return this;
        }

        public IUserBuild SetHomePhone(string homePhone)
        {
            _homePhone = homePhone;
            return this;
        }

        // Advanced
        public IUserBuild SetSex(string sex)
        {
            _sex = sex;
            return this;
        }

        public IUserBuild SetEmail(string email)
        {
            _email = email;
            return this;
        }

        public IUserBuild SetCompany(string company)
        {
            _company = company;
            return this;
        }

        public IUserBuild SetAddInformation(string addInformation)
        {
            _addInformation = addInformation;
            return this;
        }

        public IUserBuild SetMobilePhone(string mobilePhone)
        {
            _mobilePhone = mobilePhone;
            return this;
        }

        public IUserBuild SetAddressAdd(string addressAdd)
        {
            _addressAdd = addressAdd;
            return this;
        }

        public IUserBuild SetDateOfBirth(string dateOfBirth)
        {
            _dateOfBirth = dateOfBirth;
            return this;
        }

        public IUserBuild SetSingNewsletter(bool singNewsletter)
        {
            _singNewsletter = singNewsletter;
            return this;
        }

        public IUserBuild SetSpecialOffers(bool specialOffers)
        {
            _specialOffers = specialOffers;
            return this;
        }
        //Builder


        public IUser Build()
        {
            return this;
        }

        ////Getters
        ///
        public string GetFirstName()
        {
            return _firstName;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public string GetPassword()
        {
            return _password;
        }

        public string GetAddress1()
        {
            return _address1;
        }

        public string GetCountry()
        {
            return _country;
        }

        public string GetCity()
        {
            return _city;
        }

        public string GetPostalCode()
        {
            return _postalCode;
        }

        public string GetState()
        {
            return _state;
        }

        public string GetHomePhone()
        {
            return _homePhone;
        }

        // Advanced
        public string GetSex()
        {
            return _sex;
        }

        public string GetEmail()
        {
            return _email;
        }

        public string GetCompany()
        {
            return _company;

        }

        public string GetAddInformation()
        {
            return _addInformation;        
        }

        public string GetMobilePhone()
        {
            return _mobilePhone;

        }

        public string GetAddressAdd()
        {
            return _addressAdd;
        }

        public string GetDateOfBirth()
        {
            return _dateOfBirth;
        }

        public bool GetSingNewsletter()
        {
            return _singNewsletter;
        }

        public bool GetSpecialOffers()
        {
            return _specialOffers;
        }

        // Static Factory

        public static IList<IUser> GetAllUsers(AExternalReader externalData)
        {
            IList<IUser> users = new List<IUser>();
            foreach (IList<string> row in externalData.GetAllCells())
            {
                if (row[2].ToLower().Equals("password")
                        && row[7].ToLower().Equals("state"))
                {
                    continue;
                }

                users.Add(Get()
                        .SetFirstName(row[0])
                        .SetLastName(row[1])
                        .SetPassword(row[2])
                        .SetAddress1(row[3])
                        .SetCountry(row[4])
                        .SetCity(row[5])
                        .SetPostalCode(row[6])
                        .SetState(row[7])
                        .SetHomePhone(row[8])
                        .SetSex(row[9])
                        .SetMobilePhone(row[10])
                        .SetSpecialOffers(row[11].ToLower().Equals("true"))
                        .SetSingNewsletter(row[12].ToLower().Equals("true"))
                        .SetDateOfBirth(row[13].Remove(10))
                        .SetEmail(row[14])
                        .Build());
            }
            return users;
        }
    }
}
