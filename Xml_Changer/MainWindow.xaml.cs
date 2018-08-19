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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Xml_Changer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.SystemKey == Key.LeftAlt)            
                mainMenuBar.Visibility = Visibility.Visible;
        }

        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            if (mainMenuBar.IsVisible && e.Source != mainMenuBar && !IsMenuChildMouseDown(e.Source as FrameworkElement))
            {
                mainMenuBar.Visibility = Visibility.Collapsed;
            }
            base.OnPreviewMouseDown(e);
        }

        private bool IsMenuChildMouseDown(FrameworkElement elem)
        {
            if (elem == null)
                return false;

            DependencyObject parent = elem.Parent;

            if (parent == null)
                return false;
            else
            {
                if (parent == mainMenuBar)
                    return true;

                return IsMenuChildMouseDown(parent as FrameworkElement);
            }
        }
    }
}
