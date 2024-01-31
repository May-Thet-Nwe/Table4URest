using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Table4URest.Server.Data;
using Table4URest.Server.IRepository;
using Table4URest.Shared.Domain;

namespace Table4URest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationFiltersController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
          private readonly IUnitOfWork _unitOfWork;
        //public LocationFiltersController(ApplicationDbContext context)
          public LocationFiltersController(IUnitOfWork unitOfWork)
            {
                //_context = context;
                _unitOfWork = unitOfWork;
            }

        // GET: api/LocationFilters
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<LocationFilter>>> GetLocationFilters()
        public async Task<IActionResult> GetLocationFilters()
        {
          var locationfilters = await _unitOfWork.LocationFilters.GetAll();
            if (locationfilters == null)
            {
                return NotFound();
            }
            return Ok(locationfilters);
        }

        // GET: api/LocationFilters/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<LocationFilter>> GetLocationFilter(int id)
        public async Task<IActionResult> GetLocationFilter(int id)
        {
          
            var locationfilter = await _unitOfWork.LocationFilters.Get(q=>q.Id==id);

            if (locationfilter == null)
            {
                return NotFound();
            }

            return Ok(locationfilter);
        }

        // PUT: api/LocationFilters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocationFilter(int id, LocationFilter locationfilter)
        {
            if (id != locationfilter.Id)
            {
                return BadRequest();
            }

            //_context.Entry(locationFilter).State = EntityState.Modified;
            _unitOfWork.LocationFilters.Update(locationfilter);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!LocationFilterExists(id))
                if (!await LocationFilterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
                
            }

            return NoContent();
        }

        // POST: api/LocationFilters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LocationFilter>> PostLocationFilter(LocationFilter locationfilter)
        {
          await _unitOfWork.LocationFilters.Insert(locationfilter);
          await _unitOfWork.Save(HttpContext);
          return CreatedAtAction("GetLocationFilter", new { id = locationfilter.Id }, locationfilter);
        }

        // DELETE: api/LocationFilters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocationFilter(int id)
        {
            var locationfilter = await _unitOfWork.LocationFilters.Get(q => q.Id == id);
            if (locationfilter==null)
            {
                return NotFound();
            }
            await _unitOfWork.LocationFilters.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
        }

        private async Task<bool> LocationFilterExists(int id)
        {
            //return (_context.LocationFilters?.Any(e => e.Id == id)).GetValueOrDefault();
            var locationfilter = await _unitOfWork.LocationFilters.Get(q => q.Id == id);
            return locationfilter!=null;
        }
    }
}
