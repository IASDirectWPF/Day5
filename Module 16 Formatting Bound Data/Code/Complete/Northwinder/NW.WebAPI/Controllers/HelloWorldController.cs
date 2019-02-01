using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NW.WebAPI.Controllers
{
    public class HelloWorldController : ApiController
    {
        // GET: api/HelloWorld
        public string Get()
        {
            return "Get: Hello World";
        }

        // GET: api/HelloWorld/5
        public string Get(int id)
        {
            return "Get: " + id;
        }

        // POST: api/HelloWorld
        public string Post([FromBody]string value)
        {
            return "Post: " + value;
        }

        // PUT: api/HelloWorld/5
        public string Put(int id, [FromBody]string value)
        {
            return "Put: " + value + " @ " + id;
        }

        // DELETE: api/HelloWorld/5
        public string Delete(int id)
        {
            return "Delete: " + id;
        }
    }
}
