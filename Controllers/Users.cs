using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Rocket_Elevators_Rest_API.Data;

namespace Rocket_Elevators_Rest_API.Models.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly rocketelevators_developmentContext _context;
        public UserController(rocketelevators_developmentContext context)
        {
            _context = context;
        }

        // To see all the Users                           
        // GET: api/Users/all
        [HttpGet("all")]
        public IEnumerable<Users> GetUser()
        {
            return _context.Users;
        }

        // To get an intervention by email                              
        // GET: api/User/{email}  
        [HttpGet("{User_email}")]
        public ActionResult<List<Users>> FindUser_Email(string User_email)
        {
            var Email = _context.Users.Where(t => t.Email == User_email).ToList();

            if (Email.Count == 0)
            {
                return NotFound();
            }

            return Ok();
        }

    }
}