using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSafeBackend.Profile.Contact
{
    [Serializable]
    public partial class EmailType
    {


        private string emailAdressField;

        private string nameField;

        public string emailAdress
        {
            get
            {
                return this.emailAdressField;
            }
            set
            {
                this.emailAdressField = value;
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
    }
}
