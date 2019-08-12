using MyStoreProject.Tools;
using System;
using System.Collections.Generic;

namespace MyStoreProject.Data.User
{
    public sealed class UserRepository
    {
        private static volatile  UserRepository _instance;
        private static readonly object LookingObject = new object();

        private UserRepository()
        { }

        public static UserRepository Get()
        {
            if (_instance == null)
            {
                lock (LookingObject)
                {
                    if (_instance ==null)
                    {
                        _instance = new UserRepository();
                    }
                }
            }
            return _instance;
        }

        public IUser Registered()
        {
            return User.Get()
                .SetFirstName("MichelS")
                .SetLastName("PythonR")
                .SetPassword("qwerty")
                .SetAddress1("Dj.Washington streets")
                .SetCountry("United States")
                .SetCity("California")
                .SetPostalCode("77755")
                .SetState("California")
                .SetHomePhone("(844) 723-0252")
                .SetSex("Mr.")
                .SetMobilePhone("415-845-1600")
                .SetSpecialOffers(true)
                .SetSingNewsletter(true)
                .SetDateOfBirth("11/12/1992")
                .SetEmail("testing" +$"{DateTime.Now.Minute}"+"@mail.com")
                .SetCompany("GlobalCompany")
                .Build();
        }

        public IUser Invalid()
        {
            return User.Get()
                .SetFirstName("$%656")
                .SetLastName("*#4@@")
                .SetPassword("    ")
                .SetAddress1("#@#$#@#")
                .SetCountry("########")
                .SetCity("2#@")
                .SetPostalCode("!@#$")
                .SetState("#$%#$%")
                .SetHomePhone("(erg)erg (!#-0252")
                .SetSex("(!@#")
                .SetMobilePhone("sdd")
                .SetSpecialOffers(true)
                .SetSingNewsletter(true)
                .SetDateOfBirth("dc/asda/sd")
                .SetEmail("a2$%$#####@.com")
                .Build();
        }


        public IList<IUser> FromExcel()
        {
            return FromExcel("ExistUsers.xlsx");
        }

        public IList<IUser> FromExcel(string filename)
        {
            return User.GetAllUsers(new ExcelReader(filename));
        }
    }
}
