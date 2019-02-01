using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureWorksWinForm
{
    public partial class FormProducts : Form
    {
        public FormProducts()
        {
            InitializeComponent();
        }

        private AdventureWorksDAL.ProductsDAL productsDAL = new AdventureWorksDAL.ProductsDAL();

        private void ClearFields()
        {
            listBoxProducts.ClearSelected();
            textBoxProductID.Clear();
            textBoxName.Clear();
            textBoxColor.Clear();
            textBoxPrice.Clear();
            buttonUpdate.Enabled = false;
            buttonInsert.Enabled = true;
        }
        
        private void LoadProducts()
        {
            listBoxProducts.DataSource = productsDAL.GetProducts();
            ClearFields();
        }
        
        private void FormProducts_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void listBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxProducts.SelectedItem == null) return;

            AdventureWorksDAL.Product selectedItem = 
                ((AdventureWorksDAL.Product)listBoxProducts.SelectedItem);
            textBoxProductID.Text = selectedItem.ProductID.ToString();
            textBoxName.Text = selectedItem.Name.ToString();
            textBoxColor.Text = selectedItem.Color;
            textBoxPrice.Text = selectedItem.Price.ToString();
            buttonUpdate.Enabled = true;
            buttonInsert.Enabled = false;
        }

        private void buttonNewProduct_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            AdventureWorksDAL.Product product = new AdventureWorksDAL.Product
            {
                Name = textBoxName.Text,
                Color = textBoxColor.Text,
                Price = decimal.Parse(textBoxPrice.Text)
            };
            productsDAL.PostProduct(product);
            LoadProducts();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            AdventureWorksDAL.Product product = new AdventureWorksDAL.Product
            {
                ProductID = int.Parse(textBoxProductID.Text),
                Name = textBoxName.Text,
                Color = textBoxColor.Text,
                Price = decimal.Parse(textBoxPrice.Text)
            };
            productsDAL.PutProduct(product.ProductID, product);
            LoadProducts();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int productID = ((AdventureWorksDAL.Product)listBoxProducts.SelectedItem).ProductID;
            productsDAL.DeleteProduct(productID);
            LoadProducts();
        }
    }
}
