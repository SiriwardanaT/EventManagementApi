using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Partner> Get()
        {
            salesDbContext dbContext = new salesDbContext();
            return dbContext.Partner.ToList();
        }


        [HttpPost]
        public Partner Post(Partner _partner)
        {
            salesDbContext dbContext = new salesDbContext();
            if (_partner.Id == Guid.Empty)
            {
                _partner.Id = Guid.NewGuid();
                dbContext.Partner.Add(_partner);
                dbContext.SaveChanges();
                return _partner;
            }
            else
            {
                dbContext.Partner.Update(_partner);
                dbContext.SaveChanges();
                return _partner;
            }
            
        }
    }
}
