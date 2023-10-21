using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementAPI.AuthModal
{
    public class Auth
    {
        public string Phone { get; set; }
        public string Password { get; set; }
        public int  UserType { get; set; }
        public string FirstName { get; set; }

        public Guid PartnerId { get; set; }
    }
}
