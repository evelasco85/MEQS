using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MessageEmotionQuerySystem.WebApi.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public string HelloWorld()
        {
            return "hello world";
        }
    }
}
