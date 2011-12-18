using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Security;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DataSafeBackend
{
	public class CryptographyHelper
	{
        static byte[] IV = new byte[16] { 33, 241, 14, 16, 103, 18, 14, 248, 4, 54, 18, 5, 60, 76, 16, 191 };
    
		public static byte[] keyProtect(string key)
		{
			byte[] byteKeyPassword = Encoding.GetEncoding(1252).GetBytes(key);

			if (byteKeyPassword.Length < 16)
			{
				byte[] byteKeyComplete = new byte[16];
				byteKeyPassword.CopyTo(byteKeyComplete, 0);
				ProtectedMemory.Protect(byteKeyComplete, MemoryProtectionScope.SameLogon);
				return byteKeyComplete;
			}

			else if (byteKeyPassword.Length == 16)
			{
				ProtectedMemory.Protect(byteKeyPassword, MemoryProtectionScope.SameLogon);
				return byteKeyPassword;
			}

			else
			{
				return null;
			}
		}

		public static string keyUnprotect(byte[] byteKey)
		{
			ProtectedMemory.Unprotect(byteKey, MemoryProtectionScope.SameLogon);
			string stringKey = Encoding.ASCII.GetString(byteKey);
			return stringKey;
		}

        public static byte[] GetPassword(string password)
        {
            const string salt = "L9O2Z1N22QRWE415492354PNVGJDC";
            byte[] pwd = Encoding.Unicode.GetBytes(password);
            byte[] slt = Encoding.Unicode.GetBytes(salt);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(pwd, slt, "SHA1", 2);
            byte[] keyBytes = pdb.GetBytes(8);
            return keyBytes;
        }


		public static byte[] Decrypt(byte[] encryptedData, string Key)
		{
			byte[] ByteKey = GetPassword(Key);

			DESCryptoServiceProvider DES = new DESCryptoServiceProvider();

			DES.Key = ByteKey;

			DES.IV = ByteKey;

			ICryptoTransform desDecrypt = DES.CreateDecryptor();

			byte[] decryptedData;

			try
			{
				decryptedData = desDecrypt.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
			}
			catch
			{
				decryptedData = new byte[1]{0};
			}

			return decryptedData;
		}

		public static byte[] Encrypt(byte[] plainData, string Key)
		{

			byte[] byteKey = GetPassword(Key);

			DESCryptoServiceProvider DES = new DESCryptoServiceProvider();

			DES.Key = byteKey;

			DES.IV = byteKey;

			ICryptoTransform desencrypt = DES.CreateEncryptor();

			byte[] encryptedData = desencrypt.TransformFinalBlock(plainData, 0, plainData.Length);

			return encryptedData;

		}
	}
}