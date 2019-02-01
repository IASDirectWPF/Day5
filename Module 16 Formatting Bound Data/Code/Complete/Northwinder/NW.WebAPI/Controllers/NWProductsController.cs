using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System.Web.Http.Description;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace NW.WebAPI.Controllers
{
    public class Product
    {
        public int ProductID;
        public string ProductName;
        public decimal UnitPrice;
        public short UnitsInStock;
    }

    public class NWProductsController: ApiController
    {
        private static SqlConnection northwindSqlConnection;
        private static DataSet northwindDataSet = new DataSet("Northwind");
        private static SqlDataAdapter northWindDataAdapter;

        // Default Static CTor to populate collection with some test data
        static NWProductsController()
        {
            PopulateNorthwindDataSet();
        }

        private static void PopulateNorthwindDataSet()
        {
            string northwindConnectionString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
            northwindSqlConnection = new SqlConnection(northwindConnectionString);
            northWindDataAdapter = new SqlDataAdapter("select * from dbo.Products", northwindSqlConnection);
            SqlCommandBuilder builder = new SqlCommandBuilder(northWindDataAdapter);
            northWindDataAdapter.Fill(northwindDataSet, "Products");

            northwindDataSet.Tables["Products"].PrimaryKey =
                new DataColumn[] { northwindDataSet.Tables["Products"].Columns["ProductID"] };
            northwindDataSet.Tables["Products"].Columns["ProductID"].AutoIncrement = true;
            int autoIncrementSeed = (int)northwindDataSet.Tables["Products"].AsEnumerable().Max(row => row["ProductID"]);
            northwindDataSet.Tables["Products"].Columns["ProductID"].AutoIncrementSeed = autoIncrementSeed + 1;
            northwindDataSet.Tables["Products"].Columns["ProductID"].AutoIncrementStep = 1;
        }

        private IEnumerable<Product> ConvertDataTableToList()
        {
            var rowData = northwindDataSet.Tables["Products"].AsEnumerable().Select(
                r => new Product()
                {
                    ProductID = r.Field<int>("ProductID"),
                    ProductName = r.Field<string>("ProductName"),
                    UnitPrice = r.Field<decimal>("UnitPrice"),
                    UnitsInStock = r.Field<short>("UnitsInStock"),
                }
            );
            return rowData.ToList();
        }

        private Product ConvertRowToProduct(DataRow productRow)
        {
            Product product = new Product()
            {
                ProductID = (int)productRow["ProductID"],
                ProductName = (string)productRow["ProductName"],
                UnitPrice = (decimal)productRow["UnitPrice"],
                UnitsInStock = (short)productRow["UnitsInStock"]
            };
            return product;
        }

        private void ConvertProductToRow(Product product, DataRow productRow)
        {
            productRow["ProductName"] = product.ProductName;
            productRow["UnitPrice"] = product.UnitPrice;
            productRow["UnitsInStock"] = product.UnitsInStock;
        }

        // Return products collection
        public IEnumerable<Product> Get()
        {
            return ConvertDataTableToList();
        }

        // return IHttpActionResult
        [ResponseType(typeof(Product))]                  // Optional, helpful for API Description
        public IHttpActionResult Get(int id)
        {
            DataRow productRow = northwindDataSet.Tables["Products"].Rows.Find(id);
            if (productRow == null) return NotFound();

            return Ok(ConvertRowToProduct(productRow));
        }

        // Simple Type, Force to [FromBody]
        public IHttpActionResult Post(Product product)
        {
            DataRow newProductRow = northwindDataSet.Tables["Products"].NewRow();
            ConvertProductToRow(product, newProductRow);

            northwindDataSet.Tables["Products"].Rows.Add(newProductRow);
            northWindDataAdapter.Update(northwindDataSet, "Products");

            product.ProductID = (int)newProductRow["ProductID"];

            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }

        public IHttpActionResult Put(int id, Product product)
        {
            DataRow productRow = northwindDataSet.Tables["Products"].Rows.Find(id);
            if (productRow == null) return NotFound();

            ConvertProductToRow(product, productRow);
            northWindDataAdapter.Update(northwindDataSet, "Products");

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Delete(int id)
        {
            DataRow productRow = northwindDataSet.Tables["Products"].Rows.Find(id);
            if (productRow == null) return NotFound();

            northwindDataSet.Tables["Products"].Rows.Remove(productRow);
            northWindDataAdapter.Update(northwindDataSet, "Products");

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}