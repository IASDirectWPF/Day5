using NW.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NW.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NWProductsDAL nwProductsDAL = new NWProductsDAL();

        public MainWindow()
        {
            InitializeComponent();

            CommandBinding OpenCommand = new CommandBinding(ApplicationCommands.Open);
            OpenCommand.CanExecute += OpenCommand_CanExecute;
            OpenCommand.Executed += OpenCommand_Executed;
            this.CommandBindings.Add(OpenCommand);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadProducts();
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Product product = new Product();
            new ProductWindow(product).ShowDialog();
            nwProductsDAL.PostProduct(product);
            ListBoxProducts.ItemsSource = nwProductsDAL.GetProducts();
        }

        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (ListBoxProducts.SelectedIndex != -1);
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Product product = ListBoxProducts.SelectedItem as Product;
            if (product != null)
            {
                new ProductWindow(product).ShowDialog();
                nwProductsDAL.PutProduct(product.ProductID, product);
            }
        }
        private void CustomersListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ApplicationCommands.Open.Execute(null, this);
        }

        private void LoadProducts()
        {
            ListBoxProducts.ItemsSource = nwProductsDAL.GetProducts();
            ListBoxProducts.DisplayMemberPath = "ProductName";
        }

    }
}
