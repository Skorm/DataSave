using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataSafeBackend
{
    public class Serializer
    {
        public static MemoryStream getSerializedStream(ProfileType profile)
		{	
			BinaryFormatter binFormatter = new BinaryFormatter();
            MemoryStream mStream = new MemoryStream();
            binFormatter.Serialize(mStream, profile);
            return mStream;
		}

        public static  ProfileType getDeserializedProfile(MemoryStream mStream)
        {
			BinaryFormatter binFormatter = new BinaryFormatter();
            ProfileType profile = new ProfileType();
            if (mStream.Length == 1)
            {
                profile = new ProfileType();
            }
            else
            {
                profile = (ProfileType)binFormatter.Deserialize(mStream);
            }
			return profile;
        }
    }
}
