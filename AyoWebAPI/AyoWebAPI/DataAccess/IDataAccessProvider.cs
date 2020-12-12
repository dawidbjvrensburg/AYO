using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AyoWebAPI.DataAccess
{
    public interface IDataAccessProvider
    {
        Models.Response AddUserRecord(Models.User user);
        Models.User GetUserRecord(Models.Login lg);

        Models.Response AddConvertRecord(Models.Converter convert);
    }
}
