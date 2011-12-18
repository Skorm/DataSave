using System.Collections.Generic;
using System;
using DataSafeBackend.Profile;
namespace DataSafeBackend
{
    [Serializable]
    public partial class ProfileType
    {
        public ProfileType()
        {
            Contacts = new List<ContactType>();
            Serials = new List<SerialType>();
            Accounts = new List<AccountType>();
        }

        public List<ContactType> Contacts;

        public List<SerialType> Serials;

        public List<AccountType> Accounts;

        public string ProfileName;

        public short ErrorCode; 
    }   
}