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
    /// Interaction logic for Module11ElementBinding.xaml
    /// </summary>
    public partial class Module11ElementBinding : Window
    {
        public Module11ElementBinding()
        {
            InitializeComponent();

            //BindingOperations.ClearAllBindings(TextBlockSampleText);
            //Binding binding = new Binding();
            //binding.Source = SliderFontSize;
            //binding.Path = new PropertyPath("Value");
            //binding.Mode = BindingMode.TwoWay;
            //TextBlockSampleText.SetBinding(TextBlock.FontSizeProperty, binding);
        }

        private void ButtonSetSlider_Click(object sender, RoutedEventArgs e)
        {
            // Changes Slider with then Changes TextBlock
            SliderFontSize.Value = 50;
        }

        private void ButtonSetTextBlock_Click(object sender, RoutedEventArgs e)
        {
            // Only changes TextBlock not Slider without 2 way binding
            TextBlockSampleText.FontSize = 10;
        }

    }
}
