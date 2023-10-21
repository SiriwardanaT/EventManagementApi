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
    public class UserController : ControllerBase
    {
        [HttpPost]
        public User Post(User _user)
        {
            _user.UserType = 2;
            salesDbContext dbContext = new salesDbContext();

            _user.Id = Guid.NewGuid();
            dbContext.User.Add(_user);
            dbContext.SaveChanges();
             return _user;
        }
    }
}
