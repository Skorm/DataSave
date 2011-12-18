using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Collections;

namespace AdressBook
{
    /// <summary>
    /// </summary>
    public partial class App : Application
    {
        public static int HigestLengthOfProfileName;
        public static List<string> ListOfAvaibleProfiles;
        public static string key;
        public static profileType activeProfile;
        public static bool guiIsProfileLoaded;
        public static MainWindow PonterMainWindow;
    }
}
