using System;
using System.Collections.Generic;

namespace SalesManagementAPI.Models
{
    public partial class Event
    {
        public Event()
        {
            Ticket = new HashSet<Ticket>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTime? Time { get; set; }
        public int? Type { get; set; }
        public int? TicketCount { get; set; }
        public Guid? PartnerId { get; set; }

        public virtual Partner Partner { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
