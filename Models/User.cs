using System;
using System.Collections.Generic;

namespace SalesManagementAPI.Models
{
    public partial class User
    {
        public Guid Id { get; set; }
        public Guid PartnerId { get; set; }
        public int UserType { get; set; }
        public string Password { get; set; }

        public virtual Partner Partner { get; set; }
    }
}
