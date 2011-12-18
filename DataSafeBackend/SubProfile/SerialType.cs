using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSafeBackend.Profile
{
    [Serializable]
    public partial class SerialType
    {
        public string Name;

        public List<string> Serials;
    }
}
