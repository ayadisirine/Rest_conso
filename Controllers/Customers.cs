using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rocket_Elevators_Rest_API.Models;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_Rest_API.Data;
using Pomelo.EntityFrameworkCore.MySql;

namespace Rocket_Elevators_Rest_API.Models.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly  rocketelevators_developmentContext _context;

        public CustomersController( rocketelevators_developmentContext context)
        {
            _context = context;

        }

        // To see all customer                                         
        // GET: api/customer/all           
        [HttpGet("all")]
        public IEnumerable<Customers> Getcustomers()
        {
            IQueryable<Customers> Customers =
                from l in _context.Customers
                select l;
            return Customers.ToList();
        }

        [HttpGet("email/{email}")]
        // User is free to check different status : in our case just make intervention 
        public IEnumerable<Customers> checkUser(string email)
        {
            //Prepare the request 
            IQueryable<Customers> customers = from l in _context.Customers
            //define condition status should be equal to given values 
                                             where l.TechnicalAuthorityEmail == email
                                             select l;
            //show results 
            return customers.ToList();

        }

        [HttpGet("Id/{id}")]
        // User is free to check different status : in our case just make intervention 
        public IEnumerable<Customers> getCustomerByID(long id)
        {
            //Prepare the request 
            IQueryable<Customers> customers = from l in _context.Customers
            //define condition status should be equal to given values 
                                             where l.Id == id
                                             select l;
            //show results 
            return customers.ToList();

        }

    }
}