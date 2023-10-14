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
    public class EventController : ControllerBase
    {
        [HttpGet]
        public List<Event> Get()
        {
            salesDbContext dbContext = new salesDbContext();
            return dbContext.Event.ToList();
        }

        [HttpPost]
        public Event Post(Event _event)
        {
            salesDbContext dbContext = new salesDbContext();
            if (_event.Id == Guid.Empty)
            {
                _event.Id = Guid.NewGuid();
                dbContext.Event.Add(_event);
                dbContext.SaveChanges();
                return _event;
            }
            else
            {
                dbContext.Event.Update(_event);
                dbContext.SaveChanges();
                return _event;
            }

        }

        [HttpGet ("{_id}")]
        public List<Event> Get(Guid _id)
        {
            salesDbContext dbContext = new salesDbContext();
            var evelist =  dbContext.Event.ToList();

            return evelist.FindAll(eve => eve.PartnerId == _id).ToList();
        }
    }

}
