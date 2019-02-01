using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System.Web.Http.Description;

namespace NW.WebAPI.Controllers
{
    public class ProductsController: ApiController
    {
        // Configure products List of strings
        // Static because of the async nature of ApiControllers
        private static List<string> products = new List<string>();

        // Default Static CTor to populate collection with some test data
        static ProductsController()
        {
            products.Add("IPA");
            products.Add("Lager");
            products.Add("Sour");
        }

        // Return products collection
        public IEnumerable<string> Get()
        {
            return products;
        }

        // return void
        //public void Get(int id) { }

        // return HttpResponseMessage
        //[ResponseType(typeof(string))]                  // Optional, helpful for API Description
        //public HttpResponseMessage Get(int id)
        //{
        //    if (id < 0 || id >= products.Count)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //        //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product Not Found");
        //    }
        //    return Request.CreateResponse<string>(HttpStatusCode.OK, products[id]);
        //}

        // return IHttpActionResult
        //[ResponseType(typeof(string))]                  // Optional, helpful for API Description
        //public IHttpActionResult Get(int id)
        //{
        //    if (id < 0 || id >= products.Count)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(products[id]);
        //}

        // Other return type
        public string Get(int id)
        {
            if (id < 0 || id >= products.Count)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return products[id];
        }

        // Simple Type, Defaults to [FromUri]
        //public IHttpActionResult Post(string product)
        //{
        //    products.Add(product);

        //    // Create the Location header the long way
        //    string uri = Request.RequestUri.GetLeftPart(UriPartial.Path);               // Removes Query String if Present
        //    Uri location = new Uri(uri +
        //        (uri.EndsWith("/") ? "" : "/") +                                        // Ensure trailing slash
        //        (products.Count - 1).ToString());                                       // Add latest product position
        //    return Created<string>(location, product);
        //}

        // Simple Type, Force to [FromBody]
        public IHttpActionResult Post([FromBody]string product)
        {
            products.Add(product);

            // Easier way to return Location header
            return CreatedAtRoute("DefaultApi", new { id = products.Count - 1 }, product);
        }

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