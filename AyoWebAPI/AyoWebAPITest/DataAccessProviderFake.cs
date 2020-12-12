using AyoWebAPI.DataAccess;
using AyoWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AyoWebAPITest
{
    class DataAccessProviderFake : IDataAccessProvider
    {
        private readonly List<User> _users;
        private readonly List<Converter> _converters;
        private readonly Login _login;

        public DataAccessProviderFake()
        {
            _users = new List<User>() {
                 new User() { Email = "fakeemail@fake.com", ID = 999999, Name = "Fake", Password = "fakepassword", UserName = "fakeusername" }
            };
            _converters = new List<Converter>() {
                new Converter(){From ="FakeFrom", To="FakeTo", ID=999999, FromUnit="FakeFromUnit", ToUnit="FakeToUnit", RequestDate=DateTime.Now, Result=9999999.9999999, UnitValue="FakeUnitValue"}
            };
            _login = new Login() { UserName="fakeusername", Password="fakepassword"};
        }

        public Response AddConvertRecord(Converter convert)
        {
            _converters.Add(convert);
            return new Response();
        }

        public Response AddUserRecord(User user)
        {
            _users.Add(user);
            return new Response();
        }

        public User GetUserRecord(Login lg)
        {
            User retval = null;
            foreach(User u in  _users)
            {
                if(u.UserName == lg.UserName && u.Password == lg.Password)
                {
                    retval = u;
                    break;
                }
            }
            return retval;
        }
    }
}
