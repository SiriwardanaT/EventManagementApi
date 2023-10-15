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
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public List<Partner> Get()
        {
            return null;
        }


        [HttpPost]
        public Partner Post(Partner _partner)
        {
            return null;

        }
    }
}
