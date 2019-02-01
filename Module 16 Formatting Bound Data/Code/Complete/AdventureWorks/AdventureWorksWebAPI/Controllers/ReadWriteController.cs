using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdventureWorksWebAPI.Controllers
{
    public class ReadWriteController : ApiController
    {
        // GET: api/ReadWrite
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ReadWrite/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ReadWrite
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ReadWrite/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ReadWrite/5
        public void Delete(int id)
        {
        }
    }
}
