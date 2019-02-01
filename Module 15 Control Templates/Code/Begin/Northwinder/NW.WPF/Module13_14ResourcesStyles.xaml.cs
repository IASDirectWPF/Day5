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
    /// Interaction logic for Module13_14ResourcesStyles.xaml
    /// </summary>
    public partial class Module13_14ResourcesStyles : Window
    {
        public Module13_14ResourcesStyles()
        {
            InitializeComponent();
            Application.Current.Resources["SunriseBrush"] = new LinearGradientBrush(Colors.Blue, Colors.Red, 0.5);
        }
    }
}
