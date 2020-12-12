using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AyoWebAPI.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AyoWebAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace AyoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UserController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;
        public UserController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
           
            return new string[] { "value1", "value2" };
        }

        // GET api/values
        [HttpPost]
        public User Post(Login lg)
        {
            //Login lg = new Login();
            User retval = _dataAccessProvider.GetUserRecord(lg);
            return retval;
        }
    }
}