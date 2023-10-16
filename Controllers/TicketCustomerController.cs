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
            _ticketCustomer.Id = Guid.NewGuid();
            dbContext.TicketCustomer.Add(_ticketCustomer);
            dbContext.SaveChanges();
            return _ticketCustomer;

        }

        [HttpGet]
        public List<TicketCustomer> Get()
        {
            salesDbContext dbContext = new salesDbContext();
            return dbContext.TicketCustomer.ToList();
        }
    }
}
