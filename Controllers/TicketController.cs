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
    public class TicketController : ControllerBase
    {
        [HttpGet]
        public List<Ticket> Get()
        {
            salesDbContext dbContext = new salesDbContext();
            return dbContext.Ticket.ToList();
        }

        [HttpPost]
        public Ticket Post(Ticket _ticket)
        {
            salesDbContext dbContext = new salesDbContext();
            if (_ticket.Id == Guid.Empty)
            {
                _ticket.Id = Guid.NewGuid();
                dbContext.Ticket.Add(_ticket);
                dbContext.SaveChanges();
                return _ticket;
            }
            else
            {
                dbContext.Ticket.Update(_ticket);
                dbContext.SaveChanges();
                return _ticket;
            }

        }

        [HttpGet ("{_Id}")]
        public List<Ticket> Get(Guid _Id)
        {
            salesDbContext dbContext = new salesDbContext();
            var ticketList = dbContext.Ticket.ToList();

            return ticketList.FindAll(tic => tic.EventId == _Id).ToList();
        }


    }
}
