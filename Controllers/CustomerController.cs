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
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        public Customer Post(Customer _customer)
        {
            salesDbContext dbContext = new salesDbContext();
            _customer.Id = Guid.NewGuid();
            dbContext.Customer.Add(_customer);
            dbContext.SaveChanges();
            return _customer;
            
        }

        [HttpGet]
        public List<Customer> Get()
        {
            salesDbContext dbContext = new salesDbContext();
            return dbContext.Customer.ToList();
        }
    }
}
