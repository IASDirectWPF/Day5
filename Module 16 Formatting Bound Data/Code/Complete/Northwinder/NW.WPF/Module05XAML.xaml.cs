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
    /// Interaction logic for Module05XAML.xaml
    /// </summary>
    public partial class Module05XAML : Window
    {
        public Module05XAML()
        {
            InitializeComponent();
            this.TextBoxHasName.Text = "I have a name!";
        }
    }
}
