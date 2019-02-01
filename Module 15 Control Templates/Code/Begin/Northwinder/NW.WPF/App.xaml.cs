using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NW.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //MessageBox.Show($"# of Command Line Arguments = {e.Args.Count()}");
            //MessageBox.Show($"# of Windows = {Application.Current.Windows.Count}");
        }
    }

}
