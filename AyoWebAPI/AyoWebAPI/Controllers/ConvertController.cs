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
    public class ConvertController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;
        public ConvertController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpPost]
        public Response Post(Models.Convert convert)
        {
            ConvertCalc c = new ConvertCalc();
            Response retval = _dataAccessProvider.AddConvertRecord(c.Create(convert));
            return retval;
        }
    }
}