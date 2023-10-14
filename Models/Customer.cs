using System;
using System.Collections.Generic;

namespace SalesManagementAPI.Models
{
    public partial class Customer
    {
        public Customer()
        {
            TicketCustomer = new HashSet<TicketCustomer>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Nic { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<TicketCustomer> TicketCustomer { get; set; }
    }
}
