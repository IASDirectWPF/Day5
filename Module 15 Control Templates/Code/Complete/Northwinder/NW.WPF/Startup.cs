using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NW.WPF
{
    class Startup
    {
        [STAThread()]
        static void Main(String[] args)
        {
            MessageBox.Show(String.Format("# of Command Line Arguments = {0}", args.Count()));

            Application app = new Application();
            MainWindow mainWindow = new MainWindow();
            app.Run(mainWindow);
        }
    }
}
