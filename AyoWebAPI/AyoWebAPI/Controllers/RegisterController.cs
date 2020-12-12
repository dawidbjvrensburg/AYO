using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AyoWebAPI.DataAccess;
using AyoWebAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AyoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class RegisterController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;
        public RegisterController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpPost]
        public Response Post(User user)
        {
            //Login lg = new Login();
            Response retval = _dataAccessProvider.AddUserRecord(user);
            return retval;
        }
    }
}