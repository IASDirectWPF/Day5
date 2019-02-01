using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksDAL
{
    public class ProductsDAL
    {
        private HttpClient client = new HttpClient();

        public ProductsDAL()
        {
            client.BaseAddress = new Uri("http://localhost:2491/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IEnumerable<Product> GetProducts()
        {
            HttpResponseMessage response = client.GetAsync("api/AWProducts").Result; 
            if (!response.IsSuccessStatusCode)
            {
                Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
            return response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
        }

        public Product GetProduct(int id)
        {
            HttpResponseMessage response = client.GetAsync("api/Products/" + id).Result;
            if (!response.IsSuccessStatusCode)
            {
                Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
            return response.Content.ReadAsAsync<Product>().Result;
        }

        public Uri PostProduct(Product product)
        {
            HttpResponseMessage response =
                client.PostAsJsonAsync("api/AWProducts", product).Result;
            if (!response.IsSuccessStatusCode)
            {
                Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
            return response.Headers.Location;
        }

        public void PutProduct(int id, Product product)
        {
            HttpResponseMessage response =
                client.PutAsJsonAsync("api/AWProducts/" + id, product).Result;
            Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }

        public void DeleteProduct(int id)
        {
            HttpResponseMessage response =
                client.DeleteAsync("api/AWProducts/" + id).Result;
            Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }
    }
}
