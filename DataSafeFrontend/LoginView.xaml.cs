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
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class LoginView : Page
    {
        public LoginView(string name)
        {
            InitializeComponent();
            ProfileName = name;
            this.LabelInfoUsernameValue.Content = ProfileName;
        }

        string ProfileName;

        private void MenuItemAbort_Click(object sender, RoutedEventArgs e)
        {
            DataSafeBackend.AppData.PointerMainWindow.Content = new StartupView();
        }

        private void MenuItemLogin_Click(object sender, RoutedEventArgs e)
        {
            ProfileType Profile = new ProfileType();
            Profile = DataSafeBackend.DataOperations.GetProfileFromDisk(ProfileName,passwordBox1.Password);
            if (Profile.ErrorCode == (short)Enumerators.ProfileTypeErrorCodes.NoFailture)
            {
                AppData.ActiveProfile = Profile;
                AppData.PointerMainWindow.Content = new ProfileContentView();
            }
            else
            {
                this.TextBlockErrorDisplay.Text = "";
                switch (Profile.ErrorCode)
                {
                    case (short)Enumerators.ProfileTypeErrorCodes.FileNotFound: this.TextBlockErrorDisplay.Text = "File not Found!";
                        break;
                    case (short)Enumerators.ProfileTypeErrorCodes.ReadFileError: this.TextBlockErrorDisplay.Text = "Could not read the Profilefile!";
                        break;
                    case (short)Enumerators.ProfileTypeErrorCodes.SerializerError: this.TextBlockErrorDisplay.Text = "The Password might be wrong!";
                        break;
                }
            }
        }
    }
}
