using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesManagementAPI.AuthModal;
using SalesManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public List<Partner> Get()
        {
            return null;
        }


        [HttpPost]
        public Auth Post(Auth auth)
        {
            salesDbContext dbContext = new salesDbContext();
            Partner partner = dbContext.Partner.FirstOrDefault(pa => pa.Phone == auth.Phone);

            if (partner != null && partner.Id != null)
            {
                User user = dbContext.User.FirstOrDefault(use => use.Password == auth.Password && use.PartnerId == partner.Id);
                if (user != null && user.Id != Guid.Empty)
                {
                    auth.FirstName = partner.FirstName;
                    auth.UserType = user.UserType;
                    auth.PartnerId = partner.Id;
                    return auth;
                }
                else
                {
                    return null;
                }
            }
            else 
            {
                return null;
            }
        }
    }
}
