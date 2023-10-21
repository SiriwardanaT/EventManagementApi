using System;
using System.Collections.Generic;

namespace SalesManagementAPI.Models
{
    public partial class Partner
    {
        public Partner()
        {
            Event = new HashSet<Event>();
            User = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nic { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
