using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSafeBackend
{
    public class Enumerators
    {
        public enum ProfileTypeErrorCodes : short
        {
            NoFailture = 0,
            FileNotFound = 1,
            ReadFileError = 2,
            SerializerError = 3
        }
    }
}
