using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdventureWorksWebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private static List<string> products = new List<string>();
        static ProductsController()
        {
            products.Add("Widget");
            products.Add("DooHickey");
            products.Add("Thingofabob");
        }

        public IEnumerable<string> Get()
        {
            return products;
        }

        public HttpResponseMessage Get(int id)
        {
            if (id < 0 || id >= products.Count)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product Not Found");
            }
            return Request.CreateResponse<string>(HttpStatusCode.OK, products[id]);

        }

        //public IHttpActionResult Get(int id)
        //{
        //    if (id < 0 || id >= products.Count)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(products[id]);
        //}

        public HttpResponseMessage Post([FromBody]string product)
        {
            products.Add(product);
            var message = Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = 
                new Uri(Request.RequestUri +
                    (Request.RequestUri.ToString().EndsWith("/") ? "" : "/") + // Ensure trailing slash
                    (products.Count - 1).ToString());
            return message;
        }

        //public IHttpActionResult Post([FromBody]string product)
        //{
        //    products.Add(product);
        //    Uri location = new Uri(Request.RequestUri +
        //        (Request.RequestUri.ToString().EndsWith("/") ? "" : "/") + // Ensure trailing slash
        //        (products.Count - 1).ToString());
        //    return Created<string>(location, product);
        //}
        
        public void Put(int id, [FromBody]string product)
        {
            if (id < 0 || id >= products.Count)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            } 
            products[id] = product;
        }

        public void Delete(int id)
        {
            if (id < 0 || id >= products.Count)
            {
                var message = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No product with ID = {0}", id)),
                    ReasonPhrase = "Product ID Not Found"
                };
                throw new HttpResponseException(message);
            }
            products.RemoveAt(id);
        }
    }
}
