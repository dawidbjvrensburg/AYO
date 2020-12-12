using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AyoWebAPI.Models;

namespace AyoWebAPI.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly PostgreSqlContext _context;

        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
        }
        public Response AddUserRecord(User user)
        {
            user.ID = null;
            Response retval = new Response() { Message = "", Status = "Success" };
            try
            {
                _context.users.Add(user);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                retval.Status = "Fail";
                retval.Message = ex.Message;
            }
            return retval; 
        }

        public User GetUserRecord(Models.Login lg)
        {
            return _context.users.FirstOrDefault(t => t.UserName == lg.UserName && t.Password == lg.Password);
        }

        public Response AddConvertRecord(Converter convert)
        {
            convert.ID = null;
            convert.RequestDate = DateTime.Now;
            Response retval = new Response() { Message = convert.Result.ToString(), Status = "Success" };
            try
            {
                _context.converters.Add(convert);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                retval.Status = "Fail";
                retval.Message = ex.Message;
            }
            return retval;
        }
    }
}
