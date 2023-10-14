using System;
using System.Collections.Generic;

namespace SalesManagementAPI.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            TicketCustomer = new HashSet<TicketCustomer>();
        }

        public Guid Id { get; set; }
        public string TicketCode { get; set; }
        public int? TicketNo { get; set; }
        public int? TicketPrice { get; set; }
        public int? TicketType { get; set; }
        public string SaleStatus { get; set; }
        public DateTime? ExDate { get; set; }
        public int? NoOfTicket { get; set; }
        public Guid? EventId { get; set; }

        public virtual Event Event { get; set; }
        public virtual ICollection<TicketCustomer> TicketCustomer { get; set; }
    }
}
