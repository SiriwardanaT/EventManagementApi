using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketCustomerController : ControllerBase
    {
        [HttpPost]
        public TicketCustomer Post(TicketCustomer _ticketCustomer)
        {

            salesDbContext dbContext = new salesDbContext();
            Ticket ticket = dbContext.Ticket.FirstOrDefault(tik => tik.Id == _ticketCustomer.TicketId);

            if (ticket.NoOfTicket >= _ticketCustomer.NumberOfTicket)
            {
                _ticketCustomer.Id = Guid.NewGuid();
                dbContext.TicketCustomer.Add(_ticketCustomer);
                dbContext.SaveChanges();

                ticket.NoOfTicket -= _ticketCustomer.NumberOfTicket;
                dbContext.Ticket.Update(ticket);
                dbContext.SaveChanges();
                return _ticketCustomer;
            }
            else 
            {
                return null;
            }
        }

        [HttpGet]
        public List<TicketCustomer> Get()
        {
            salesDbContext dbContext = new salesDbContext();
            return dbContext.TicketCustomer.ToList();
        }

        [HttpGet("{ticket}")]
        public List<TicketCustomer> Get(Guid ticket)
        {

            salesDbContext dbContext = new salesDbContext();

            var allSles = dbContext.TicketCustomer.ToList().FindAll(e => e.TicketId == ticket);
            return allSles;
        }
    }
}
