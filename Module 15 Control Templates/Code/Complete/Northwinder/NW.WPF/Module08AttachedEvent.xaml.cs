using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace NW.WPF
{
    /// <summary>
    /// Interaction logic for Module08AttachedEvent.xaml
    /// </summary>
    public partial class Module08AttachedEvent : Window
    {
        public Module08AttachedEvent()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(e.Source.ToString());
        }

    }
}
