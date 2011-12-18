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

namespace DataSafeFrontend
{
    /// <summary>
    /// Interaktionslogik für Startup.xaml
    /// </summary>
    public partial class StartupView : Page
    {
        public StartupView()
        {
            InitializeComponent();
            GuiHelper.UpdateListBoxProfileStartup(this);
            GuiHelper.UpdateMenuStartup(this);
        }

        private void ListBoxProfiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GuiHelper.UpdateMenuStartup(this);
        }

        private void MenuItemNewProfile_Click(object sender, RoutedEventArgs e)
        {
            DataSafeBackend.AppData.PointerMainWindow.Content = new CreateProfileView();
        }

        private void MenuItemLoadProfile_Click(object sender, RoutedEventArgs e)
        {
            if(DataSafeBackend.DataOperations.ChekProfileFileExsists(this.ListBoxProfiles.SelectedItem.ToString()))
            {
                DataSafeBackend.AppData.PointerMainWindow.Content = new LoginView(this.ListBoxProfiles.SelectedItem.ToString());
            }
        }

        private void MenuItemDeleteProfile_Click(object sender, RoutedEventArgs e)
        {
            DataSafeBackend.DataOperations.ProfileFileDelete(this.ListBoxProfiles.SelectedItem.ToString());
            GuiHelper.UpdateListBoxProfileStartup(this);
        }

        private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
