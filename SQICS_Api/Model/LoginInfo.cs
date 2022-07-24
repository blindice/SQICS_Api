using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Model
{
    public class LoginInfo
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string FullName { get; set; }

        public int SupplierId { get; set; }

        public string SupplierName { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }
    }
}
