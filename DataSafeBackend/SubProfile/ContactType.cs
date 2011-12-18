using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSafeBackend.Profile.Contact;
namespace DataSafeBackend.Profile
{
    [Serializable]
    public partial class ContactType : IComparable<ContactType>
    {
        private string vornameField;

        private string nameField;

        private string straßeField;

        private string ortField;

        private string postleitzahlField;

        private string hausnummerField;

        private List<PhoneType> phoneListField;

        private List<EmailType> emailListField;

        public string vorname
        {
            get
            {
                return this.vornameField;
            }
            set
            {
                this.vornameField = value;
            }
        }

        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        public string straße
        {
            get
            {
                return this.straßeField;
            }
            set
            {
                this.straßeField = value;
            }
        }

        public string ort
        {
            get
            {
                return this.ortField;
            }
            set
            {
                this.ortField = value;
            }
        }

        public string postleitzahl
        {
            get
            {
                return this.postleitzahlField;
            }
            set
            {
                this.postleitzahlField = value;
            }
        }

        public string hausnummer
        {
            get
            {
                return this.hausnummerField;
            }
            set
            {
                this.hausnummerField = value;
            }
        }

        public List<PhoneType> phoneList
        {
            get
            {
                return this.phoneListField;
            }
            set
            {
                this.phoneListField = value;
            }
        }

        public List<EmailType> emailList
        {
            get
            {
                return this.emailListField;
            }
            set
            {
                this.emailListField = value;
            }
        }

        public int CompareTo(ContactType other)
        {
            return vorname.CompareTo(other.vorname);
        }
    }
}
