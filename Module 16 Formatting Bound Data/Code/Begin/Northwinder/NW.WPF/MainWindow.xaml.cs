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
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

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
            MessageBox.Show("New Product Window", "Coming Soon!");
        }

        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (ListBoxProducts.SelectedIndex != -1);
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string product = ListBoxProducts.SelectedItem as string;
            if (product != null)
            {
                MessageBox.Show($"Edit Window - {product}", "Coming Soon!");
            }
        }
        private void CustomersListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ApplicationCommands.Open.Execute(null, this);
        }

        private ProductsDAL productsDAL = new ProductsDAL();

        private void LoadProducts()
        {
            ListBoxProducts.ItemsSource = productsDAL.GetProducts();
        }

    }
}
