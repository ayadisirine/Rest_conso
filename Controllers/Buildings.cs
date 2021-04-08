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
    [Route("api/Buildings")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly rocketelevators_developmentContext _context;

        public BuildingsController(rocketelevators_developmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buildings>>> GetBuildings()
        {
            return await _context.Buildings.ToListAsync();
        }
      // GET: api/buildings
        // Retrieving a list of Buildings requiring intervention 
       [HttpGet("Intervention")]
        public ActionResult<List<Buildings>> GetToFixBuildings()
        {
            IQueryable<Buildings> ToFixBuildingsList = from bat in _context.Buildings
            join Batteries in _context.Batteries on bat.Id equals Batteries.BuildingId 
            join Columns in _context.Columns on Batteries.Id equals Columns.BatteryId
            join Elevators in _context.Elevators on Columns.Id equals Elevators.ColumnId
            where (Batteries.Status == "Intervention") || (Columns.Status == "Intervention") || (Elevators.Status == "Intervention")
            select bat;
            return ToFixBuildingsList.Distinct().ToList();
        }

      // GET: 
        // Retrieving a list of 
       [HttpGet("customer/{id}")]
        public ActionResult<List<Buildings>> GetcustomerBuildings(long id)
        {

            //Prepare the request 
            IQueryable<Buildings> buildings = from l in _context.Buildings
            //define condition status should be equal to given values 
                                             where l.CustomerId == id
                                             select l;
            //show results 
            return buildings.ToList();
        }        
       

      
    }
}