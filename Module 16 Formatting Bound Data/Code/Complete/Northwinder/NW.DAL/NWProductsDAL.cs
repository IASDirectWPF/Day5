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
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
    }

    public class NWProductsDAL
    {
        private HttpClient client = new HttpClient();

        public NWProductsDAL()
        {
            client.BaseAddress = new Uri("http://localhost:8000/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IEnumerable<Product> GetProducts()
        {
            HttpResponseMessage response = client.GetAsync("api/NWProducts").Result;
            if (!response.IsSuccessStatusCode)
            {
                Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
            return response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
        }

        public Product GetProduct(int id)
        {
            HttpResponseMessage response = client.GetAsync("api/NWProducts/" + id).Result;
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
                client.PostAsJsonAsync("api/NWProducts", product).Result;
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
                client.PutAsJsonAsync("api/NWProducts/" + id, product).Result;
            Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }

        public void DeleteProduct(int id)
        {
            HttpResponseMessage response =
                client.DeleteAsync("api/NWProducts/" + id).Result;
            Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }
    }
}
