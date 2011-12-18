using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace DataSafeBackend
{
    public class IOHelper
    {
        //Liest das Profileverzeichniss und erstellt eine Liste der ProfilDateien
        private  FileInfo[] PathReader()
        {
            FileInfo[] files;
            string path = Directory.GetCurrentDirectory() + "\\Profiles";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            files = dirInfo.GetFiles();
            return files;
        }

        //Wandelt die Profildateinamen in Namen um
        public  List<string> GetProfileeNames()
        {
            
            List<string> names = new List<string>();
            foreach ( FileInfo entry in PathReader())
            {
                names.Add(entry.Name.Replace(".xml",""));   
            }
            return names;
        }

        //Löscht die angegebene Profildatei
        public void profileFileDelete(string profileName)
        {
            string profileFileName = Path.Combine(Directory.GetCurrentDirectory(),"Profiles",profileName+".dat");
            File.Delete(profileFileName);  
        }

        //Durch den übergebenen Namen wird der Pfad zu der gewählten Profiledatei erstellt
        public static string getProfileFilePath(string profileName)
        {
            string applicatioPath = Directory.GetCurrentDirectory();
            string profilePath = Path.Combine(applicatioPath, "Profiles", profileName + ".dat");
            return profilePath;
        }

        //Fragt den Pfad für den Profilordner ab
        public static string getProfilePath()
        {
            string applicatioPath = Directory.GetCurrentDirectory();
            string profilePath = Path.Combine(applicatioPath, "Profiles");
            return profilePath;
        }

        //Erstellt den Profilepfad, wenn er nicht exsistiert
        public static void profileFolderHelper()
        {
            string path = getProfilePath();
            if (!folderCheck(path))
            {
                createProfileFolder(path);
            }
        }

        //Überprüft ob der Profilordner exsetiert
        private static bool folderCheck(string path)
        {
            
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (dirInfo.Exists)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Erstellt den Profilordner
        private static void createProfileFolder(string path)
        {
            Directory.CreateDirectory(path);
        }

        //Überprüft ob das Zielprofil als Datei exsetiert
        public static bool ChekFileExsists(string profileName)
        {
            string filePath = getProfileFilePath(profileName);
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists)
            {
                return true;
            }

            else
            {
                return false;
            }
        } 
    }
}
