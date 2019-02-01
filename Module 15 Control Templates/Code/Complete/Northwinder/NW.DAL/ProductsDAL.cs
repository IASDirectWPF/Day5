using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NW.DAL
{
    public class ProductsDAL
    {
        private HttpClient client = new HttpClient();

        public ProductsDAL()
        {
            client.BaseAddress = new Uri("http://localhost:8000/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IEnumerable<string> GetProducts()
        {
            HttpResponseMessage response = client.GetAsync("api/Products").Result;
            if (!response.IsSuccessStatusCode)
            {
                Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
            return response.Content.ReadAsAsync<IEnumerable<string>>().Result;
        }

        public string GetProduct(int id)
        {
            HttpResponseMessage response = client.GetAsync("api/Products/" + id).Result;
            if (!response.IsSuccessStatusCode)
            {
                Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
            return response.Content.ReadAsAsync<string>().Result;
        }

        public Uri PostProduct(string product)
        {
            HttpResponseMessage response =
                client.PostAsJsonAsync("api/Products", product).Result;
            if (!response.IsSuccessStatusCode)
            {
                Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
            return response.Headers.Location;
        }

        public void PutProduct(int id, string product)
        {
            HttpResponseMessage response =
                client.PutAsJsonAsync("api/Products/" + id, product).Result;
            Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }

        public void DeleteProduct(int id)
        {
            HttpResponseMessage response =
                client.DeleteAsync("api/Products/" + id).Result;
            Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }
    }
}
