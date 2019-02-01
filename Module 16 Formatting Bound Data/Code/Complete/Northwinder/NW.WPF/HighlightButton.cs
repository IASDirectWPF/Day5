using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NW.WPF
{
    class HighlightButton : Button
    {
        public static readonly DependencyProperty HighlightProperty;

        static HighlightButton()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata(
                false,                                                          // Default Value
                FrameworkPropertyMetadataOptions.Inherits,                      // Value can be inherited
                new PropertyChangedCallback(OnHighlightChanged)                 // Change Callback
            );

            HighlightProperty = DependencyProperty.Register(
                "Highlight",                                                    // Name of Dependency Property
                typeof(Boolean),                                                // Type of Dependency Property
                typeof(HighlightButton),                                        // Owner of Dependency Property
                metadata                                                        // MetaData from above
            );
        }

        public Boolean Highlight
        {
            get { return (Boolean)GetValue(HighlightProperty); }
            set { SetValue(HighlightProperty, value); }
        }

        public event PropertyChangedEventHandler HighlightChanged;
        private static void OnHighlightChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            HighlightButton highlightButton = (HighlightButton)sender;
            if (highlightButton == null) return;

            if (highlightButton.Highlight) highlightButton.Background = Brushes.Yellow;
            else highlightButton.Background = null;

            highlightButton.HighlightChanged(highlightButton, new PropertyChangedEventArgs("Highlight"));
        }
    }
}
