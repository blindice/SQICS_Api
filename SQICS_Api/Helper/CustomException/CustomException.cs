using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Helper.CustomException
{
    public class CustomException : Exception
    {
        public CustomException(string msg) : base(msg)
        {

        }
    }
}
