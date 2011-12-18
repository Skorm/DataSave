using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace DataSafeBackend
{
    public class DataOperations
    {
        public static bool ComparePasswords(string PasswordOne, string PasswordTwo)
        {
            if (PasswordOne == PasswordTwo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Liest das Profileverzeichniss und erstellt eine Liste der ProfilDateien
        private static FileInfo[] PathReader()
        {
            FileInfo[] files;
			FolderCheck();
            string path = Directory.GetCurrentDirectory() + "\\Profiles";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
			files = dirInfo.GetFiles("*.dat");
			return files;
        }

        //Wandelt die Profildateinamen in Namen um
        public static List<string> GetNamesOfAvaibleProfiles()
        {
            
            List<string> names = new List<string>();
            foreach ( FileInfo entry in PathReader())
            {
                names.Add(entry.Name.Replace(".dat",""));   
            }
            return names;
        }

        //Löscht die angegebene Profildatei
        public static void ProfileFileDelete(string profileName)
        {
            if(ChekProfileFileExsists(profileName))
            {
                File.Delete(GetProfileFilePath(profileName));  
            }
        }

        public static bool ChekProfileFileExsists(string profileName)
        {
            FileInfo fileInfo = new FileInfo(GetProfileFilePath(profileName));
            if (fileInfo.Exists)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private static string GetProfilePath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "Profiles");
        }

        public static string GetProfileFilePath(string profileName)
        {
            return Path.Combine(GetProfilePath() +"\\"+  profileName  + ".dat");
        }

		private static void FolderCheck()
		{
			DirectoryInfo dirInfo = new DirectoryInfo(GetProfilePath());
			if (!dirInfo.Exists)
			{
				CreateProfileFolder(dirInfo.FullName);
			}

		}

		//Profile Controllstructures
		private static void CreateProfileFolder(string path)
		{
			Directory.CreateDirectory(path);
		}

        public static void WriteProfileToDisk(ProfileType profile, string key)
        {
            FileStream fStream = File.Open(Path.Combine(DataOperations.GetProfilePath(), profile.ProfileName + ".dat"), FileMode.Create);
            byte[] encryptedBytes = CryptographyHelper.Encrypt(Serializer.getSerializedStream(profile).ToArray(), key);
            fStream.Write(encryptedBytes, 0, encryptedBytes.Length);
            fStream.Close();
        }

        public static ProfileType GetProfileFromDisk(string ProfileName, string Key)
        {
            if(ChekProfileFileExsists(ProfileName))
            {
                FileStream FileStream;
                MemoryStream MemoryStream;
                try
                {
                    FileStream = new FileStream(DataOperations.GetProfileFilePath(ProfileName), FileMode.Open);
                    byte[] EncrypedFromStream = new byte[FileStream.Length];
                    FileStream.Read(EncrypedFromStream, 0, EncrypedFromStream.Length);
                    MemoryStream = new MemoryStream(CryptographyHelper.Decrypt(EncrypedFromStream, Key));
                }
                catch
                {
                    ProfileType Profile = new ProfileType();
                    Profile.ErrorCode = (short)Enumerators.ProfileTypeErrorCodes.ReadFileError;
                    return Profile;
                }
                try
                {
                    ProfileType Profile = Serializer.getDeserializedProfile(MemoryStream);
                    FileStream.Close();
                    MemoryStream.Close();
                    Profile.ErrorCode = (short)Enumerators.ProfileTypeErrorCodes.NoFailture;
                    return Profile;
                }
                catch
                {
                    ProfileType Profile = new ProfileType();
                    Profile.ErrorCode = (short)Enumerators.ProfileTypeErrorCodes.SerializerError;
                    return Profile;
                }
            }
            else
            {
                ProfileType Profile = new ProfileType();
                Profile.ErrorCode = (short)Enumerators.ProfileTypeErrorCodes.FileNotFound;
                return Profile;
            }
        }
    }
}
