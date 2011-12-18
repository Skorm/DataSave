using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSafeBackend.Profile.Contact
{
    public partial class PhoneType
    {
        private string phoneNummberField;

        private string nameField;

        public string phoneNummber
        {
            get
            {
                return this.phoneNummberField;
            }
            set
            {
                this.phoneNummberField = value;
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
