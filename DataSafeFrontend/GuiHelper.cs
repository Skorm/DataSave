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
    class GuiHelper
    {
        #region fuctions

        private List<MenuItem> CreateMenuItemCollection()
        {
            List<MenuItem> MenuItems = new List<MenuItem>();
            MenuItems.Add(CreateMenuEntryProfile());
            MenuItems.Add(CreateMenuEntryHelp());
            return MenuItems;
        }

        private MenuItem CreateMenuEntryHelp()
        {
            MenuItem menuItem = new MenuItem();
            menuItem.Name = "Help";
            return menuItem;
        }

        private MenuItem CreateMenuEntryProfile()
        {
            MenuItem MenuItemTopLevel = new MenuItem();
            if (AppData.ProfileIsLoaded)
            {
                MenuItemTopLevel.Name = AppData.ActiveProfile.ProfileName;
            }
            else
            {
                MenuItemTopLevel.Name = "No Profile";
            }
            int ProfileCount = 0;

            foreach (string entry in DataOperations.GetNamesOfAvaibleProfiles())
            {
                ProfileCount++;
                MenuItem MenuItemSecondLevel = new MenuItem();
                if (AppData.ProfileIsLoaded)
                {
                    MenuItemSecondLevel.IsEnabled = false;
                }
                MenuItemSecondLevel.Header = entry;
                MenuItemSecondLevel.Name = "profileButton" + ProfileCount;
                MenuItemSecondLevel.Click += new RoutedEventHandler(MenuItemSecondLevel_Click);
                MenuItemTopLevel.Items.Add(MenuItemSecondLevel);
            }
            MenuItemTopLevel.Items.Add(CreateMenuItemSaveProfile());
            return MenuItemTopLevel;

        }

        private MenuItem CreateMenuItemSaveProfile()
        {
            MenuItem MenuItemSaveProfile = new MenuItem();
            MenuItemSaveProfile.Header = "Save Profile";
            MenuItemSaveProfile.Click += new RoutedEventHandler(MenuItemSaveProfile_Click);
            if (AppData.ProfileIsLoaded != true)
            {
                MenuItemSaveProfile.IsEnabled = false;
            }
            return MenuItemSaveProfile;
        }

        #endregion

        #region functions - Starup

        public static void UpdateMenuStartup(StartupView sender)
        {
            if (CheckIfProfileIsSelectedStarup(sender))
            {
                GuiStateProfileSelected(sender);
            }
            else
            {
                GuiStateNoProfileSelected(sender);
            }
        }

        public static bool CheckIfProfileIsSelectedStarup(StartupView sender)
        {
            return sender.ListBoxProfiles.SelectedIndex != -1;
        }

        public static void UpdateListBoxProfileStartup(StartupView sender)
        {
            sender.ListBoxProfiles.Items.Clear();
            try
            {
                List<string> ListOfProfileNames = new List<string>();
                ListOfProfileNames = DataOperations.GetNamesOfAvaibleProfiles();
                foreach (string name in ListOfProfileNames)
                {
                    sender.ListBoxProfiles.Items.Add(name);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Exception while refreshing Profilelist " + e);
            }
        }

        #endregion

        #region GuiSate - Startup

        private static void GuiStateNoProfileSelected(StartupView sender)
        {
            sender.MenuItemLoadProfile.IsEnabled = false;
            sender.MenuItemDeleteProfile.IsEnabled = false;
        }

        private static void GuiStateProfileSelected(StartupView sender)
        {
            sender.MenuItemLoadProfile.IsEnabled = true;
            sender.MenuItemDeleteProfile.IsEnabled = true;
        }
        
        #endregion

        #region GuiState - Create Profile

        public static void HandelProfileCreation(CreateProfileView sender)
        {
            sender.TextBlockErrorDisplay.Text = "";
            bool NoFailture = true;

            if (DataOperations.ChekProfileFileExsists(sender.TextBoxUserInputProfileName.Text))
            {
                sender.TextBlockErrorDisplay.Text += "Profile already exist!\n";
                NoFailture = false;
            }


            if (sender.TextBoxUserInputProfileName.Text.Count() <= 0)
            {
                sender.TextBlockErrorDisplay.Text += "Your Profilename have to be longer than 0 Charakters!\n";
                NoFailture = false;
            }


            if (!DataOperations.ComparePasswords(sender.PasswordBoxUserInputPassword.Password, sender.PasswordBoxUserInputPasswordRepate.Password))
            {
                sender.TextBlockErrorDisplay.Text += "The Passwords are not the same!\n";
                NoFailture = false;
            }

            if (NoFailture)
            {
                ProfileType Profile = new ProfileType();
                Profile.ProfileName = sender.TextBoxUserInputProfileName.Text;
                DataOperations.WriteProfileToDisk(Profile, sender.PasswordBoxUserInputPassword.Password);
                AppData.PointerMainWindow.Content = new StartupView();
            }
        }

        #endregion 

        #region Eventhandler

        void MenuItemSaveProfile_Click(object sender, EventArgs e)
        {

        }

        void MenuItemSecondLevel_Click(object sender, EventArgs e)
        {

        }

        #endregion

    }
}
