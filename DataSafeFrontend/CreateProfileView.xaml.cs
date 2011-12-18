using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataSafeBackend;

namespace DataSafeFrontend
{
    /// <summary>
    /// Interaktionslogik für CreateProfile.xaml
    /// </summary>
    public partial class CreateProfileView : Page
    {
        public CreateProfileView()
        {
            InitializeComponent();
        }

        private void MenuItemCreateProfile_Click(object sender, RoutedEventArgs e)
        {
            GuiHelper.HandelProfileCreation(this);
        }

        private void MenuItemAbort_Click(object sender, RoutedEventArgs e)
        {
            AppData.PointerMainWindow.Content = new StartupView();
        }
    }
}
