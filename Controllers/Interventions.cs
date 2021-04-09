using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rocket_Elevators_Rest_API.Models;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_Rest_API.Data;





namespace Rocket_Elevators_Rest_API.Models.Controllers
{   [ApiController]
    [Route("api/[controller]")]
   
    public class InterventionsController : ControllerBase
    {
        private readonly rocketelevators_developmentContext _context;

        public InterventionsController(rocketelevators_developmentContext context)
        {
            _context = context;
        }

        // GET: api/interventions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interventions>>> GetInterventions()
        {
            return await _context.Interventions.ToListAsync();
        }
        



    /*PUT: Change the status of the intervention request to "InProgress" and add a
     start date and time (Timestamp). 
     /api/interventions/inprogress/id  */ 
     [HttpPut("inprogress/{id}")]
        public async Task<IActionResult> PutmodifyInterventionsStatus(long id)
        {



            var intervention = await _context.Interventions.FindAsync(id);
            intervention.Status = "InProgress";
            intervention.start_intervention = System.DateTime.Now;;     
                 
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterventionsExists(id))
                    return NotFound();
                else
                    throw;
            }

            return new OkObjectResult("success");
        }


/*PUT: Change the status of the request for action to "Completed" 
and add an end date and time (Timestamp).  
/api/interventions/completed/id */ 
     [HttpPut("completed/{id}")]
        public async Task<IActionResult> PutcompletedInterventionsStatus(long id)
        {



            var intervention = await _context.Interventions.FindAsync(id);
            intervention.Status = "Completed";
            intervention.end_intervention = System.DateTime.Now;     
                 
            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterventionsExists(id))
                    return NotFound();
                else
                    throw;
            }

            return new OkObjectResult("success");
        }


     
/* GET: Returns all fields of all intervention Request records 
that do not have a start date and are in "Pending" status. 
/api/interventions/pending */
       [HttpGet("pending")]
        public ActionResult<List<Interventions>> GetPendingInterventions()
        {
            IQueryable<Interventions> PendingInterventionsList = from i in _context.Interventions
            where (i.Status == "Pending") && (i.start_intervention == null) 
            select i ;

            return PendingInterventionsList.Distinct().ToList();
        }
        private bool InterventionsExists(long id)
        {
            return _context.Interventions.Any(e => e.Id == id);
        }


    }




    
}